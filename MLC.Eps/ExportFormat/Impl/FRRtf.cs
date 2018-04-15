using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате текстовых документов (RTF)
    /// </summary>
    public class FRRtf : BaseExportFormat
    {
        public FRRtf()
        {
            FileExtension = "rtf";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.RichText.RTFExport();
        }
    }
}
