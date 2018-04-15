using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using log4net;
using MLC.Eps.Config;
using MLC.Wms.Model.Entities;
using NHibernate;

namespace MLC.Eps.Server
{
    public class EpsOutputExecutor : IEpsOutputExecutor
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (EpsOutputExecutor));

        public EpsOutputExecutor(ISessionFactory sessionFactory,
            IEpsJobFactory epsJobFactory,
            EpsJobConfigurator epsJobConfigurator)
        {
            Contract.Requires(sessionFactory != null);
            Contract.Requires(epsJobConfigurator != null);

            SessionFactory = sessionFactory;
            EpsJobFactory = epsJobFactory;
            EpsJobConfigurator = epsJobConfigurator;
        }

        protected ISessionFactory SessionFactory { get; private set; }
        protected IEpsJobFactory EpsJobFactory { get; private set; }
        protected EpsJobConfigurator EpsJobConfigurator { get; private set; }

        public IEpsConfiguration EpsConfig => EpsJobConfigurator.EpsConfig;

        public virtual void Execute(object context)
        {
            var outputs = context as EpsOutput[];
            if (outputs == null)
                return;

            foreach (var output in outputs)
            {
                ProcessOutput(output);
            }
        }

        private void ProcessOutput(EpsOutput output)
        {
            var sw = new Stopwatch();
            sw.Start();
            Log.Debug("Start processing.");
            Exception exception = null;

            try
            {
                IEpsJobConfig config;
                using (var session = SessionFactory.OpenSession())
                {
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
            }
            finally
            {
                sw.Stop();
                HandleComplete(output.OutputID, exception, sw.Elapsed);
            }
        }

        private void HandleTaskComplete(int taskId, Exception exception, TimeSpan elapsed)
        {
            HandleComplete(taskId, exception, elapsed);
        }

        private void HandleComplete(int outputId, Exception exception, TimeSpan elapsed)
        {
            Log.DebugFormat("Output task is completed{0}.", exception != null ? " with errors." : null);
            if (exception != null)
                Log.Error(exception);
        }

        protected static void CheckOutput(EpsOutput output)
        {
            if (output.OutputStatus != OutputStatuses.OS_ON_TRANSFER)
                throw new Exception(string.Format("Output {0} in the wrong state. Waiting state {1} but {2}.",
                    output.OutputID, OutputStatuses.OS_ON_TRANSFER, output.OutputStatus));
        }
    }
}