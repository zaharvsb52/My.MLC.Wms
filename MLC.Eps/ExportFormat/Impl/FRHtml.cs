using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате HTML
    /// </summary>
    public class FRHtml : BaseExportFormat
    {
        public FRHtml()
        {
            FileExtension = "html";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Html.HTMLExport();
            res.Format = FastReport.Export.Html.HTMLExportFormat.HTML;
            return res;
        }
    }
}