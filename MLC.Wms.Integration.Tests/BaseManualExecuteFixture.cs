using System;
using log4net.Config;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using NUnit.Framework;
using MLC.Wms.Workflows;

namespace MLC.Wms.Integration.Tests
{
    [TestFixture, Ignore("Only manually executable.")]
    internal abstract class BaseManualExecuteFixture
    {
        private IUnityContainer _container;

        [TestFixtureSetUp]
        public void Setup()
        {
            // init log4net
            XmlConfigurator.Configure();

            UnityConfig.RegisterComponents(container =>
            {
                container.RegisterType<IWmsEnvironmentInfoProvider, ManualWmsEnvironmentInfoProvider>(
                    new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), null);

                // запускаем wf
                WorkflowServicesUnityConfigurator.Configure(container, false);

                _container = container;
            });
        }

        protected void WithChildContainer(Action<IUnityContainer> action)
        {
            using (var childContainer = _container.CreateChildContainer())
            {
                action(childContainer);
            }
        }
    }
}