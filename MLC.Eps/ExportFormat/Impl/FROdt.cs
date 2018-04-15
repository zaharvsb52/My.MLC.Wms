using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате ODT - текстовые файлы формата OpenDocument (OpenOffice)
    /// </summary>
    public class FROdt : BaseExportFormat
    {
        public FROdt()
        {
            FileExtension = "odt";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.Odf.ODTExport();
        }
    }
}