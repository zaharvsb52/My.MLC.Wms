using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    /// <summary>
    /// Класс, для передачи данных (имя типа и поток данных) для экпорт отчета FastReport
    /// </summary>
    public class EpsReportExportContainer
    {
        public string TypeName { get; private set; }

        public byte[] Bytes { get; private set; }

        public string DefaultExtension { get; private set; }

        /// <summary>
        /// Данных для экпорт отчета FastReport
        /// </summary>
        /// <param name="nameType">название типа</param>
        /// <param name="stream">поток данных</param>
        /// <param name="defaultExtension">расширение данного экпортрера</param>
        public EpsReportExportContainer(string nameType, byte[] bytes, string defaultExtension)
        {
            Contract.Requires(nameType != null);
            Contract.Requires(bytes != null);
            Contract.Requires(defaultExtension != null);

            TypeName = nameType;
            Bytes = bytes;
            DefaultExtension = defaultExtension;
        }
    }
}