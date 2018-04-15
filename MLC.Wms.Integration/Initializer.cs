using System.Web.Hosting;
using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Integration.v1;
using MLC.Wms.Workflows;

namespace MLC.Wms.Integration
{
    public class Initializer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Initializer));
        private static bool _isStarting;

        public static void AppInitialize()
        {
            if (_isStarting || HostingEnvironment.InClientBuildManager)
                return;

            _isStarting = true;
            XmlConfigurator.Configure();

            UnityConfig.RegisterComponents(Configure);

            Log.Debug("Integration service was configured");
        }

        private static void Configure(IUnityContainer container)
        {
            // регистрируем сервисы
            container.RegisterType<IQueueService, QueueService>();

            // выставляем контейнер для фабрики сервисов
            WcfServiceFactory.SetRootContainer(container);

            // инициализируем Environment
            container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILocalData, WebLocalData>(new ContainerControlledLifetimeManager());
            WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

            // запускаем wf
            WorkflowServicesUnityConfigurator.Configure(container, false);
        }
    }
}