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
            // �� ����� ����� Wf ���������� ���� Interceptor
            var interceptor = new WorkflowSignSessionInterceptor(_userName);
            childContainer.RegisterInstance(typeof(IWorkflowSessionInterceptor), interceptor);

            var abacContext = new WfAbacContext(_userName);
            childContainer.RegisterInstance(typeof(IAbacContext), abacContext);

            // ��������� Environment � child ����������
            // (��� ����� ��� ����, ����� ��� ����� ����� ��������� � ��� ��� ������ Environment,
            //  �.�. ��� ������ � ������� � Web-��������� HttpContext.Current ����� ������ ��� �������� ������ ����������)
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