using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    [ContractClass(typeof (IEpsTaskFactoryContract))]
    public interface IEpsTaskFactory
    {
        IEpsTask CreateTask(IEpsTaskConfig config);
    }

    [ContractClassFor(typeof (IEpsTaskFactory))]
    abstract class IEpsTaskFactoryContract : IEpsTaskFactory
    {
        IEpsTask IEpsTaskFactory.CreateTask(IEpsTaskConfig config)
        {
            Contract.Requires(config != null);
            Contract.Ensures(Contract.Result<IEpsTask>() != null);
            throw new System.NotImplementedException();
        }
    }
}