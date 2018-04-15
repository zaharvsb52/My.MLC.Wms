using System.Activities;
using MLC.WF.Core.Common;
using MLC.WF.Core.Extensions;
using MLC.WF.Core.Extensions.UnityWF;
using MLC.Wms.Api;
using MLC.Wms.Common.DataAccess;
using NHibernate;

namespace MLC.Wms.WF.Activities.Business
{
    /// <summary>
    /// Активити запуска метода WmsAPI
    /// </summary>
    public class ExecuteWmsApi : ExecuteMethod<WmsAPI>
    {
        protected override WmsAPI CreateTarget(NativeActivityContext context)
        {
            var di = context.GetExtension<DependencyInjectionExtension>();
            var sessionShareExtention = context.GetExtension<SessionShareExtention>();

            // Создаем декоратор фабрики для проброса правильного подписчика сессий
            var factory = new SessionFactoryDecorator(context.GetDependency<ISessionFactory>());

            // если есть чем подписать - подписываем
            if (di.IsRegistered<IWorkflowSessionInterceptor>())
                factory.Interceptor = di.GetDependency<IWorkflowSessionInterceptor>();

            // Если сессией управляют извне - настраиваем соответсвующие декораторы
            if (sessionShareExtention.SharedSession != null)
            {
                var sessionDecorator = new SessionDecorator(sessionShareExtention.SharedSession) {DoNotDispose = true};
                if (sessionShareExtention.SharedSession.Transaction != null)
                    sessionDecorator.ExternalTransaction =
                        new TransactionDecorator(sessionShareExtention.SharedSession.Transaction)
                        {
                            DisableActions = true
                        };

                factory.ExternalSession = sessionDecorator;
            }

            return new WmsAPI(factory,
                context.GetDependency<IWmsXmlConverter>(),
                context.GetDependency<IWorkflowLoader>());
        }
    }
}
