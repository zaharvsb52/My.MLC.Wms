using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате XPS - документ, хранения и просмотра спецификаций
    /// </summary>
    public class FRXps : BaseExportFormat
    {
        public FRXps()
        {
            FileExtension = "xps";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.OoXML.XPSExport();
        }
    }
}
