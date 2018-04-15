using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using log4net;
using MLC.Wms.Common.DataAccess;
using MLC.Wms.Common.Helpers;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Util;

namespace MLC.Eps.Server
{
    public static class EpsHelper
    {
        public const string CpvCheckSql = "EPSJOBCheckSQLL2";
        public const string CpvSplitSql = "EPSJOBSplitParamSQLL2";
        public const string EpsLogicalPrinter = "EpsLogicalPrinter";
        public const string CpvCheckRoot = "EPSJOBPrepareL1";

        /// <summary>
        /// Проверка необходимости запуска.
        /// </summary>
        public static bool IsNeedToStart(EpsJob job, ISession session)
        {
            if (job.CPV_List == null || !job.CPV_List.Any())
                return true;

            // ищем нужную CPV
            var checkCpv = job.CPV_List.FirstOrDefault(i => i.CustomParam.CustomParamCode == CpvCheckSql);
            if (checkCpv == null)
                return true;

            // достаем sql
            var sql = checkCpv.CPVValue;
            if (string.IsNullOrEmpty(sql))
                throw new Exception(
                    $"In job '{job.JobCode}' cpv '{checkCpv.CustomParam.CustomParamCode}' is empty. Please enter value or remove it.");

            // запускаем sql проверки
            var sqlReult = session.CreateSQLQuery(sql).List();

            // если ничего не вернулось - запускать не нужно
            return sqlReult.Any();
        }

        /// <summary>
        /// Дополнение задачи параметрами.
        /// </summary>
        public static IList<Dictionary<string, object>> GetAddigionalParametersAndSplit(EpsJob job, ISession session)
        {
            if (job.CPV_List == null || !job.CPV_List.Any())
                return null;

            // получаем CPV
            var checkCpv = job.CPV_List.FirstOrDefault(i => i.CustomParam.CustomParamCode == CpvSplitSql);
            if (checkCpv == null)
                return null;

            // достаем sql
            var sql = checkCpv.CPVValue;
            if (string.IsNullOrEmpty(sql))
                throw new Exception(
                    string.Format("In job '{0}' cpv '{1}' is empty. Please enter value or remove it.", job.JobCode,
                        checkCpv.CPVValue));

            // запускаем sql получения параметров и разделения
            return session
                .CreateSQLQuery(sql)
                .SetResultTransformer(new DictionaryResultTransformer())
                .List<Dictionary<string, object>>();
        }

        /// <summary>
        /// Создание задания EPS.
        /// </summary>
        public static EpsOutput ProcessEpsJob(string executor, EpsJob job, ISession session,
            Dictionary<string, object> additionalParameters, ILog log)
        {
            // получаем параметры самого задания
            List<WmsReport> reports;
            var parameters = ProcessEpsConfigParams(job, additionalParameters, session, log, out reports);

            // получаем задачи
            var outputTasks = ProcessTaskParams(job, session, reports, log);

            //Формируем задание EPS
            var output = CreateEpsOutput(executor, job, outputTasks, reports, parameters, additionalParameters, log);
            return output;
        }

        /// <summary>
        /// Создание задачи.
        /// </summary>
        public static EpsOutput CreateEpsOutput(string executor, EpsJob job, IEnumerable<EpsOutputTask> outputTasks,
            IEnumerable<WmsReport> reports, IEnumerable<EpsOutputParam> parameters,
            Dictionary<string, object> additionalParameters, ILog log)
        {
            var output = new EpsOutput
            {
                Login_r = executor,
                Host_r = Environment.MachineName,
                OutputStatus = OutputStatuses.OS_NEW,
                EpsHandler = job.JobHandler ?? 20160614
            };

            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    p.Output = output;
                    output.Output_EpsOutputParam_List.Add(p);
                }
            }

            //TODO: тут нужно переделывать. если в задании 2 отчета из разных subfolder-ов, то в output попадет subfolder последнего
            if (reports != null && reports.Any())
            {
                var subFolders =
                    reports.Where(i => i.ReportFile_r != null)
                        .Select(i => i.ReportFile_r.ReportFileSubFolder)
                        .Distinct()
                        .ToArray();
                if (subFolders.Length > 1)
                    throw new Exception(
                        string.Format("Job '{0}' has more than one reports from different sub folders '{1}'.",
                            job.JobCode, string.Join("','", subFolders)));

                output.ReportFileSubFolder_r = subFolders[0];
            }

