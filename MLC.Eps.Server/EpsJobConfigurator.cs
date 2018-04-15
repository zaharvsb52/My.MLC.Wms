using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using MLC.Eps.Config;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;

namespace MLC.Eps.Server
{
    /// <summary>
    /// Преобразует конфигурацию из БД (EpsOutput*) в настройки EPS.
    /// </summary>
    public class EpsJobConfigurator
    {
        public const string ResultReportFileNameMacro = "RESULTREPORTFILE";
        public const string UserNameMacro = "USERNAME";
        public const string SqlMacroSuf = "${SQL=";

        #region .  Const & Fields  .

        public static readonly Encoding DefaultFileEncoding = Encoding.UTF8;
        //public const string ReportNameMacro = "${REPORTNAME}";

        private readonly IMacroProcessor _baseMacroProcessor;

        #endregion

        #region .  Inner classes  .

        public class EpsJobConfig : IEpsJobConfig
        {
            public int JobId { get; set; }

            public IEpsTaskConfig[] Tasks { get; set; }

            public IEpsReportConfig[] Reports { get; set; }

            public EpsJobParameter[] Parameters { get; set; }
        }

        public class EpsTaskConfig : IEpsTaskConfig
        {
            public int TaskId { get; set; }

            public int TaskOrder { get; set; }

            public EpsTaskExecutorTypes TaskExecutorType { get; set; }

            public ExportType ExportType { get; set; }

            public EpsTaskParameter[] Parameters { get; set; }

            public bool IsNeedZip { get; set; }

            public bool IsNeedReserveCopy { get; set; }

            public Action<int, Exception, TimeSpan> HandleTaskComplete { get; set; }
        }

        public class EpsReportConfig : IEpsReportConfig
        {
            public string ReportCode { get; set; }

            public string ReportName { get; set; }

            public string ReportFullFileName { get; set; }

            public string ReportResultFileName { get; set; }

            public string ConnectionString { get; set; }

            public Dictionary<string, string> Parameters { get; set; }
        }

        #endregion

        public EpsJobConfigurator(IEpsConfiguration epsConfiguration, IMacroProcessor macroProcessor)
        {
            Contract.Requires(epsConfiguration != null);
            Contract.Requires(macroProcessor != null);

            EpsConfig = epsConfiguration;
            _baseMacroProcessor = macroProcessor;
        }

        public IEpsConfiguration EpsConfig { get; private set; }

        #region .  Methods  .

        public IEpsJobConfig Configure(EpsOutput output, ISession session,
            Action<int, Exception, TimeSpan> taskCompleteAction)
        {
            Contract.Requires(output != null);
            Contract.Requires(session != null);
            Contract.Requires(taskCompleteAction != null);

            CheckOutput(output);

            // получаем отдельный инстанс макро-процессора
            var childMacroProcessor = _baseMacroProcessor.GetChildProcessor();

            // добавлем специализированный параметр макроса, который может быть использован далее
            childMacroProcessor.Add(UserNameMacro, output.Login_r);

            // добавляем обработчик для специального макроса SQL
            childMacroProcessor.Add("SQL", macroString => ProcessSqlMacro(macroString, session, null));

            var res = new EpsJobConfig
            {
                JobId = output.OutputID,
                Parameters = output
                    .Output_EpsOutputParam_List
                    .Where(i => i.OutputParamType == EpsParamTypes.EPS)
                    .Select(i => new EpsJobParameter
                    {
                        Code = i.OutputParamCode,
                        Value = childMacroProcessor.Process(i.OutputParamValue),
                        Subvalue = childMacroProcessor.Process(i.OutputParamSubValue)
                    })
                    .ToArray(),
                Reports = CreateReportConfigs(childMacroProcessor, output, session)
            };

            // добавлем специализированный параметр макроса, который может быть использован далее
            childMacroProcessor.Add(ResultReportFileNameMacro,
                string.Join(";",
                    res.Reports.Where(i => !string.IsNullOrEmpty(i.ReportResultFileName))
                        .Select(i => i.ReportResultFileName)));
            // конфигурируем задания
            res.Tasks = CreateTaskConfigs(childMacroProcessor, output, taskCompleteAction);

            return res;
        }

