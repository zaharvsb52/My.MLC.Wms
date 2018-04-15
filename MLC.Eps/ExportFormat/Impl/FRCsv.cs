using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using FastReport;
using FastReport.Export;
using FastReport.Export.Csv;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате CSV - тектовый формат с разделителем 
    /// </summary>
    public class FRCsv : BaseExportFormat
    {
        private Encoding _encoding = Encoding.UTF8;
        private bool _spacelife;

        public FRCsv()
        {
            FileExtension = "csv";
            SupportsEncoding = true;
            SupportsSpacelife = true;
        }

        public override void Export(Report report, Stream stream)
        {
            Contract.Requires(report != null);
            Contract.Requires(stream != null);

            var exp = GetOrCreateExporter<CSVExport>();
            if (_spacelife)
            {
                using (var ms = new MemoryStream())
                {
                    exp.Encoding = Encoding.UTF8;
                    exp.Export(report, ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    using (var sr = new StreamReader(ms, Encoding.UTF8))
                    using (var sw = new StreamWriter(stream, _encoding))
                    {
                        var content = sr.ReadToEnd().Replace("$endline$", string.Empty);
                        sw.Write(content);
                    }
                }
            }
            else
            {
                exp.Encoding = _encoding;
                exp.Export(report, stream);
            }
        }

        protected override ExportBase CreateExporter()
        {
            return new CSVExport();
        }

        public override void SetEncoding(Encoding encoding)
        {
            Contract.Requires(encoding != null);

            _encoding = encoding;
        }

        public override void SetSpacelife(bool val)
        {
            _spacelife = val;
        }
    }
}