            // задачи
            if (outputTasks != null)
            {
                foreach (var outputTask in outputTasks)
                {
                    outputTask.Output = output;
                    output.Output_EpsOutputTask_List.Add(outputTask);

                    if (outputTask.OutputTask_EpsOutputParam_List == null)
                        continue;

                    foreach (var t in outputTask.OutputTask_EpsOutputParam_List)
                    {
                        t.Output = output;
                    }
                }
            }

            if (log != null)
                log.InfoFormat("Create new EpsOutput '{0}' from Executor '{1}'.", output.OutputID, executor);

            return output;
        }

        /// <summary>
        /// Сохранение задания EPS в БД.
        /// </summary>
        public static void SaveEpsOutput(EpsOutput output, ISession session)
        {
            //Сохраняем
            session.Save(output);
            if (output.Output_EpsOutputParam_List != null)
            {
                foreach (var p in output.Output_EpsOutputParam_List)
                {
                    p.Output = output;
                    session.Save(p);
                }
            }

            if (output.Output_EpsOutputTask_List != null)
            {
                foreach (var outputTask in output.Output_EpsOutputTask_List)
                {
                    outputTask.Output = output;
                    session.Save(outputTask);

                    if (outputTask.OutputTask_EpsOutputParam_List == null)
                        continue;

                    foreach (var t in outputTask.OutputTask_EpsOutputParam_List)
                    {
                        t.Output = output;
                        session.Save(t);
                    }
                }
            }
        }

        /// <summary>
        /// Параметры задания.
        /// </summary>
        private static IEnumerable<EpsOutputParam> ProcessEpsConfigParams(EpsJob job,
            Dictionary<string, object> additionalParameters, ISession session, ILog log, out List<WmsReport> reports)
        {
            var res = new List<EpsOutputParam>();
            reports = new List<WmsReport>();
            var uselog = log != null;

            if (job.CFG_List.Count == 0)
                return res;

            foreach (var jobConfig in job.CFG_List)
            {
                if (jobConfig.EpsConfigLocked)
                {
                    if (uselog)
                        log.DebugFormat("Job '{0}'. Parameter '{1}' (id={2}) is locked.", job.JobCode,
                            jobConfig.EpsConfigParamCode, jobConfig.EpsConfigID);
                    continue;
                }

                if (string.IsNullOrEmpty(jobConfig.EpsConfigParamCode))
                    throw new Exception(
                        string.Format("Job '{0}'. Рarameter '{1}' (id={2}) has empty ParamCode. Please check settings.",
                            job.JobCode, jobConfig.EpsConfigParamCode, jobConfig.EpsConfigID));

                switch (EnumHelper.ParseEnum(jobConfig.EpsConfigParamCode, EpsTaskParams.None))
                {
                    case EpsTaskParams.EpsReport:
                        var reportCode = jobConfig.EpsConfigValue;
                        if (string.IsNullOrEmpty(reportCode))
                            throw new Exception(
                                string.Format(
                                    "Job '{0}' has parameter '{1}' (id={2}; type={3}) with empty value. Please check settings.",
                                    job.JobCode, jobConfig.EpsConfigParamCode, jobConfig.EpsConfigID,
                                    jobConfig.EpsConfigParamCode));

                        // получаем отчет
                        var report = session.Get<WmsReport>(reportCode);
                        if (report == null)
                            throw new Exception(string.Format("Can't find report with code '{0}'.", reportCode));

                        if (report.ReportLocked)
                            throw new Exception(string.Format("Report '{0}' is Locked.", reportCode));

                        if (report.ReportFile_r == null)
                            throw new Exception(string.Format("Report '{0}' has empty ReportFile link.", reportCode));

                        reports.Add(report);

                        // добавляем отчет
                        res.Add(new EpsOutputParam
                        {
                            OutputParamCode = jobConfig.EpsConfigParamCode,
                            OutputParamValue = report.ReportFile_r.ReportFile,
                            OutputParamType = EpsParamTypes.REP
                        });

                        if (report.CFG_List.Count > 0)
                        {
                            foreach (var reportConfig in report.CFG_List)
                            {
                                if (reportConfig.EpsConfigLocked)
                                {
                                    if (uselog)
                                        log.DebugFormat("Report {0}. Parameter '{1}' (id={2}) is locked.", reportCode,
                                            reportConfig.EpsConfigParamCode, reportConfig.EpsConfigID);
                                    continue;
                                }

                                switch (EnumHelper.ParseEnum(reportConfig.EpsConfigParamCode, EpsTaskParams.None))
                                {
                                    case EpsTaskParams.ResultReportFile:
                                    case EpsTaskParams.ChangeODBC:
                                        break;

                                    case EpsTaskParams.None: //Variable
                                        if (string.IsNullOrEmpty(reportConfig.EpsConfigParamCode))
                                            continue;
                                        break;

                                    default:
                                        throw new Exception(
                                            string.Format("Report param '{0}' is not supported.",
                                                reportConfig.EpsConfigParamCode));
                                }

                                var name = reportConfig.EpsConfigParamCode;
                                if (!string.IsNullOrEmpty(name) && name[0] == '{' && name[name.Length - 1] == '}')
                                    name = name.Substring(1, name.Length - 2);

                                var val = reportConfig.EpsConfigValue;
                                // если передали строку, пытаемся из нее взять значение парметра
                                if (additionalParameters != null)
                                {
                                    var key = additionalParameters.Keys.SingleOrDefault(
                                        i => string.Equals(i, name, StringComparison.InvariantCultureIgnoreCase));
                                    if (!string.IsNullOrEmpty(key))
                                        val = additionalParameters[key] == null
                                            ? null
                                            : additionalParameters[key].ToString();
                                }

                                res.Add(new EpsOutputParam
                                {
                                    OutputParamCode = name,
                                    OutputParamValue = val,
                                    OutputParamSubValue = report.ReportFile_r.ReportFile,
                                    OutputParamType = EpsParamTypes.REP
                                });
                            }
                        }
                        break;

                    default:
                        res.Add(new EpsOutputParam
                        {
                            OutputParamCode = jobConfig.EpsConfigParamCode,
                            OutputParamValue = jobConfig.EpsConfigValue,
                            OutputParamType = EpsParamTypes.EPS
                        });
                        break;
                }
            }

            return res;
        }

        private static IEnumerable<EpsOutputTask> ProcessTaskParams(EpsJob job, ISession session,
            List<WmsReport> reports, ILog log)
        {
            var res = new List<EpsOutputTask>();
            if (job.Job_EpsTask2Job_List.Count == 0)
                return res;

            var uselog = log != null;

            foreach (var task2Job in job.Job_EpsTask2Job_List)
            {
                var task = task2Job.Task;

                if (task.TaskLocked)
                {
                    if (uselog)
                        log.DebugFormat("Task '{0}' is locked.", task.TaskCode);
                    continue;
                }

                if (task.TaskType == EpsTaskTypes.None)
                {
                    if (uselog)
                        log.Debug("Undefined EPS Task type.");
                    continue;
                }

                var outputTask = new EpsOutputTask
                {
                    OutputTaskCode =
                        (EpsOutputTaskCodes) Enum.Parse(typeof (EpsOutputTaskCodes), "OTC_" + task.TaskType),
                    OutputTaskOrder = task2Job.Task2JobOrder
                };

                // разбираем параметры
                if (task.CFG_List.Count > 0)
                {
                    EpsPrinterLogical printerLogical = null;

                    foreach (var configTsk in task.CFG_List)
                    {
                        if (configTsk.EpsConfigLocked)
                        {
                            if (uselog)
                                log.DebugFormat("Task {0}. Parameter '{1}' (id={2}) is locked.", task.TaskCode,
                                    configTsk.EpsConfigParamCode, configTsk.EpsConfigID);
                            continue;
                        }

                        if (string.IsNullOrEmpty(configTsk.EpsConfigParamCode))
                            throw new Exception(string.Format("Param code in task {0} (id={1}) is empty.",
                                configTsk.EpsConfigParamCode, configTsk.EpsConfigID));

                        EpsTaskParams param;
                        if (!Enum.TryParse(configTsk.EpsConfigParamCode, out param))
                            param = EpsTaskParams.None;

                        var epsConfigParamCode = configTsk.EpsConfigParamCode;
                        var epsConfigValue = configTsk.EpsConfigValue;

                        switch (param)
                        {
                            case EpsTaskParams.PhysicalPrinter:
                                continue;

                            case EpsTaskParams.None:
                                // из таких мы знаем только EpsLogicalPrinter
                                if (
                                    !string.Equals(configTsk.EpsConfigParamCode, EpsLogicalPrinter,
                                        StringComparison.InvariantCultureIgnoreCase))
                                    throw new Exception(string.Format("Unknown EpsConfigParamCode '{0}'.",
                                        configTsk.EpsConfigParamCode));

                                //Задан логический принтер
                                if (!string.IsNullOrEmpty(configTsk.EpsConfigValue))
                                {
                                    printerLogical = session.Get<EpsPrinterLogical>(configTsk.EpsConfigValue);
                                    if (printerLogical == null)
                                        throw new Exception(
                                            string.Format("Can't get PrinterLogical by key '{0}'.",
                                                configTsk.EpsConfigValue));

                                    //Проверяем физический принтер
                                    var printerPhysical = printerLogical.PhysicalPrinter_r;
                                    if (printerPhysical == null)
                                        throw new Exception(
                                            string.Format("Can't get PrinterPhysical by logical '{0}'.",
                                                printerLogical.LogicalPrinter));

                                    if (printerPhysical.PhysicalPrinterLocked)
                                        throw new Exception(
                                            string.Format("Physical printer '{0}' is locked.",
                                                printerPhysical.PhysicalPrinter));

                                    epsConfigParamCode = EpsTaskParams.PhysicalPrinter.ToString();
                                    epsConfigValue = printerLogical.PhysicalPrinter_r.PhysicalPrinter;
                                }
                                break;
                        }

                        outputTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam
                        {
                            OutputTask = outputTask,
                            OutputParamCode = epsConfigParamCode,
                            OutputParamValue = epsConfigValue,
                            OutputParamType = EpsParamTypes.TSK
                        });
                    }

                    //Проверяем наличие физ. принтера
                    if (task.TaskType == EpsTaskTypes.PRINT)
                    {
                        if (
                            outputTask.OutputTask_EpsOutputParam_List.All(
                                p =>
                                    EnumHelper.ParseEnum(p.OutputParamCode, EpsTaskParams.None) !=
                                    EpsTaskParams.PhysicalPrinter))
                            throw new Exception(string.Format(
                                "PhysicalPrinter parameter is not present for task '{0}'.", task.TaskCode));

                        //Добавляем copies для задачи Print
                        if (reports != null)
                        {
                            var copies =
                                outputTask.OutputTask_EpsOutputParam_List.Where(
                                    p =>
                                        EnumHelper.ParseEnum(p.OutputParamCode, EpsTaskParams.None) ==
                                        EpsTaskParams.Copies).ToArray();
                            if (copies.Length > 0) //Удаляем
                            {
                                foreach (var p in copies)
                                {
                                    session.Delete(p);
                                    outputTask.OutputTask_EpsOutputParam_List.Remove(p);
                                }

                                //Определяем новые copies с учетом отчета и принтера
                                //TODO: почему тут мы берем первую попапвшуюся запись?
                                int copy;
                                int.TryParse(copies[0].OutputParamValue, out copy);
                                foreach (var report in reports.Where(p => p.ReportFile_r != null))
                                {
                                    outputTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam
                                    {
                                        OutputTask = outputTask,
                                        OutputParamCode = EpsTaskParams.Copies.ToString(),
                                        OutputParamValue =
                                            (report.ReportCopies*copy*
                                             (printerLogical == null ? 0 : printerLogical.LogicalPrinterCopies))
                                                .ToString(CultureInfo.InvariantCulture),
                                        OutputParamSubValue = report.ReportFile_r.ReportFile,
                                        OutputParamType = EpsParamTypes.TSK
                                    });
                                }
                            }
                        }
                    }
                }

                res.Add(outputTask);
            }

            return res;
        }
    }
}