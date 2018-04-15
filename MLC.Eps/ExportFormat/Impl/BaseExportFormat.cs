using System;
using System.IO;
using System.Text;
using FastReport;
using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    public abstract class BaseExportFormat : IExportFormat
    {
        private readonly Lazy<ExportBase> _exportBase;

        protected BaseExportFormat()
        {
            _exportBase = new Lazy<ExportBase>(CreateExporter);
            SupportsEncoding = false;
            SupportsSpacelife = false;
        }

        public virtual void Export(Report report, Stream stream)
        {
            _exportBase.Value.Export(report, stream);
        }

        public string FileExtension { get; protected set; }

        public bool SupportsEncoding { get; protected set; }

        public bool SupportsSpacelife { get; protected set; }

        public virtual void SetEncoding(Encoding encoding)
        {
            if (SupportsEncoding)
                throw new NotImplementedException();

            throw new NotSupportedException();
        }

        public virtual void SetSpacelife(bool val)
        {
            if (SupportsSpacelife)
                throw new NotImplementedException();

            throw new NotSupportedException();
        }

        protected T GetOrCreateExporter<T>()
            where T : ExportBase
        {
            return (T)_exportBase.Value;
        }

        protected abstract ExportBase CreateExporter();

        public virtual void Dispose()
        {
            if (_exportBase.IsValueCreated)
            {
                _exportBase.Value.Clear();
                _exportBase.Value.Dispose();
            }
        }
    }
}