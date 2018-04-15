using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате DBF
    /// </summary>
    public class FRDbf : BaseExportFormat
    {
        public FRDbf()
        {
            FileExtension =  "dbf";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Dbf.DBFExport();
        }
    }
}