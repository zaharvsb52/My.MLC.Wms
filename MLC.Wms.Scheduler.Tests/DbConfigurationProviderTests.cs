using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.DataAccess;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using Quartz;
using Quartz.Impl.Triggers;

namespace MLC.Wms.Scheduler.Tests
{
    [TestFixture]
    public class DbConfigurationProviderTests
    {
        private const string TstSchedulerName = "TST_NUNIT";
        private const string SampleCronExpression = "0 0 12 1 1 ? *";
        private IUnityContainer _container;

        [TestFixtureSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(container =>
            {
                _container = container;

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());
            });
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
        }

        private void DoWithData(Action<ISession, DbConfigurationProvider> action)
        {
            using (var childContainer = _container.CreateChildContainer())
            {
                var sessionFactory = childContainer.Resolve<ISessionFactory>();

                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var sessionDecorator = new SessionDecorator(session) {DoNotDispose = true};
                    var sessionFactoryMock = new Mock<ISessionFactory>();
                    sessionFactoryMock.Setup(i => i.OpenSession()).Returns(sessionDecorator);

                    PopulateTestData(session);

                    session.Flush();

                    // засыпаем на 2 секунды, чтобы детектить изменения
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                    var provider = new DbConfigurationProvider(sessionFactoryMock.Object);

                    action(session, provider);

                    transaction.Rollback();
                }
            }
        }

        /// <summary>
        /// Сценарий:
        /// Job1 - нормальный
        /// Job2 - имеет один триггер с датой старта больше текущей
        /// Job3 - имеет один триггер с датой окончания меньше текущей
        /// Job4 - имеет один заблокированный триггер
        /// Job5 - имеет два триггера: один заблокирован, один нормальный
        /// </summary>
        /// <param name="session"></param>
        private static void PopulateTestData(ISession session)
        {
            var scheduler = new SchScheduler { Code = TstSchedulerName };
            session.Save(scheduler);

            var jobType = new SchJobType
            {
                Code = "TST Job Type",
                ClassName = string.Format("{0}, MLC.Wms.Scheduler.Tests", typeof(FakeJob).FullName),
                Scheduler = scheduler
            };
            session.Save(jobType);

            var job1 = new SchJob
            {
                JobType = jobType,
                Code = "TST_JOB1",
                Scheduler = scheduler
            };
            session.Save(job1);

            var job1Param1 = new SchJobParam
            {
                Name = "TST_JOB1_PARAM1",
                Job = job1,
                Value = "TST VALUE"
            };
            session.Save(job1Param1);
            job1.Job_SchJobParam_List.Add(job1Param1);

            var job1Trigger1 = new SchCronTrigger
            {
                Code = "TST_JOB1_TR1",
                CronExpression = SampleCronExpression,
                MisfireInstruction = 1,
                StartTimeUtc = DateTime.UtcNow.AddDays(-1),
                Job = job1,
                Scheduler = scheduler
            };
            session.Save(job1Trigger1);
            job1.Job_SchTrigger_List.Add(job1Trigger1);

            // job 2
            var job2 = new SchJob
            {
                JobType = jobType,
                Code = "TST_JOB2",
                Scheduler = scheduler
            };
            session.Save(job2);
            var job2Trigger1 = new SchCronTrigger
            {
                Code = "TST_JOB2_TR1",
                CronExpression = SampleCronExpression,
                MisfireInstruction = 1,
                StartTimeUtc = DateTime.UtcNow.AddDays(1),
                Job = job2,
                Scheduler = scheduler
            };
            session.Save(job2Trigger1);
            job2.Job_SchTrigger_List.Add(job2Trigger1);

            // job 3
            var job3 = new SchJob
            {
                JobType = jobType,
                Code = "TST_JOB3",
                Scheduler = scheduler
            };
            session.Save(job3);
            var job3Trigger1 = new SchCronTrigger
            {
                Code = "TST_JOB3_TR1",
                CronExpression = SampleCronExpression,
                MisfireInstruction = 1,
                StartTimeUtc = DateTime.UtcNow.AddDays(-2),
                EndTimeUtc = DateTime.UtcNow.AddDays(-1),
                Job = job3,
                Scheduler = scheduler
            };
            session.Save(job3Trigger1);
            job3.Job_SchTrigger_List.Add(job3Trigger1);

            // job 4
            var job4 = new SchJob
            {
                JobType = jobType,
                Code = "TST_JOB4",
                Scheduler = scheduler
            };
            session.Save(job4);
            var job4Trigger1 = new SchCronTrigger
            {
                Code = "TST_JOB4_TR1",
                CronExpression = SampleCronExpression,
                MisfireInstruction = 1,
                StartTimeUtc = DateTime.UtcNow.AddDays(-2),
                EndTimeUtc = DateTime.UtcNow.AddDays(+1),
                Disabled = true,
                Job = job4,
                Scheduler = scheduler
            };
            session.Save(job4Trigger1);
            job4.Job_SchTrigger_List.Add(job4Trigger1);

            // job 5
            var job5 = new SchJob
            {
                JobType = jobType,
                Code = "TST_JOB5",
                Scheduler = scheduler
            };
            session.Save(job5);
            var job5Trigger1 = new SchCronTrigger
            {
                Code = "TST_JOB5_TR1",
                CronExpression = SampleCronExpression,
                MisfireInstruction = 1,
                StartTimeUtc = DateTime.UtcNow.AddDays(-2),
                EndTimeUtc = DateTime.UtcNow.AddDays(+1),
                Disabled = true,
                Job = job5,
                Scheduler = scheduler
            };
            session.Save(job5Trigger1);
            job5.Job_SchTrigger_List.Add(job5Trigger1);

            var job5Trigger2 = new SchCronTrigger
            {
                Code = "TST_JOB5_TR2",
                CronExpression = SampleCronExpression,
                MisfireInstruction = 1,
                StartTimeUtc = DateTime.UtcNow.AddDays(-2),
                EndTimeUtc = DateTime.UtcNow.AddDays(+1),
                Job = job5,
                Scheduler = scheduler
            };
            session.Save(job5Trigger2);
            job5.Job_SchTrigger_List.Add(job5Trigger2);
        }

        [Test]
        public void GetJobsTest()
        {
            DoWithData((session, provider) =>
            {
                var res = provider.GetJobs(TstSchedulerName);

                res.Should().NotBeNull();
                res.Should().HaveCount(2);

                var resJob1 = res.FirstOrDefault(i => i.Key.Key.Name == "TST_JOB1");
                resJob1.Should().NotBeNull();
                resJob1.Value.Should().HaveCount(1);

                var resJob5 = res.FirstOrDefault(i => i.Key.Key.Name == "TST_JOB5");
                resJob5.Should().NotBeNull();
                resJob5.Value.Should().HaveCount(1);
                resJob5.Value.First().Key.Name.ShouldBeEquivalentTo("TST_JOB5_TR2");
            });
        }

        [Test]
        public void TestChange_Job_AddNew()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у Job1 добавляем новый параметр
                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                var newJob = new SchJob
                {
                    Code = "TST_NEWJOB",
                    JobType = job1.JobType,
                    Scheduler = job1.Scheduler
                };
                session.Save(newJob);
                var jobNewTrigger1 = new SchCronTrigger
                {
                    Code = "TST_JOBNEW_TR1",
                    Scheduler = job1.Scheduler,
                    StartTimeUtc = DateTime.UtcNow.AddDays(-1),
                    Job = newJob,
                    CronExpression = SampleCronExpression
                };
                session.Save(jobNewTrigger1);
                newJob.Job_SchTrigger_List.Add(jobNewTrigger1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo(newJob.Code);
                changedJobs.Values.Single().Should().HaveCount(1);
                changedJobs.Values.Single().Single().Key.Name.ShouldBeEquivalentTo(jobNewTrigger1.Code);
            });
        }

        [Test]
        public void TestChange_Job_AddNewWithoutTriggers()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у Job1 добавляем job без триггера
                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                var newJob = new SchJob
                {
                    Code = "TST_NEWJOB",
                    JobType = job1.JobType,
                    Scheduler = job1.Scheduler
                };
                session.Save(newJob);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // 1 job будет, т.к. мы не знаем что именно произошло: у старого удалили trigger или добавили job без триггера
                deletedJobs.Should().HaveCount(1);
                changedJobs.Should().HaveCount(0);
            });
        }

        [Test]
        public void TestChange_Job_Delete()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                foreach (var item in job1.Job_SchJobParam_List)
                    session.Delete(item);
                foreach (var item in job1.Job_SchTrigger_List)
                    session.Delete(item);
                session.Delete(job1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(1);
                changedJobs.Should().HaveCount(0);
            });
        }

        [Test]
        public void TestChange_Job_Change()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                job1.Description = "New description";
                session.Save(job1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo(job1.Code);
                changedJobs.Values.Single().Should().HaveCount(1);
                changedJobs.Values.Single().Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1_TR1");
            });
        }

        [Test]
        public void TestChange_JobParameter_Add()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у Job1 добавляем новый параметр
                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                var job1Param2 = new SchJobParam
                {
                    Job = job1,
                    Name = "TST_JOB1_PARAM2",
                    Value = "Some value"
                };
                session.Save(job1Param2);
                job1.Job_SchJobParam_List.Add(job1Param2);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo(job1.Code);
                changedJobs.Keys.Single().JobDataMap.Should().ContainKey(job1Param2.Name);
                changedJobs.Keys.Single().JobDataMap[job1Param2.Name].ShouldBeEquivalentTo(job1Param2.Value);
                changedJobs.Values.Single().Should().HaveCount(1);
                changedJobs.Values.Single().Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1_TR1");
            });
        }

        [Test]
        public void TestChange_JobParameter_Change()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у Job1 меняем значение параметра
                var job1Param1 = session.Query<SchJobParam>().Single(i => i.Name == "TST_JOB1_PARAM1");
                job1Param1.Value = "Some other value";
                session.Save(job1Param1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1");
                changedJobs.Keys.Single().JobDataMap.Should().ContainKey(job1Param1.Name);
                changedJobs.Keys.Single().JobDataMap[job1Param1.Name].ShouldBeEquivalentTo(job1Param1.Value);
                changedJobs.Values.Single().Should().HaveCount(1);
                changedJobs.Values.Single().Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1_TR1");
            });
        }

        [Test]
        public void TestChange_JobParameter_Delete()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у Job1 меняем значение параметра
                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                var job1Param1 = session.Query<SchJobParam>().Single(i => i.Name == "TST_JOB1_PARAM1");
                session.Delete(job1Param1);
                job1.Job_SchJobParam_List.Remove(job1Param1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;

                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1");
                changedJobs.Keys.Single().JobDataMap.Should().NotContainKey(job1Param1.Name);
                changedJobs.Values.Single().Should().HaveCount(1);
                changedJobs.Values.Single().Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1_TR1");
            });
        }

        [Test]
        public void TestChange_Trigger_AddNew()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у job 2 добавляем рабочий триггер
                var job2 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB2");
                var job2Trigger2 = new SchCronTrigger
                {
                    Scheduler = job2.Scheduler,
                    Code = "TST_JOB2_TR2",
                    Job = job2,
                    StartTimeUtc = DateTime.UtcNow.AddDays(-1),
                    CronExpression = SampleCronExpression
                };
                session.Save(job2Trigger2);
                job2.Job_SchTrigger_List.Add(job2Trigger2);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo("TST_JOB2");
                changedJobs.Values.Should().HaveCount(1);
                changedJobs.Values.Single().Should().HaveCount(1);
                changedJobs.Values.Single().Should().ContainSingle(i => i.Key.Name == "TST_JOB2_TR2");
            });
        }

        [Test]
        public void TestChange_Trigger_AddOneMore()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у job 1 добавляем 2ой триггер
                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                var job1Trigger2 = new SchCronTrigger
                {
                    Scheduler = job1.Scheduler,
                    Code = "TST_JOB1_TR2",
                    Job = job1,
                    StartTimeUtc = DateTime.UtcNow.AddDays(-1),
                    CronExpression = SampleCronExpression
                };
                session.Save(job1Trigger2);
                job1.Job_SchTrigger_List.Add(job1Trigger2);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1");
                changedJobs.Values.Should().HaveCount(1);
                changedJobs.Values.Single().Should().HaveCount(2);
                changedJobs.Values.Single().Should().ContainSingle(i => i.Key.Name == "TST_JOB1_TR1");
                changedJobs.Values.Single().Should().ContainSingle(i => i.Key.Name == "TST_JOB1_TR2");
            });
        }

        [Test]
        public void TestChange_Trigger_ChangeCronField()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у 1 job двигаем дату окончания в прошлое
                var job1Trigger1 = session.Query<SchCronTrigger>().Single(i => i.Code == "TST_JOB1_TR1");
                job1Trigger1.CronExpression = "0 0 12 2 1 ? *";
                session.Save(job1Trigger1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().HaveCount(0);
                changedJobs.Should().HaveCount(1);
                changedJobs.Keys.Single().Key.Name.ShouldBeEquivalentTo("TST_JOB1");
                changedJobs.Values.Should().HaveCount(1);
                changedJobs.Values.Single().Should().HaveCount(1);
                var resTrigger = (CronTriggerImpl)changedJobs.Values.Single().Single(i => i.Key.Name == "TST_JOB1_TR1");
                resTrigger.CronExpressionString.ShouldBeEquivalentTo(job1Trigger1.CronExpression);
            });
        }

        [Test]
        public void TestChange_Trigger_ChangeEndTimeUtc()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у 1 job двигаем дату окончания в прошлое
                var job1Trigger1 = session.Query<SchCronTrigger>().Single(i => i.Code == "TST_JOB1_TR1");
                job1Trigger1.EndTimeUtc = DateTime.Now.AddHours(-5);
                session.Save(job1Trigger1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().ContainSingle(i => i.Name == "TST_JOB1");
                changedJobs.Should().HaveCount(0);
            });
        }

        [Test]
        public void TestChange_Trigger_ChangeStartTimeUtc()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у 1 job двигаем дату начала в будущее
                var job1Trigger1 = session.Query<SchCronTrigger>().Single(i => i.Code == "TST_JOB1_TR1");
                job1Trigger1.StartTimeUtc = DateTime.Now.AddDays(1);
                session.Save(job1Trigger1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().ContainSingle(i => i.Name == "TST_JOB1");
                changedJobs.Should().HaveCount(0);
            });
        }

        [Test]
        public void TestChange_Trigger_Delete()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у job 1 удаляем триггер
                var job1 = session.Query<SchJob>().Single(i => i.Code == "TST_JOB1");
                var job1Trigger1 = session.Query<SchCronTrigger>().Single(i => i.Code == "TST_JOB1_TR1");
                session.Delete(job1Trigger1);
                job1.Job_SchTrigger_List.Remove(job1Trigger1);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().ContainSingle(i => i.Name == "TST_JOB1");
                changedJobs.Should().HaveCount(0);
            });
        }

        [Test]
        public void TestChange_Trigger_Disable()
        {
            DoWithData((session, provider) =>
            {
                // берем дату проверки
                var checkDate = DateTime.Now;

                // засыпаем на 2 секунды, чтобы детектить изменения
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // у 5 job блокируем триггер
                var job5Trigger2 = session.Query<SchCronTrigger>().Single(i => i.Code == "TST_JOB5_TR2");
                job5Trigger2.Disabled = true;
                session.Save(job5Trigger2);

                session.Flush();

                // поехали
                JobKey[] deletedJobs;
                IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> changedJobs;
                provider.GetChangedJobs(TstSchedulerName, checkDate, out deletedJobs, out changedJobs);

                // проверяем
                deletedJobs.Should().ContainSingle(i => i.Name == "TST_JOB5");
                changedJobs.Should().HaveCount(0);
            });
        }
    }

    public class FakeJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
        }
    }
}
