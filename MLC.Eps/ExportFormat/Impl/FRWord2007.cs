using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате Word2007 (*.docx)
    /// </summary>
    public class FRWord2007 : BaseExportFormat
    {
        public FRWord2007()
        {
            FileExtension = "docx";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.OoXML.Word2007Export();
        }
    }
}
