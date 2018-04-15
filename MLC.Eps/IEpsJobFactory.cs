using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    [ContractClass(typeof (IEpsJobFactoryContract))]
    public interface IEpsJobFactory
    {
        IEpsJob CreateJob(IEpsJobConfig config);
    }

    [ContractClassFor(typeof (IEpsJobFactory))]
    abstract class IEpsJobFactoryContract : IEpsJobFactory
    {
        IEpsJob IEpsJobFactory.CreateJob(IEpsJobConfig config)
        {
            Contract.Requires(config != null);
            Contract.Ensures(Contract.Result<IEpsJob>() != null);
            throw new System.NotImplementedException();
        }
    }
}