        private static string ProcessSqlMacro(string macroString, ISession session, EpsOutputParam[] reportParams)
        {
            try
            {
                // вычленяем запрос
                var sql = macroString.Replace(SqlMacroSuf, string.Empty);
                sql = sql.Substring(0, sql.Length - 1);

                if (reportParams != null)
                {
                    //Необходимо определить параметры типа {ABC...} для запроса, таким вот странным кодом
                    foreach (var param in reportParams)
                    {
                        var paramName = param.OutputParamCode[0] == '{'
                            ? param.OutputParamCode
                            : "{" + param.OutputParamCode + "}";
                        sql = sql.Replace(paramName, param.OutputParamValue);
                    }
                }

                var name = session.CreateSQLQuery(sql).UniqueResult<string>();
                return name.Replace("'", string.Empty);
            }
            catch (Exception ex)
            {
                var message = string.Format("Ошибка получения значения по макросу {0}. {1}", macroString, ex.Message);
                throw new Exception(message, ex);
            }
        }

        private static void CheckOutput(EpsOutput output)
        {
            if (string.IsNullOrEmpty(output.Login_r))
                throw new Exception(string.Format("Output with id {0} has empty Login_r field.", output.OutputID));
        }

        private static IEpsTaskConfig[] CreateTaskConfigs(IMacroProcessor macroProcessor, EpsOutput output,
            Action<int, Exception, TimeSpan> taskCompleteAction)
        {
            var jobParameters =
                output.Output_EpsOutputParam_List.Where(i => i.OutputParamType == EpsParamTypes.EPS).ToArray();

            //TODO: выяснить почему это праметры Job-а, а не Task-а
            var isNeedZip =
                jobParameters.Any(i => i.OutputParamCode == EpsTaskParameterTypes.Zip && Equals(i.OutputParamValue, "1"));
            var isNeedReserveCopy =
                jobParameters.Any(
                    i => i.OutputParamCode == EpsTaskParameterTypes.ReserveCopy && Equals(i.OutputParamValue, "1"));

            var res = new List<IEpsTaskConfig>();
            foreach (var task in output.Output_EpsOutputTask_List)
            {
//                var childMacroProcessor = _macroProcessor.GetChildProcessor();
//                foreach (var taskParam in task.OutputTask_EpsOutputParam_List.Where(i => !EpsTaskParameterTypes.IsKnownParameter(i.OutputParamCode)))
//                    childMacroProcessor.Add(taskParam.OutputParamCode, taskParam.OutputParamValue);
                var taskConfig = CreateTaskConfig(task, macroProcessor, isNeedZip, isNeedReserveCopy, taskCompleteAction);
                res.Add(taskConfig);
            }
            return res.ToArray();
        }

        private static IEpsTaskConfig CreateTaskConfig(EpsOutputTask task, IMacroProcessor macroProcessor,
            bool isNeedZip, bool isNeedReserveCopy, Action<int, Exception, TimeSpan> taskCompleteAction)
        {
            var res = new EpsTaskConfig();
            res.TaskId = task.OutputTaskID;
            res.TaskOrder = task.OutputTaskOrder;
            res.IsNeedZip = isNeedZip;
            res.IsNeedReserveCopy = isNeedReserveCopy;

            res.Parameters = task
                .OutputTask_EpsOutputParam_List
                .Select(i => new EpsTaskParameter
                {
                    Code = i.OutputParamCode,
                    Value = macroProcessor.Process(i.OutputParamValue),
                    Subvalue = macroProcessor.Process(i.OutputParamSubValue)
                })
                .ToArray();

            //Такое "кривое" преобразование, чтобы разделить функциональность в Eps и основной системы
            // По сути дублируем enum EpsTaskType
            var taskType = EpsTaskExecutorTypes.None;
            if (task.OutputTaskCode != EpsOutputTaskCodes.None)
                Enum.TryParse(task.OutputTaskCode.ToString().Substring(4), true, out taskType);
            res.TaskExecutorType = taskType;

            var exportFormats = res.Parameters
                .Where(i => i.Code == EpsTaskParameterTypes.FileFormat)
                .Select(p => p.Value)
                .Cast<string>()
                .ToArray();

            //больше не должно быть форматов
            if (exportFormats.Length > 1)
                throw new Exception(
                    string.Format(
                        "For output task with id {0} set more then one FileFormat. Please, check the settings.",
                        task.OutputTaskID));

            if (exportFormats.Length == 1)
            {
                var exportFormat = exportFormats[0];
                if (string.IsNullOrEmpty(exportFormat))
                    throw new Exception(
                        string.Format("For output task with id {0} set empty FileFormat. Please, check the settings.",
                            task.OutputTaskID));

                var encodingNames = res.Parameters
                    .Where(i => i.Code == EpsTaskParameterTypes.Conversion)
                    .Select(p => p.Value)
                    .Cast<string>()
                    .ToArray();

                if (encodingNames.Length > 1)
                    throw new Exception(
                        string.Format(
                            "For output task with id {0} set more then one Conversion parameter. Please, check the settings.",
                            task.OutputTaskID));

                var encoding = DefaultFileEncoding;
                if (encodingNames.Length == 1)
                {
                    if (string.IsNullOrEmpty(encodingNames[0]))
                        throw new Exception(
                            string.Format(
                                "For output task with id {0} set empty Conversion. Please, check the settings.",
                                task.OutputTaskID));

                    encoding = Encoding.GetEncoding(encodingNames[0]);
                }

                var spacelife = res.Parameters
                    .Any(i => i.Code == EpsTaskParameterTypes.Spacelife && string.Equals(i.Value, "1"));

                res.ExportType = new ExportType {Encoding = encoding, Format = exportFormat, Spacelife = spacelife};
            }

            res.HandleTaskComplete = taskCompleteAction;

            return res;
        }

