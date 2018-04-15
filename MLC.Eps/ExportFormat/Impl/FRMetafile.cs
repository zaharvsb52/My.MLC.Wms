using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Экпорт отчета в формате изображения metafile
    /// </summary>
    public class FRMetafile : BaseExportFormat
    {
        public FRMetafile()
        {
            FileExtension = "emf";
        }

        protected override ExportBase CreateExporter()
        {
            var res = new FastReport.Export.Image.ImageExport();
            res.ImageFormat = FastReport.Export.Image.ImageExportFormat.Metafile;
            res.SeparateFiles = false;
            return res;
        }
   }
}