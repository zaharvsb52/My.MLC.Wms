using System;
using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    [ContractClass(typeof (IEpsReportContract))]
    public interface IEpsReport : IDisposable
    {
        string ReportName { get; }
        string ReportResultFileName { get; }

        void AddExportType(ExportType exportType);
        void Prepare();
        void Export();

        EpsReportExportContainer GetExportContainer(ExportType exportType);
        void Print(string physicalPrinter, int copies);
    }

    [ContractClassFor(typeof (IEpsReport))]
    abstract class IEpsReportContract : IEpsReport
    {
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        string IEpsReport.ReportName
        {
            get { throw new NotImplementedException(); }
        }

        string IEpsReport.ReportResultFileName
        {
            get { throw new NotImplementedException(); }
        }

        void IEpsReport.AddExportType(ExportType exportType)
        {
            throw new NotImplementedException();
        }

        void IEpsReport.Prepare()
        {
            throw new NotImplementedException();
        }

        void IEpsReport.Export()
        {
            throw new NotImplementedException();
        }

        EpsReportExportContainer IEpsReport.GetExportContainer(ExportType exportType)
        {
            Contract.Requires(exportType != null);
            Contract.Ensures(Contract.Result<EpsReportExportContainer>() != null);

            throw new NotImplementedException();
        }

        void IEpsReport.Print(string physicalPrinter, int copies)
        {
            Contract.Requires(string.IsNullOrEmpty(physicalPrinter));
            Contract.Requires(copies > 0);
        }
    }
}