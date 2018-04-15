using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    [ContractClass(typeof (IEpsReportFactoryContract))]
    public interface IEpsReportFactory
    {
        IEpsReport CreateReport(IEpsReportConfig config);
    }

    [ContractClassFor(typeof (IEpsReportFactory))]
    abstract class IEpsReportFactoryContract : IEpsReportFactory
    {
        IEpsReport IEpsReportFactory.CreateReport(IEpsReportConfig config)
        {
            Contract.Requires(config != null);
            throw new System.NotImplementedException();
        }
    }
}