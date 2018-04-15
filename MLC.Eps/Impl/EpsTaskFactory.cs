using System;
using Microsoft.Practices.Unity;

namespace MLC.Eps.Impl
{
    public class EpsTaskFactory : IEpsTaskFactory
    {
        private readonly IUnityContainer _container;

        public EpsTaskFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IEpsTask CreateTask(IEpsTaskConfig config)
        {
            Type taskType;
            switch (config.TaskExecutorType)
            {
                case EpsTaskExecutorTypes.PRINT:
                    taskType = typeof(EpsTaskPrintExport);
                    break;
                case EpsTaskExecutorTypes.MAIL:
                    taskType = typeof(EpsTaskMailExport);
                    break;
                case EpsTaskExecutorTypes.SHARE:
                    taskType = typeof (EpsTaskShareExport);
                    break;
                case EpsTaskExecutorTypes.FTP:
                    taskType = typeof (EpsTaskFtpExport);
                    break;

                default:
                    throw new Exception(string.Format("Unknown Task type {0}.", config.TaskExecutorType));
            }

            return (IEpsTask)_container.Resolve(taskType, new ParameterOverride("config", config));
        }
    }
}