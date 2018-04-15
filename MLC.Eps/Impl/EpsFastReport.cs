//TODO: посмотреть можно ли вынести настройки FastReport в app.config (TempFolder, ...)

using System;
using System.Linq;
using FastReport;
using System.IO;
using MLC.Eps.ExportFormat;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    /// <summary>
    /// Функционал для работы с FastReport
    /// </summary>
    public class EpsFastReport : IEpsReport
    {
        #region .  Fields  .
        /// <summary>
        /// Отчет FastReport.
        /// </summary>
        private readonly Report _report;

        /// <summary>
        /// Список stream-ов и типов при разных экпортах.
        /// </summary>
        private readonly List<EpsReportExportContainer> _exportContainers;

        /// <summary>
        /// Список типов для экпортах.
        /// </summary>
        private readonly List<ExportType> _exportTypes;

        private readonly IEpsReportConfig _config;
        private readonly IReportExporterFactory _reportExporterFactory;
        #endregion

        #region .  Properties  .
        public string ReportName { get { return _config.ReportName; } }

        public string ReportResultFileName { get { return _config.ReportResultFileName; } }
        #endregion
/*
        public EpsFastReport(string reportName, string reportFileName, string connectionString, string tempFolder)
        {
            if (string.IsNullOrEmpty(reportName))
                throw new ArgumentNullException("reportName");

            if (string.IsNullOrEmpty(reportFileName))
                throw new ArgumentNullException("reportFileName");

            if (!(File.Exists(reportFileName)))
                throw new FileNotFoundException(reportFileName);

            if (string.IsNullOrEmpty(tempFolder))
                throw new ArgumentNullException("tempFolder");

            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);
            FastReport.Utils.Config.TempFolder = tempFolder;

            ReportName = reportName;
            ReportFileName = reportFileName;

            _report = new Report();
            _report.Load(reportFileName);

            if (!string.IsNullOrEmpty(connectionString))
            {
                for (var i = 0; i < _report.Dictionary.Connections.Count; i++)
                {
                    _report.Dictionary.Connections[i].ConnectionString = connectionString;
                }
            }

            _exportStreams = new List<EpsStreamType>();
            _exportTypes = new List<ExportType>();
        }
*/
        public EpsFastReport(IEpsReportConfig config,
            IEpsConfiguration epsConfiguration,
            IReportExporterFactory reportExporterFactory)
        {
            Contract.Requires(config != null);
            Contract.Requires(epsConfiguration != null);
            Contract.Requires(reportExporterFactory != null);

            _config = config;
            _reportExporterFactory = reportExporterFactory;
            _exportContainers = new List<EpsReportExportContainer>();
            _exportTypes = new List<ExportType>();

            CheckConfig(config, epsConfiguration);

            // создаем временную папку (если еще нет)
            if (!Directory.Exists(epsConfiguration.TmpPath))
                Directory.CreateDirectory(epsConfiguration.TmpPath);

            // настраиваем FastReport
            if (!string.Equals(FastReport.Utils.Config.TempFolder, epsConfiguration.TmpPath))
                FastReport.Utils.Config.TempFolder = epsConfiguration.TmpPath;

            // убираем окно прогресса
            FastReport.Utils.Config.ReportSettings.ShowProgress = false;

            //ODAC
            if (!FastReport.Utils.RegisteredObjects.IsTypeRegistered(typeof (FastReport.Data.OracleDataConnection)))
                FastReport.Utils.RegisteredObjects.AddConnection(typeof (FastReport.Data.OracleDataConnection));

            // создаем отчет
            _report = new Report();
            _report.Load(config.ReportFullFileName);

            //CheckReport(_report);

            for (var i = 0; i < _report.Dictionary.Connections.Count; i++)
                _report.Dictionary.Connections[i].ConnectionString = config.ConnectionString;
        }

        #region .  Methods  .
        private static void CheckConfig(IEpsReportConfig config, IEpsConfiguration epsConfiguration)
        {
            if (string.IsNullOrEmpty(config.ReportName))
                throw new Exception("ReportName for is not set.");

            if (string.IsNullOrEmpty(config.ReportFullFileName))
                throw new Exception($"ReportFileName for report {config.ReportName} is not set.");

            if (!File.Exists(config.ReportFullFileName))
                throw new FileNotFoundException(config.ReportFullFileName);

            if (string.IsNullOrEmpty(config.ConnectionString))
                throw new Exception($"ConnectionString for report {config.ReportName} is not set.");

            if (string.IsNullOrEmpty(epsConfiguration.TmpPath))
                throw new Exception("Ошибка конфигурации EPS. Не задан путь хренения временных файлов TMP.");
        }

        //private void CheckReport(Report report)
        //{
        //    if (report.Dictionary.Connections.Count == 0)
        //        throw new Exception(string.Format("Report {0} have no any connection string.", report.Name));
        //}

        /// <summary>
        /// Добавление параметра в отчет report.
        /// </summary>
        /// <param name="nameParameter">имя параметра</param>
        /// <param name="value">значение параметра</param>
        public void AddParameters(string nameParameter, object value)
        {
            Contract.Requires(nameParameter != null);

            _report.SetParameterValue(nameParameter, value);
        }

        /// <summary>
        /// Формирование отчета.
        /// </summary>
        public void Prepare()
        {
            _report.Prepare();
        }

        /// <summary>
        /// Добавление типов для экпорта.
        /// </summary>
        public void AddExportType(ExportType exportType)
        {
            Contract.Requires(exportType != null);

            if (_exportTypes.Any(t => t.GetKey().Equals(exportType.GetKey())))
                return;

            _exportTypes.Add(exportType);
        }

        private EpsReportExportContainer ExportReportTo(ExportType format)
        {
            using (var export = _reportExporterFactory.CreateExporter(format.Format))
            using (var stream = new MemoryStream())
            {
                if (export.SupportsEncoding)
                    export.SetEncoding(format.Encoding);

                if (export.SupportsSpacelife)
                    export.SetSpacelife(format.Spacelife);

                export.Export(_report, stream);

                return new EpsReportExportContainer(format.GetKey(), stream.ToArray(), export.FileExtension);
            }
        }

        /// <summary>
        /// Добавление stream-ов по типам для экпорта.
        /// </summary>
        public void Export()
        {
            _exportContainers.Clear();

            foreach (var type in _exportTypes)
                _exportContainers.Add(ExportReportTo(type));
        }

        /// <summary>
        /// Получение массива данных по имени типа экспорта отчета.
        /// </summary>
        /// <param name="exportType"></param>
        /// <returns>массив данных</returns>
        public EpsReportExportContainer GetExportContainer(ExportType exportType)
        {
            Contract.Requires(exportType != null);

            return _exportContainers.FirstOrDefault(i => i.TypeName == exportType.GetKey());
        }

        /// <summary>
        /// Печать отчета.
        /// </summary>
        /// <param name="physicalPrinter">имя принтера</param>
        /// <param name="copies">количество копий</param>
        public virtual void Print(string physicalPrinter, int copies)
        {
            Contract.Requires(physicalPrinter != null);
            Contract.Requires(copies > 0);

            _report.PrintSettings.ShowDialog = false;
            _report.PrintSettings.Copies = copies;
            _report.PrintSettings.Printer = physicalPrinter;
            _report.ReportInfo.Name = DateTime.Now.ToLongTimeString() + ":" + _report.FileName;
            _report.PrintPrepared();
        }

        public void Dispose()
        {
            if (_report != null)
                _report.Dispose();

            if (_exportTypes != null)
                _exportTypes.Clear();

            if (_exportContainers != null)
                _exportContainers.Clear();
        }
        #endregion
    }
}