using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате изображения png
    /// </summary>
    public class FRPng : BaseExportFormat
    {
        public FRPng()
        {
            FileExtension = "png";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Image.ImageExport
            {
                ImageFormat = FastReport.Export.Image.ImageExportFormat.Png,
                SeparateFiles = false
            };
            return res;
        }
    }
}