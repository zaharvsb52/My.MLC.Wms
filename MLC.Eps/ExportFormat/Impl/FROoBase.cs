using System;
using FastReport.Export;

namespace MLC.Eps.ExportFormat.Impl
{
    /// <summary>
    /// File created by OpenOffice.org Base (OOBase).
    /// </summary>
    [Obsolete]
    public class FROoBase : BaseExportFormat
    {
        public FROoBase()
        {
            FileExtension = "odb";
        }

        protected override ExportBase CreateExporter()
        {
            return new FastReport.Export.OoXML.OOExportBase();
        }
    }
}