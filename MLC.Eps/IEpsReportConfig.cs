using System.Collections.Generic;

namespace MLC.Eps
{
    /// <summary>
    /// ������������ ������
    /// </summary>
    public interface IEpsReportConfig
    {
        /// <summary>
        /// ��� ������
        /// </summary>
        string ReportCode { get; }

        /// <summary>
        /// ��� ����� ������
        /// </summary>
        string ReportName { get; }

        /// <summary>
        /// ������ ��� ����� ������ (� ��������� ����)
        /// </summary>
        string ReportFullFileName { get; }

        /// <summary>
        /// �������� ��� ������ ��� ��������
        /// </summary>
        string ReportResultFileName { get; set; }

        /// <summary>
        /// ������������ ������ �����������
        /// </summary>
        string ConnectionString { get; }

        Dictionary<string, string> Parameters { get; set; }
    }
}