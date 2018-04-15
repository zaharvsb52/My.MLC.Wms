using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате изображения tiff
    /// </summary>
    public class FRTiff : BaseExportFormat
    {
        public FRTiff()
        {
            FileExtension = "tif";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Image.ImageExport
            {
                ImageFormat = FastReport.Export.Image.ImageExportFormat.Tiff,
                SeparateFiles = false
            };
            return res;
        }
   }
}