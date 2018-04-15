using System;
using System.IO;
using System.Text;
using FastReport;
using FastReport.Export;
using FastReport.Export.Text;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате текста
    /// </summary>
    public class FRText : BaseExportFormat
    {
        private Encoding _encoding = Encoding.UTF8;
        private bool _spacelife;

        public FRText()
        {
            FileExtension = "txt";
            SupportsEncoding = true;
            SupportsSpacelife = true;
        }

        public override void Export(Report report, Stream stream)
        {
            var exp = GetOrCreateExporter<TextExport>();
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
            var res = new TextExport
            {
                PageBreaks = false,
                EmptyLines = false,
                DataOnly = false,
                Frames = false,
                Encoding = new UnicodeEncoding()
            };
            return res;
        }

        public override void SetEncoding(Encoding encoding)
        {
            if (encoding == null)
                throw new ArgumentNullException("encoding");

            _encoding = encoding;
        }

        public override void SetSpacelife(bool val)
        {
            _spacelife = val;
        }
    }
}
