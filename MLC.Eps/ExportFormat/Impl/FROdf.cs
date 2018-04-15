using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате ODT - открытый формат файлов документов OpenDocument (OpenOffice)
    /// </summary>
    public class FROdf : BaseExportFormat
    {
        public FROdf()
        {
            FileExtension = "odf";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Odf.ODFExport();
        }
    }
}

