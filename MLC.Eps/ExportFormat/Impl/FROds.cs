using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате ODS -  электронные таблицы формата OpenDocument (OpenOffice)
    /// </summary>
    public class FROds : BaseExportFormat
    {
        public FROds()
        {
            FileExtension = "ods";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Odf.ODSExport();
        }
    }
}