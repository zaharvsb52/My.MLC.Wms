using System;
using FastReport;
using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// Сохранение отчета в формате предпросмотра
    /// </summary>
    public class FRFpx : BaseExportFormat
    {
        public FRFpx()
        {
            FileExtension = "fpx";
        }

        public override void Export(Report report, System.IO.Stream stream)
        {
            report.SavePrepared(stream);
        }

        protected override ExportBase CreateExporter()
        {
            throw new NotSupportedException();
        }
    }
}