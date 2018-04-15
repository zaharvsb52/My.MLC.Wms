using System;
using System.Diagnostics.Contracts;

namespace MLC.Eps.ExportFormat
{
    [ContractClass(typeof(IReportExporterFactoryContract))]
    public interface IReportExporterFactory
    {
        IExportFormat CreateExporter(string name);
    }

    [ContractClassFor(typeof(IReportExporterFactory))]
    abstract class IReportExporterFactoryContract : IReportExporterFactory
    {
        IExportFormat IReportExporterFactory.CreateExporter(string name)
        {
            Contract.Requires(!string.IsNullOrEmpty(name));
            Contract.Ensures(Contract.Result<IExportFormat>() != null);
            throw new NotImplementedException();
        }
    }
}