        private IEpsReportConfig[] CreateReportConfigs(IMacroProcessor macroProcessor, EpsOutput output,
            ISession session)
        {
            var reportParams =
                output.Output_EpsOutputParam_List.Where(i => i.OutputParamType == EpsParamTypes.REP).ToArray();
            var reports = reportParams.Where(i => i.OutputParamCode == EpsTaskParameterTypes.EpsReport).ToArray();
            var res = new List<IEpsReportConfig>();
            foreach (var report in reports)
            {
                var reportName = report.OutputParamValue;
                // проверяем не задали ли один отчет несколько раз
                if (res.Any(i => i.ReportName == reportName))
                    throw new Exception(
                        string.Format(
                            "Report {0} in output {1} was configured more than once. Please, check the settings.",
                            report.OutputParamValue, output.OutputID));

                // вычленяем параметры
                var currentReportParams = reportParams.Where(i => i.OutputParamSubValue == reportName).ToArray();

                // заполняем макросы
                var childMacroProcessor = macroProcessor.GetChildProcessor();
                foreach (
                    var taskParam in
                        currentReportParams.Where(i => !EpsTaskParameterTypes.IsKnownParameter(i.OutputParamCode)))
                    childMacroProcessor.Add(taskParam.OutputParamCode, taskParam.OutputParamValue);
                // безусловно добавляем пользователя
                childMacroProcessor.Add(EpsReportParameterTypes.UserCode, output.Login_r);

                var reportConfig = CreateReportConfig(output, childMacroProcessor, report, currentReportParams, session);
                res.Add(reportConfig);
            }
            return res.ToArray();
        }

