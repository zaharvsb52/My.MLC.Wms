using System;
using System.Configuration;
using System.Security.Authentication;
using System.ServiceProcess;
using System.Threading.Tasks;
using log4net;
using Microsoft.Practices.Unity;
using MLC.Eps;
using MLC.Eps.Config;
using MLC.Eps.ExportFormat;
using MLC.Eps.ExportFormat.Impl;
using MLC.Eps.Impl;
using MLC.JobRunner.Core;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Common.Services;
using MLC.Wms.Scheduler.Services;
using MLC.Wms.Workflows;
using Quartz;

namespace MLC.Wms.Scheduler
{
    internal class SchedulerHost : ServiceBase
    {
        #region .  Fields  .

        private IScheduler _scheduler;
        private readonly ILog _log = LogManager.GetLogger(typeof(SchedulerHost));

        #endregion

        #region .  ctors  .

        public SchedulerHost(ServiceContext context)
        {
        }

        #endregion

        #region .  ServiceBase  .

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    _log.Info("Start service configure");
                    // конфигурируем приложение
                    UnityConfig.RegisterComponents(Configure);

                    // запускаем scheduler-а
                    _scheduler.Start();
                    _log.Info("Complete service configure");
                }
                catch (Exception ex)
                {
                    _log.Fatal("Error service configure."+ex.Message, ex);
                    throw;
                }
            });
        }

        protected override void OnPause()
        {
            _scheduler.PauseAll();
            base.OnPause();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
            _scheduler.ResumeAll();
        }

        protected override void OnShutdown()
        {
            if (_scheduler.IsStarted)
                _scheduler.Shutdown(true);
            base.OnShutdown();
        }

        protected override void OnStop()
        {
            if (_scheduler != null &&_scheduler.IsStarted)
                _scheduler.Shutdown(true);
            base.OnStop();
        }

        #endregion

        #region .  Methods  .

        public void Start(string[] args)
        {
            OnStart(args);
        }

        private void Configure(IUnityContainer container)
        {
            // инициализируем Environment
            container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
            WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

            AuthenticateService(container);

            InitEps(container);

            // инициализируем Wf
            WorkflowServicesUnityConfigurator.Configure(container, false);

            // инициализируем job-ы
            container.RegisterType<ISchedulerFactory, CustomSchedulerFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<IScheduler>(new InjectionFactory(c => c.Resolve<ISchedulerFactory>().GetScheduler()));
            container.RegisterType<IConfigurationProvider, DbConfigurationProvider>();


            // настраиваем fr
            //осознано выставляем этот параметр, чтобы откл. часть функционала
            FastReport.Utils.Config.WebMode = true;
            FastReport.Utils.RegisteredObjects.AddConnection(typeof(FastReport.Data.OracleDataConnection));

            _scheduler = container.Resolve<IScheduler>();
        }

        private void InitEps(IUnityContainer container)
        {
            var config = (EpsConfigSection)ConfigurationManager.GetSection(EpsConfigSection.DefaultSectionName);

            // регистрируем нужное
            container.RegisterInstance<IEpsConfiguration>(config);
            container.RegisterInstance<IEpsMailConfig>(config.MailSettings);
            container.RegisterType<IEpsJobFactory, EpsJobFactory>();
            container.RegisterType<IEpsTaskFactory, EpsTaskFactory>();
            container.RegisterType<IEpsReportFactory, EpsReportFactory>();
            container.RegisterType<IReportExporterFactory, ReportExporterFactory>();
            container.RegisterType<IMacroProcessor, MacroProcessor>(new PerResolveLifetimeManager());
        }

        /// <summary>
        /// Аутентификация себя (для подписки сессий от имени сервиса)
        /// </summary>
        /// <param name="container"></param>
        private void AuthenticateService(IUnityContainer container)
        {
            var login = ConfigurationManager.AppSettings["SvcLogin"];
            string userName;
            if (string.IsNullOrEmpty(login))
                throw new ConfigurationErrorsException(string.Format("Can't find auth settings '{0}'.", "SvcLogin"));

            var pass = ConfigurationManager.AppSettings["SvcPassword"];
            var authService = container.Resolve<IAuthService>();

            if (!authService.Authenticate(login, pass, out userName))
                throw new AuthenticationException(string.Format("Service is not authenticated with login '{0}'.", login));
        }

        #endregion

        private void InitializeComponent()
        {
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
        }
    }
}
