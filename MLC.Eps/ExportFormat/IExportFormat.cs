using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using FastReport;

namespace MLC.Eps.ExportFormat
{
    /// <summary>
    /// Интерфейс для классов - отчетов Fast Report
    /// </summary>
    [ContractClass(typeof (IExportFormatContract))]
    public interface IExportFormat : IDisposable
    {
        void Export(Report report, Stream stream);
        string FileExtension { get; }

        bool SupportsEncoding { get; }
        void SetEncoding(Encoding encoding);

        bool SupportsSpacelife { get; }
        void SetSpacelife(bool val);
    }

    [ContractClassFor(typeof (IExportFormat))]
    abstract class IExportFormatContract : IExportFormat
    {
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        void IExportFormat.Export(Report report, Stream stream)
        {
            Contract.Requires(report != null);
            Contract.Requires(stream != null);
            throw new NotImplementedException();
        }

        string IExportFormat.FileExtension
        {
            get { throw new NotImplementedException(); }
        }

        bool IExportFormat.SupportsEncoding
        {
            get { throw new NotImplementedException(); }
        }

        void IExportFormat.SetEncoding(Encoding encoding)
        {
            Contract.Requires(encoding != null);
            throw new NotImplementedException();
        }

        bool IExportFormat.SupportsSpacelife
        {
            get { throw new NotImplementedException(); }
        }

        void IExportFormat.SetSpacelife(bool val)
        {
            throw new NotImplementedException();
        }
    }
}