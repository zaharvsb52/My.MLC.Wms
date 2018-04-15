using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате изображения - bmp
    /// </summary>
    public class FRBmp : BaseExportFormat
    {
        public FRBmp()
        {
            FileExtension = "bmp";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Image.ImageExport();
            res.ImageFormat = FastReport.Export.Image.ImageExportFormat.Bmp;
            res.SeparateFiles = false;
            return res;
        }
    }
}