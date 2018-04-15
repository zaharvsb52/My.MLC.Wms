using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате MessageHTML
    /// </summary>
    public class FRMhtml : BaseExportFormat
    {
        public FRMhtml()
        {
            FileExtension = "html";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Html.HTMLExport();
            res.Format = FastReport.Export.Html.HTMLExportFormat.MessageHTML;
            return res;
        }
    }
}