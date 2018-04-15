using Microsoft.Practices.Unity;

namespace MLC.Eps.Impl
{
    public class EpsJobFactory : IEpsJobFactory
    {
        private readonly IUnityContainer _container;

        public EpsJobFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IEpsJob CreateJob(IEpsJobConfig config)
        {
            return _container.Resolve<EpsJob>(
                new ParameterOverride("config", config));
        }
    }
}