using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Common.Logging;
using MLC.Eps;
using MLC.Eps.Server;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using Quartz;

namespace MLC.Wms.Jobs.EPS
{
    /// <summary>
    /// Обработывает очереди eps. Выбирает группу заданий и запускает их параллельно.
    /// * Размер группы определятеся параметром BatchSize.
    /// * Задания из очереди выбираются по параметру Handler.
    /// </summary>
    [DisallowConcurrentExecution]
    public class EpsJobOutputExecutor : EpsOutputExecutor, IJob
    {
        #region .  Fields & Consts  .
        public const int DefaultBatchSize = 20;
        public const string HandlerParamName = "Handler";
        public const string BatchSizeParamName = "BatchSize";
        private static readonly ILog Log = LogManager.GetLogger(typeof(EpsJobOutputExecutor));
        #endregion

        public EpsJobOutputExecutor(ISessionFactory sessionFactory,
            IEpsJobFactory epsJobFactory,
            EpsJobConfigurator epsJobConfigurator) : base(sessionFactory, epsJobFactory, epsJobConfigurator)
        {
        }

        #region .  Methods  .

        void IJob.Execute(IJobExecutionContext context)
        {
            Execute(context);
        }

        public override void Execute(object context)
        {
            var jobcontext = (IJobExecutionContext) context;
            var handler = int.Parse(jobcontext.GetRequiredParameter<string>(HandlerParamName));
            var batchSize = int.Parse(jobcontext.GetNonRequiredParameter(BatchSizeParamName, DefaultBatchSize.ToString()));

            var outputs = LockNextOutputs(handler, batchSize);
            if (outputs.Length == 0)
                return;

            try
            {
                if (outputs.Length == 1)
                    ProcessOutput(outputs[0].OutputID);
                else
                {
                    var tasks = outputs.Select(i => Task.Factory.StartNew(() => ProcessOutput(i.OutputID))).ToArray();
                    Task.WaitAll(tasks);
                }
            }
            catch (Exception ex)
            {
                throw new JobExecutionException("Unhandled exception", ex, false);
            }
        }

        private void ProcessOutput(int outputId)
        {
            var sw = new Stopwatch();
            sw.Start();
            Log.DebugFormat("Output {0}. Start processing.", outputId);
            Exception exception = null;

            try
            {
                IEpsJobConfig config;
                using (var session = SessionFactory.OpenSession())
                {
                    // получаем output
                    var output = session.Get<EpsOutput>(outputId);

                    // проверяем
                    CheckOutput(output);

                    // создаем конфигурацию
                    config = EpsJobConfigurator.Configure(output, session, HandleTaskComplete);
                }

                // запускаем
                using (var job = EpsJobFactory.CreateJob(config))
                    job.Execute();
            }
            catch (Exception ex)
            {
                exception = ex;
                // ничего дальше не пробрасываем - просто меняем статус (в finally)
            }
            finally
            {
                sw.Stop();
                HandleComplete(outputId, exception, sw.Elapsed);
            }
        }

        private void HandleTaskComplete(int taskId, Exception exception, TimeSpan elapsed)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var output = session.Get<EpsOutputTask>(taskId);
                if (exception != null)
                {
                    output.OutputTaskStatus = OutputStatuses.OS_ERROR;
                    output.OutputTaskFeedback = exception.Message;
                    Log.Warn(string.Format("Output task {0} complete with exception '{1}'.", taskId, exception.Message), exception);
                }
                else
                {
                    output.OutputTaskStatus = OutputStatuses.OS_COMPLETED;
                }
                output.OutputTaskTime = elapsed.ToString();
                transaction.Commit();
            }

            Log.DebugFormat("Output task {0}. Complete in {1}.{2}", taskId, elapsed, exception != null ? " With errors." : null);
        }

        private void HandleComplete(int outputId, Exception exception, TimeSpan elapsed)
        {
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var output = session.Get<EpsOutput>(outputId);
                if (exception != null)
                {
                    output.OutputStatus = OutputStatuses.OS_ERROR;
                    var message = GetMeaningExeptionMessage(exception);
                    output.OutputFeedback = message.Length > 4000
                        ? message.Substring(0, 4000)
                        : message;
                    Log.Warn($"Output {outputId} complete with exception '{exception.Message}'.", exception);
                }
                else
                {
                    output.OutputStatus = OutputStatuses.OS_COMPLETED;
                }
                output.OutputTime = elapsed.ToString();
                transaction.Commit();
            }

            Log.DebugFormat("Output {0}. Complete in {1}.{2}", outputId, elapsed, exception != null ? " With errors." : null);
        }

        private static string GetMeaningExeptionMessage(Exception ex)
        {
            var aggregateException = ex as AggregateException;
            if (aggregateException != null)
                return string.Join(";", aggregateException.InnerExceptions.Select(GetMeaningExeptionMessage));

            var invokeException = ex as TargetInvocationException;
            if (invokeException != null)
                return GetMeaningExeptionMessage(invokeException.InnerException);

            return ex.Message;
        }

        private EpsOutput[] LockNextOutputs(int handler, int batchSize)
        {
            //TODO: подумать над разгребанием зависших OutputStatuses.OS_ON_TRANSFER
            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var batchId = Guid.NewGuid().ToString();
                var cmd = string.Format("update epsoutput set outputstatus = 'OS_ON_TRANSFER', OUTPUTFEEDBACK = '{0}' where outputid in (select outputid from (select outputid from epsoutput where outputstatus = 'OS_NEW' and epshandler = {1} order by dateins) where rownum <= {2})", batchId, handler, batchSize);
                var count = session.CreateSQLQuery(cmd).ExecuteUpdate();
                if (count == 0)
                    return new EpsOutput[0];
                transaction.Commit();
                return session.Query<EpsOutput>().Where(i => i.OutputFeedback == batchId).ToArray();
            }
        } 
        #endregion
    }
}