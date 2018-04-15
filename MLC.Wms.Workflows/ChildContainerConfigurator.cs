using Microsoft.Practices.Unity;
using MLC.WF.Core.Common;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using WebClient.Abac;

namespace MLC.Wms.Workflows
{
    internal class ChildContainerConfigurator : IWorkflowChildContainerConfigurator
    {
        private readonly string _userName;

        public ChildContainerConfigurator()
        {
            _userName = WmsEnvironment.UserName;
        }

        public void Configure(IUnityContainer childContainer)
        {
            // на время жизни Wf выставляем свой Interceptor
            var interceptor = new WorkflowSignSessionInterceptor(_userName);
            childContainer.RegisterInstance(typeof(IWorkflowSessionInterceptor), interceptor);

            var abacContext = new WfAbacContext(_userName);
            childContainer.RegisterInstance(typeof(IAbacContext), abacContext);

            // подменяем Environment в child контейнере
            // (это нужно для того, чтобы все время жизни конейнера у нас был единый Environment,
            //  т.к. при работе в потоках в Web-окружении HttpContext.Current будет только для главного потока приложения)
            var wmsEnvironment = new ManualWmsEnvironmentInfoProvider();
            wmsEnvironment.SetUserName(_userName);
            childContainer.RegisterInstance(typeof(IWmsEnvironmentInfoProvider), wmsEnvironment);
        }

        public void BeforeDispose(IUnityContainer childContainer)
        {
            // Do nothing
        }
    }
}