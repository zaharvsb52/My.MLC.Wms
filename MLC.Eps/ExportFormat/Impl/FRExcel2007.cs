using FastReport.Export;
using FastReport.Export.OoXML;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате Excel2007 (*.xlsx)
    /// </summary>
    public class FRExcel2007 : BaseExportFormat
    {
        public FRExcel2007()
        {
            FileExtension = "xlsx";
        }

        protected override ExportBase CreateExporter()
        {
            return new Excel2007Export();
        }
    }
}
