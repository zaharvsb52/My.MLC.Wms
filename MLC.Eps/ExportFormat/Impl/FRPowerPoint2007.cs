using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате Power Point 2007 (*.PPTX)
    /// </summary>
    public class FRPowerPoint2007 : BaseExportFormat
    {
        public FRPowerPoint2007()
        {
            FileExtension = "pptx";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.OoXML.PowerPoint2007Export();
        }
    }
}
