using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате изображения jpeg
    /// </summary>
    public class FRJpeg : BaseExportFormat
    {
        public FRJpeg()
        {
            FileExtension = "jpg";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Image.ImageExport();
            res.ImageFormat = FastReport.Export.Image.ImageExportFormat.Jpeg;
            res.SeparateFiles = false;
            return res;
        }
    }
}