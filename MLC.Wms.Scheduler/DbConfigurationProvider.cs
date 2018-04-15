using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using log4net;
using MLC.JobRunner.Core;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace MLC.Wms.Scheduler
{
    public class DbConfigurationProvider : IConfigurationProvider
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DbConfigurationProvider));
        private readonly ISessionFactory _sessionFactory;

        public DbConfigurationProvider(ISessionFactory sessionFactory)
        {
            Contract.Requires(sessionFactory != null);

            _sessionFactory = sessionFactory;
        }

        #region .  IConfigurationProvider  .

        public IDictionary<string, ICalendar> GetCalendars()
        {
            //NOTE: пока не реализовано
            return new Dictionary<string, ICalendar>();
        }

        public void GetChangedCalendars(out string[] deletedNames, out IDictionary<string, ICalendar> changed)
        {
            //NOTE: пока не реализовано
            deletedNames = new string[0];
            changed = new Dictionary<string, ICalendar>();
        }

        public void GetChangedJobs(string schedulerName, DateTime lastCheckDate, out JobKey[] deletedJobs,
            out IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs)
        {
            deletedJobs = new JobKey[0];
            changedJobs = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();

            using (var session = _sessionFactory.OpenSession())
            {
                var changedItems = GetChangedJobs(session, lastCheckDate);
                if (changedItems.Count == 0)
                    return;

                var tmpDeletedJobs = new List<JobKey>();
                var tmpChangedJobs = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();

                foreach (var item in changedItems)
                {
                    // получаем job по id
                    var job = session.Get<SchJob>(item.Key);

                    // если не нашли - удалили
                    // если не добавили - нет подходящих триггеров
                    if (job == null || !AddJob(job, tmpChangedJobs))
                    {
                        var deletedJobKey = item.Value;
                        // нужно получать из истории
                        if (deletedJobKey == null)
                        {
                            var jobH = session.Query<SchJobHistory>().FirstOrDefault(i => i.ID == item.Key && i.HDateTill > DateTime.Now);
                            if (jobH == null)
                                throw new InvalidOperationException(string.Format("При обновлении заданий возникла ошибка. Для изменения JobId '{0}' не удалось определить JobKey.", item.Key));

                            deletedJobKey = new JobKey(jobH.Code, jobH.JobGroup);
                        }
                        tmpDeletedJobs.Add(deletedJobKey);
                    }
                }

                deletedJobs = tmpDeletedJobs.ToArray();
                changedJobs = tmpChangedJobs;
            }
        }

        public IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> GetJobs(string schedulerName)
        {
            var res = new Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>>();
            using (var session = _sessionFactory.OpenSession())
            {
                var utcDate = DateTime.UtcNow;

                // получаем уникальные job-ы, у которых есть хотя бы один триггер для запуска
                var jobs = session.Query<SchJob>()
                    .Where(i =>
                            i.Job_SchTrigger_List.Any(
                                j => j.StartTimeUtc <= utcDate && (!j.EndTimeUtc.HasValue || utcDate < j.EndTimeUtc) &&
                                     j.Disabled != true &&
                                     j.Scheduler.Code == schedulerName))
                   .Fetch(i => i.JobType)
                   .ToArray();

                foreach (var job in jobs)
                    AddJob(job, res);
            }
            return res;
        }

        #endregion .  IConfigurationProvider  .

        //Проверяем изменение истории сущностей: SchJobHistory, SchJobParamHistory, SchTriggerHistory. При удалении в HSchTrigger, HSchJobParam удаляем и запускаем соответствующие job'ы.
        private static Dictionary<Guid, JobKey> GetChangedJobs(ISession session, DateTime lastCheckDate)
        {
            var res = new Dictionary<Guid, JobKey>();

            //SchJobHistory
            foreach (var h in GetHistoryChanged<SchJobHistory>(session, lastCheckDate))
                res[h.ID] = new JobKey(h.Code, h.JobGroup);

            //SchJobParamHistory
            foreach (var h in GetHistoryChanged<SchJobParamHistory>(session, lastCheckDate))
                if (!res.ContainsKey(h.JobId))
                    res.Add(h.JobId, null);

            //SchTriggerHistory
            foreach (var h in GetHistoryChanged<SchTriggerHistory>(session, lastCheckDate))
                if (!res.ContainsKey(h.JobId))
                    res.Add(h.JobId, null);

            return res;
        }

        private static T[] GetHistoryChanged<T>(ISession session, DateTime lastCheckDate) where T : IHistoryEntity
        {
            var history = session
                .Query<T>()
                .Where(p => lastCheckDate <= p.HDateFrom && p.HDateTill > DateTime.Now)
                .ToArray();
            return history;
        }

        private static bool AddJob(SchJob job, Dictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> targetCollection)
        {
            try
            {
                var jobDetail = BuildJobDetail(job);
                var triggers = BuildTriggers(job);
                if (triggers.Any())
                {
                    targetCollection.Add(jobDetail, triggers);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Ошибка подготовки задания. Задание '{0}' не будет запланировано. {1}", job == null ? string.Empty : job.Code, ex.Message), ex);
            }
            return false;
        }

        private static IJobDetail BuildJobDetail(SchJob job)
        {
            if (job == null)
                throw new ArgumentNullException("job");

            var jobType = Type.GetType(job.JobType.ClassName);
            if (jobType == null)
                throw new InvalidOperationException(string.Format("Не удалось найти задание с именем реализатора '{0}'.", job.JobType.ClassName));

            return new JobDetailImpl(job.Code, job.JobGroup, jobType)
            {
                Description = job.Description,
                JobDataMap = new JobDataMap(job.Job_SchJobParam_List.ToDictionary(i => i.Name, p => p.Value))
            };
        }

        private static Quartz.Collection.ISet<ITrigger> BuildTriggers(SchJob job)
        {
            var utcDate = DateTime.UtcNow;
            var res = new Quartz.Collection.HashSet<ITrigger>();
            foreach (var trigger in job.Job_SchTrigger_List)
            {
                if (trigger.Disabled == true)
                    continue;

                if (utcDate < trigger.StartTimeUtc || trigger.EndTimeUtc <= utcDate)
                    continue;

                res.Add(BuildTrigger(trigger));
            }
            return res;
        }

        private static ITrigger BuildTrigger(SchTrigger trigger)
        {
            IMutableTrigger qtrigger;
            var cronTrigger = trigger as SchCronTrigger;
            int defaultMisfireInstruction;
            if (cronTrigger != null)
            {
                qtrigger = new CronTriggerImpl(trigger.Code, trigger.TriggerGroup)
                {
                    CronExpressionString = cronTrigger.CronExpression
                };

                defaultMisfireInstruction = MisfireInstruction.CronTrigger.DoNothing;
            }
            else
            {
                var simpleTrigger = trigger as SchSimpleTrigger;
                if (simpleTrigger != null)
                {
                    qtrigger = new SimpleTriggerImpl(trigger.Code, trigger.TriggerGroup)
                    {
                        RepeatCount = simpleTrigger.RepeatCount,
                        RepeatInterval = TimeSpan.FromMilliseconds(simpleTrigger.RepeatIntervalInMs)
                    };

                    defaultMisfireInstruction = MisfireInstruction.SimpleTrigger.RescheduleNextWithRemainingCount;
                }
                else
                    throw new Exception(string.Format("Unknown trigger type '{0}'.", trigger));
            }

            // Вот тут может упасть при проверке значения - ну и пусть. Job с ошибкой нам запускать нельзя
            qtrigger.MisfireInstruction = defaultMisfireInstruction;

            qtrigger.Description = trigger.Description;
            qtrigger.StartTimeUtc = trigger.StartTimeUtc;
            qtrigger.EndTimeUtc = trigger.EndTimeUtc;
            qtrigger.Priority = trigger.Priority;

            return qtrigger;
        }
    }
}