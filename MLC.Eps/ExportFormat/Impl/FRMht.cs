using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате MHT - веб-архив, в который упаковывается все содержимое веб-страницы
    /// </summary>
    public class FRMht : BaseExportFormat
    {
        public FRMht()
        {
            FileExtension = "mht";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Mht.MHTExport();
        }
    }
}
