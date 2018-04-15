using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Authentication;
using log4net;
using MLC.Eps.Server;
using MLC.Wms.Common;
using MLC.Wms.Model.Entities;
using NHibernate;
using Quartz;

namespace MLC.Wms.Jobs.EPS
{
    /// <summary>
    /// «апускает задание Eps.
    /// </summary>
    [DisallowConcurrentExecution]
    public class EpsJobExecutor : IJob
    {
        #region .  Fields & Consts  .
        public const string EpsJobCodeParamName = "EpsJobCode";

        private readonly ISessionFactory _sessionFactory;
        private static readonly ILog Log = LogManager.GetLogger(typeof(EpsJobExecutor)); 
        #endregion

        public EpsJobExecutor(ISessionFactory sessionFactory)
        {
            Contract.Requires(sessionFactory != null);
            _sessionFactory = sessionFactory;
        }

        public void Execute(IJobExecutionContext context)
        {
            var jobCode = context.GetRequiredParameter<string>(EpsJobCodeParamName);
            var inputParams = context.MergedJobDataMap
               .Where(item => item.Key != EpsJobCodeParamName).ToArray();
            var parameters = inputParams.Length > 0
                ? inputParams.ToDictionary(item => item.Key, item => item.Value)
                : null;

            using (var session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {

                    var executor = WmsEnvironment.UserName;
                    if (string.IsNullOrEmpty(executor))
                        throw new AuthenticationException("Executor is not Authenticated.");

                    var job = session.Get<EpsJob>(jobCode);
                    if (job == null)
                        throw new JobExecutionException(string.Format("Can't find job with code '{0}'.", jobCode));

                    if (!job.JobHandler.HasValue)
                        throw new JobExecutionException(
                            string.Format("Job '{0}' has no JobHandler. Please check job settings.", jobCode));

                    //if (job.JobHandler != _handler)
                    //    throw new JobExecutionException(string.Format("Executor for job '{0}' can execute only jobs with handler {1}, but this job have handler {2}. Please check job settings.", jobCode, _handler, job.JobHandler));

                    if (job.JobLocked)
                        throw new JobExecutionException(string.Format("Eps job '{0}' is locked.", jobCode));

                    // пытаемс€ применить быструю проверку необходимости запуска
                    if (!EpsHelper.IsNeedToStart(job, session))
                        throw new JobExecutionException(
                            string.Format("Job '{0}' shouldn't be executed. Check return 0 rows.", jobCode));

                    try
                    {
                        // дополн€ем задачу параметрами и разбиваем, если нужно
                        var additionalParameters = EpsHelper.GetAddigionalParametersAndSplit(job, session);
                        if (parameters != null && parameters.Count > 0)
                        {
                            //≈сли сверху пришли параметры, примен€ем их к каждому элементу массива
                            if (additionalParameters == null)
                                additionalParameters = new List<Dictionary<string, object>>();

                            if (additionalParameters.Count > 0)
                            {
                                foreach (var par in additionalParameters)
                                {
                                    foreach (var newpar in parameters)
                                    {
                                        par[newpar.Key] = newpar.Value;
                                    }
                                }
                            }
                            else
                            {
                                additionalParameters.Add(parameters);
                            }
                        }

                        if (additionalParameters == null)
                        {
                            var output = EpsHelper.ProcessEpsJob(executor, job, session, null, Log);
                            EpsHelper.SaveEpsOutput(output, session);
                        }
                        else
                        {
                            if (additionalParameters.Count == 0)
                                throw new Exception(
                                    string.Format("Job '{0}' shouldn't be executed. Split query return 0 rows.", jobCode));

                            foreach (var p in additionalParameters)
                            {
                                var output = EpsHelper.ProcessEpsJob(executor, job, session, p, Log);
                                EpsHelper.SaveEpsOutput(output, session);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new JobExecutionException(ex);
                    }

                    transaction.Commit();
                }
            }
        }
    }
}