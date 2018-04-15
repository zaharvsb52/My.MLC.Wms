using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате изображения gif
    /// </summary>
    public class FRGif : BaseExportFormat
    {
        public FRGif()
        {
            FileExtension = "gif";
        }

        protected override ExportBase CreateExporter()
        {
            var res =  new FastReport.Export.Image.ImageExport();
            res.ImageFormat = FastReport.Export.Image.ImageExportFormat.Gif;
            res.SeparateFiles = false;
            return res;
        }
    }
}