using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    /// <summary>
    /// �����, ��� �������� ������ (��� ���� � ����� ������) ��� ������ ������ FastReport
    /// </summary>
    public class EpsReportExportContainer
    {
        public string TypeName { get; private set; }

        public byte[] Bytes { get; private set; }

        public string DefaultExtension { get; private set; }

        /// <summary>
        /// ������ ��� ������ ������ FastReport
        /// </summary>
        /// <param name="nameType">�������� ����</param>
        /// <param name="stream">����� ������</param>
        /// <param name="defaultExtension">���������� ������� ����������</param>
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