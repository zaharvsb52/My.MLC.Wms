using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате PDF
    /// </summary>
    public class FRPdf : BaseExportFormat
    {
        public FRPdf()
        {
            FileExtension = "pdf";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Pdf.PDFExport();
        }
    }
}
