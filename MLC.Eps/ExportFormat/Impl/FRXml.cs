using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using System.Xml;
using FastReport;
using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате XML (excel 2003+)
    /// </summary>
    public class FRXml : BaseExportFormat
    {
        private Encoding _encoding = Encoding.UTF8;

        public FRXml()
        {
            FileExtension = "xls";
            SupportsEncoding = true;
        }

        public override void Export(Report report, Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                base.Export(report, stream);

                ms.Seek(0, SeekOrigin.Begin);
                var doc = new XmlDocument();
                doc.Load(ms);
                
                using (var writer = new StreamWriter(stream, _encoding))
                {
                    doc.Save(writer);
                }
            }
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Xml.XMLExport();
        }

        public override void SetEncoding(Encoding encoding)
        {
            Contract.Requires(encoding != null);

            _encoding = encoding;
        }
    }
}