        private IEpsReportConfig CreateReportConfig(EpsOutput output, IMacroProcessor macroProcessor,
            EpsOutputParam report, EpsOutputParam[] reportParams, ISession session)
        {
            var res = new EpsReportConfig();

            // добавляем параметры этого отчета
            res.Parameters = reportParams
                .Where(p => !EpsTaskParameterTypes.IsKnownParameter(p.OutputParamCode))
                .ToDictionary(i => i.OutputParamCode, i => macroProcessor.Process(i.OutputParamValue));
            // добавляем в отчет обязательный параметр UserCode
            res.Parameters.Add(EpsReportParameterTypes.UserCode, output.Login_r);

            // определяем имя файла отчета (оно же subvalue для параметров)
            res.ReportName = macroProcessor.Process(report.OutputParamValue);
            if (string.IsNullOrEmpty(res.ReportName))
                throw new Exception(string.Format("Empty report file name in output {0}. Check the settings.",
                    output.OutputID));

            //TODO: Нужно бы переделать алгоритм определения кода отчета. Фиг знает почему так.
            res.ReportCode = Path.GetFileNameWithoutExtension(res.ReportName);

            macroProcessor.AddOrReplace("SQL", macroString => ProcessSqlMacro(macroString, session, reportParams));

            //определяем имя выгрузки отчета (итоговое имя)
            var resultReportFile = GetParamValue(reportParams, macroProcessor, EpsTaskParameterTypes.ResultReportFile,
                res.ReportName);

            // если ничего не задано - то берем имя файла отчета
            // иначе вычисляем результируещее имя с учетом макросов
            res.ReportResultFileName = IsNullOrEmptyAfterTrim(resultReportFile)
                ? res.ReportName
                : resultReportFile;
            //    : ProcessReportFileName(session, resultReportFile, reportParams);

            //получаем параметр типа EpsTaskParams.ChangeODBC. 0 - строку переопределять (переопределяет все подключения в отчете), 1 - строку не переопределять.
            var changeOdbcStr = GetParamValue(reportParams, macroProcessor, EpsTaskParameterTypes.ChangeODBC,
                res.ReportName);

            res.ConnectionString = changeOdbcStr == "1" ? null : EpsConfig.OdbcConnectionString;

            //получим пользовательский параметр ReportUseODAC
            //var wmsReport = session.Get<WmsReport>(res.ReportCode);
            //var reportUseOdac = wmsReport.CPV_List.FirstOrDefault(i => i.CustomParam.CustomParamCode == WmsReportCPV.ReportUseODACParameter);
            //TODO: исправить на вариант выше (когда Виталик починит метаданные)
            var reportUseOdac = session
                .Query<WmsReportCPV>()
                .Any(
                    i =>
                        i.CustomParam.CustomParamCode == WmsReportCPV.ReportUseODACParameter &&
                        i.REPORT.Report == res.ReportCode && i.CPVValue == "1");

            //параметр ReportUseODAC в приоритете
            if (reportUseOdac)
                res.ConnectionString = EpsConfig.OdacConnectionString;

            //вычисляем полное имя к файлу отчета
            res.ReportFullFileName = (output.ReportFileSubFolder_r != null)
                ? Path.Combine(EpsConfig.ReportPath, output.ReportFileSubFolder_r, res.ReportName)
                : Path.Combine(EpsConfig.ReportPath, res.ReportName);

            return res;
        }

//        private static string ProcessReportFileName(ISession session, string resultReportFile, IEnumerable<EpsOutputParam> parameters)
//        {
//            if (string.IsNullOrEmpty(resultReportFile))
//                return resultReportFile;

//            if (!resultReportFile.StartsWith(SqlMacroSuf))
//                return resultReportFile;

//            try
//            {
//                // вычленяем запрос
//                var sql = resultReportFile.Replace(SqlMacroSuf, string.Empty);
//                sql = sql.Substring(0, sql.Length - 1);

////                foreach (var param in parameters)
////                {
////                    var paramName = param.OutputParamCode[0] == '{' ? param.OutputParamCode : "{" + param.OutputParamCode + "}";
////                    sql = sql.Replace(paramName, _macroProcessor.Process(param.OutputParamValue));
////                }

//                var name = session.CreateSQLQuery(sql).UniqueResult<string>();
//                if (string.IsNullOrEmpty(name))
//                    throw new Exception("Получена пуская строка.");

//                return name.Replace("'", string.Empty);

//                //                using (var mgr = IoC.Instance.Resolve<IBPProcessManager>())
//                //                {
//                //                    var table = mgr.ExecuteDataTable(sql);
//                //                    if (table == null || table.Rows.Count == 0)
//                //                        throw new DeveloperException("Вернулось 0 строк данных");
//                //
//                //                    if (table.Rows[0].IsNull(0))
//                //                        throw new DeveloperException("Вернулось пустое значение");
//                //
//                //                    var name = Convert.ToString(table.Rows[0][0], CultureInfo.InvariantCulture);
//                //                    if (string.IsNullOrEmpty(name))
//                //                        throw new DeveloperException("Вернулась пустая строка");
//                //
//                //                    // текст может быть в ковычках
//                //                    return name.Replace("'", "");
//                //                }
//            }
//            catch (Exception ex)
//            {
//                var message = string.Format("Ошибка получения имени файла по макросу {0}. {1}", resultReportFile,
//                    ex.Message);
//                throw new Exception(message, ex);
//            }
//        }

        private static string GetParamValue(EpsOutputParam[] reportParams, IMacroProcessor macroProcessor,
            string parameterCode, string parameterSubValue)
        {
            //1. Проверяем на заполнение поле Subvalue.
            var result = reportParams
                .Where(
                    p => p.OutputParamCode == parameterCode && string.Equals(p.OutputParamSubValue, parameterSubValue))
                .Select(p => p.OutputParamValue)
                .FirstOrDefault();

            if (IsNullOrEmptyAfterTrim(result))
            {
                //2. Если не нашли берем параметр, у которого поле Subvalue == null
                result = reportParams
                    .Where(p => p.OutputParamCode == parameterCode && p.OutputParamSubValue == null)
                    .Select(p => p.OutputParamValue)
                    .FirstOrDefault();
            }

            return macroProcessor.Process(result);
        }

        private static bool IsNullOrEmptyAfterTrim(string str)
        {
            return (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim()));
        }

        #endregion
    }
}