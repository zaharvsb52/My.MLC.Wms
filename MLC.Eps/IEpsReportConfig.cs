using System.Collections.Generic;

namespace MLC.Eps
{
    /// <summary>
    /// Конфигурация отчета
    /// </summary>
    public interface IEpsReportConfig
    {
        /// <summary>
        /// Код отчета
        /// </summary>
        string ReportCode { get; }

        /// <summary>
        /// Имя файла отчета
        /// </summary>
        string ReportName { get; }

        /// <summary>
        /// Полное имя файла отчета (с указанием пути)
        /// </summary>
        string ReportFullFileName { get; }

        /// <summary>
        /// Итоговое имя отчета для выгрузки
        /// </summary>
        string ReportResultFileName { get; set; }

        /// <summary>
        /// Используемая строка подключения
        /// </summary>
        string ConnectionString { get; }

        Dictionary<string, string> Parameters { get; set; }
    }
}