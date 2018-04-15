using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml;
using MLC.Eps;
using MLC.Eps.Server;
using MLC.Wms.Model.Entities;
using Newtonsoft.Json;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        public const string EpsApiUrlSettingsName = "EpsApiUrl";

        /// <summary>
        /// Создание задания для EPS в БД.
        /// </summary>     
        public void CreateEpsJob(string jobCode, string executor, Dictionary<string, object> parameters)
        {
            Contract.Requires(!string.IsNullOrEmpty(jobCode));
            Contract.Requires(!string.IsNullOrEmpty(executor));

            using (var session = SessionFactory.OpenSession())
            {
                var job = session.Get<EpsJob>(jobCode);
                if (job == null)
                    throw new Exception(string.Format("Can't find job with code '{0}'.", jobCode));

                if (!job.JobHandler.HasValue)
                    throw new Exception(string.Format("Job '{0}' has no JobHandler. Please check job settings.", jobCode));

                if (job.JobLocked)
                    throw new Exception(string.Format("Eps job '{0}' is locked.", jobCode));

                // пытаемся применить быструю проверку необходимости запуска
                if (!EpsHelper.IsNeedToStart(job, session))
                    throw new Exception(
                        string.Format("Job '{0}' shouldn't be executed. Check return 0 rows.", jobCode));

                // дополняем задачу параметрами и разбиваем, если нужно
                var additionalParameters = EpsHelper.GetAddigionalParametersAndSplit(job, session);
                if (parameters != null && parameters.Count > 0)
                {
                    //Если сверху пришли параметры, применяем их к каждому элементу массива
                    if (additionalParameters == null)
                        additionalParameters = new List<Dictionary<string, object>>();
                    if (additionalParameters.Count > 0)
                    {
                        foreach (var par in additionalParameters)
                        {
                            foreach (var newpar in parameters)
                            {
                                par[newpar.Key] = newpar.Value;
                            }
                        }
                    }
                    else
                    {
                        additionalParameters.Add(parameters);
                    }
                }
                
                if (additionalParameters == null)
                {
                    EpsHelper.ProcessEpsJob(executor, job, session, null, null);
                }
                else
                {
                    if (additionalParameters.Count == 0)
                        throw new Exception(
                            string.Format("Job '{0}' shouldn't be executed. Split query return 0 rows.", jobCode));

                    foreach (var p in additionalParameters)
                    {
                        EpsHelper.ProcessEpsJob(executor, job, session, p, null);
                    }
                }
            }
        }

        /// <summary>
        /// Печать отчёта.
        /// </summary>
        public void PrintReport(string reportCode, string executor, Dictionary<string, object> parameters, int? timeoutms)
        {
            Contract.Requires(!string.IsNullOrEmpty(reportCode));
            Contract.Requires(!string.IsNullOrEmpty(executor));

            WmsReport report;
            EpsPrinterLogical logicalPrinter;
            var reportCodeInternal = reportCode;
            var reportRedefinitionCopies = 1;
            int copies;

            using (var session = SessionFactory.OpenSession())
            {
                report = session.Get<WmsReport>(reportCode);
                if (report == null)
                    throw new Exception(string.Format("Не найден отчёт '{0}'.", reportCodeInternal));

                if (report.ReportFile_r == null)
                    throw new Exception(string.Format("Отсутствует файл отчёта у отчета '{0}'.", reportCodeInternal));

                //Определяем отчет
                var tlist = new List<string>
                {
                    CreateTparam("REPORT_R", report.ReportFile_r.ReportFileName),
                    CreateTparam("HOST_R", null),
                    CreateTparam("PARTNERID", null)
                };
                var reportRedefinition = GetDefaultReport(CreateTListParams(tlist));
                
                if (reportRedefinition != null && !reportRedefinition.ReportRedefinitionLocked &&
                    !string.IsNullOrEmpty(reportRedefinition.ReportRedefinition))
                {
                    reportCodeInternal = reportRedefinition.ReportRedefinition;
                    reportRedefinitionCopies = reportRedefinition.ReportRedefinitionCopies;

                    report = session.Get<WmsReport>(reportCodeInternal);
                    if (report == null)
                        throw new Exception(string.Format("Не найден отчёт '{0}' после переопределения.",
                            reportCodeInternal));
                }

                if (report.ReportLocked)
                    throw new Exception(string.Format("Отчёт '{0}' заблокирован.", reportCodeInternal));

                //Определяем принтер
                tlist = new List<string>
                {
                    CreateTparam("REPORT_R", report.Report),
                    CreateTparam("HOST_R", null),
                    CreateTparam("LOGIN_R", executor),
                    CreateTparam("MANDANTID", null),
                    CreateTparam("CHECKTIME", DateTime.Now.ToString(Converter.DefaultDateTimeStringFormat)),
                    CreateTparam("EVENTKINDCODE_R", null),
                    CreateTparam("FACTORYID_R", null)
                };
                var printStreamConfig = GetDefaultPrinter(CreateTListParams(tlist));
                if (printStreamConfig == null || printStreamConfig.PrintStreamLocked ||
                    printStreamConfig.LogicalPrinter_r == null)
                {
                    throw new Exception(string.Format("Не найден логический принтер для отчёта '{0}'.",
                        reportCodeInternal));
                }

                //Получаем логический принтер
                logicalPrinter = session.Get<EpsPrinterLogical>(printStreamConfig.LogicalPrinter_r.LogicalPrinter);
                if (logicalPrinter == null || logicalPrinter.LogicalPrinterLocked)
                {
                    throw new Exception(string.Format("Не найден логический принтер для отчёта '{0}'.",
                        reportCodeInternal));
                }

                if (logicalPrinter.PhysicalPrinter_r == null || logicalPrinter.PhysicalPrinter_r == null ||
                    logicalPrinter.PhysicalPrinter_r.PhysicalPrinterLocked)
                {
                    throw new Exception(string.Format("Не найден физический принтер для отчёта '{0}'.",
                        reportCodeInternal));
                }

                var printStreamConfigCopies = printStreamConfig.PrintStreamCopies;
                copies = report.ReportCopies*reportRedefinitionCopies*printStreamConfigCopies*
                    logicalPrinter.LogicalPrinterCopies;
            }

            //Формируем EpsOutput
            var output = new EpsOutput
            {
                Login_r = executor,
                ReportFileSubFolder_r = report.ReportFile_r.ReportFileSubFolder,
                Output_EpsOutputParam_List = new HashSet<EpsOutputParam>
                {
                    new EpsOutputParam
                    {
                        OutputParamCode = EpsTaskParameterTypes.EpsReport,
                        OutputParamValue = report.ReportFile_r.ReportFile,
                        OutputParamType = EpsParamTypes.REP
                    }
                }
            };

            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    output.Output_EpsOutputParam_List.Add(new EpsOutputParam
                    {
                        OutputParamCode = pair.Key,
                        OutputParamValue = Convert.ToString(pair.Value),
                        OutputParamSubValue = report.ReportFile_r.ReportFile,
                        OutputParamType = EpsParamTypes.REP
                    });
                }
            }

            output.Output_EpsOutputTask_List = new HashSet<EpsOutputTask>
            {
                new EpsOutputTask
                {
                    OutputTaskCode = EpsOutputTaskCodes.OTC_PRINT,
                    OutputTask_EpsOutputParam_List = new HashSet<EpsOutputParam>
                    {
                        new EpsOutputParam
                        {
                            OutputParamCode = EpsTaskParameterTypes.PhysicalPrinter,
                            OutputParamValue = logicalPrinter.PhysicalPrinter_r.PhysicalPrinter,
                            OutputParamType = EpsParamTypes.TSK
                        },
                        new EpsOutputParam
                        {
                            OutputParamCode = EpsTaskParameterTypes.Copies,
                            OutputParamValue = copies.ToString(),
                            OutputParamType = EpsParamTypes.TSK
                        }
                    }
                }
            };

            var context = SerializeEpsOutputToDto(new[] {output});
            if (string.IsNullOrEmpty(context))
                return;

            Post("print", context, timeoutms);
        }

        /// <summary>
        /// Создает задание для EPS и выполняет его.
        /// </summary>
        public void ExecuteEpsJob(string jobCode, string executor, Dictionary<string, object> parameters, int? timeoutms)
        {
            Contract.Requires(!string.IsNullOrEmpty(jobCode));
            Contract.Requires(!string.IsNullOrEmpty(executor));

            string context;
            using (var session = SessionFactory.OpenSession())
            {
                var job = session.Get<EpsJob>(jobCode);
                if (job == null)
                    throw new Exception(string.Format("Can't find job with code '{0}'.", jobCode));

                //if (!job.JobHandler.HasValue)
                //    throw new Exception(string.Format("Job '{0}' has no JobHandler. Please check job settings.", jobCode));

                if (job.JobLocked)
                    throw new Exception(string.Format("Eps job '{0}' is locked.", jobCode));

                // пытаемся применить быструю проверку необходимости запуска
                if (!EpsHelper.IsNeedToStart(job, session))
                    throw new Exception(
                        string.Format("Job '{0}' shouldn't be executed. Check return 0 rows.", jobCode));

                // дополняем задачу параметрами и разбиваем, если нужно
                var additionalParameters = EpsHelper.GetAddigionalParametersAndSplit(job, session);
                if (parameters != null && parameters.Count > 0)
                {
                    //Если сверху пришли параметры, применяем их к каждому элементу массива
                    if (additionalParameters == null)
                        additionalParameters = new List<Dictionary<string, object>>();
                    if (additionalParameters.Count > 0)
                    {
                        foreach (var par in additionalParameters)
                        {
                            foreach (var newpar in parameters)
                            {
                                par[newpar.Key] = newpar.Value;
                            }
                        }
                    }
                    else
                    {
                        additionalParameters.Add(parameters);
                    }
                }

                var outputlst = new List<EpsOutput>();
                if (additionalParameters == null)
                {
                    var output = EpsHelper.ProcessEpsJob(executor, job, session, null, null);
                    outputlst.Add(output);
                }
                else
                {
                    if (additionalParameters.Count == 0)
                        throw new Exception(
                            string.Format("Job '{0}' shouldn't be executed. Split query return 0 rows.", jobCode));

                    foreach (var p in additionalParameters)
                    {
                        var output = EpsHelper.ProcessEpsJob(executor, job, session, p, null);
                        outputlst.Add(output);
                    }
                }

                if (outputlst.Count == 0)
                    return;

                context = SerializeEpsOutputToDto(outputlst.ToArray());
            }

            if (string.IsNullOrEmpty(context))
                return;

            Post("print", context, timeoutms);
        }

        private string SerializeEpsOutputToDto(EpsOutput[] outputs)
        {
            if (outputs == null)
                return null;

            var dto = outputs.Select(p => new
            {
                p.OutputID,
                p.Login_r,
                p.Host_r,
                p.EpsHandler,
                p.ReportFileSubFolder_r,
                OutputStatus = OutputStatuses.OS_ON_TRANSFER.ToString(),
                Output_EpsOutputParam_List =
                    p.Output_EpsOutputParam_List == null
                        ? null
                        : p.Output_EpsOutputParam_List.Select(i => new
                        {
                            i.OutputParamID,
                            i.OutputParamCode,
                            i.OutputParamValue,
                            i.OutputParamSubValue,
                            OutputParamType = i.OutputParamType.ToString()
                        }).ToArray(),
                Output_EpsOutputTask_List =
                    p.Output_EpsOutputTask_List == null
                        ? null
                        : p.Output_EpsOutputTask_List.Select(i => new
                        {
                            i.OutputTaskID,
                            OutputTaskCode = i.OutputTaskCode.ToString(),
                            OutputTaskStatus = i.OutputTaskStatus.ToString(),
                            OutputTask_EpsOutputParam_List =
                                i.OutputTask_EpsOutputParam_List == null
                                    ? null
                                    : i.OutputTask_EpsOutputParam_List.Select(t => new
                                    {
                                        t.OutputParamID,
                                        t.OutputParamCode,
                                        t.OutputParamValue,
                                        t.OutputParamSubValue,
                                        OutputParamType = t.OutputParamType.ToString()
                                    }).ToArray()
                        }).ToArray()
            }).ToArray();

            var result = JsonConvert.SerializeObject(dto);
            return result;
        }

        private void Post(string action, string content, int? timeoutms)
        {
            var url = GetEpsApiUrl() + action;
            var httpClient = new HttpClient();
            if (timeoutms.HasValue)
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeoutms.Value);
            var contentPost = new StringContent(content, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(new Uri(url), contentPost).Result;
            result.EnsureSuccessStatusCode();
        }

        public EpsPrintStreamConfig GetDefaultPrinter(string tListParams)
        {
            string res;
            using (var session = SessionFactory.OpenSession())
            {
                res =
                    session.CreateSQLQuery(
                        string.Format("select pkgPrintStreamConfig.getDefaultPrinter({0}) as res from dual", tListParams))
                        .UniqueResult<string>();
            }

            if (string.IsNullOrEmpty(res))
                return null;

            var xmldoc = new XmlDocument {InnerXml = res};
            var result = new EpsPrintStreamConfig();
            foreach (XmlNode node in xmldoc.FirstChild.ChildNodes)
            {
                switch (node.Name)
                {
                    case "REPORT_R":
                        result.Report_r = new WmsReport {Report = node.InnerText};
                        break;
                    case "LOGIN_R":
                        result.Login_r = node.InnerText;
                        break;
                    case "LOGICALPRINTER_R":
                        result.LogicalPrinter_r = new EpsPrinterLogical {LogicalPrinter = node.InnerText};
                        break;
                    case "PRINTSTREAMCOPIES":
                        int intvalue;
                        if (int.TryParse(node.InnerText, out intvalue))
                            result.PrintStreamCopies = intvalue;
                        break;
                    case "PRINTSTREAMLOCKED":
                        bool locked;
                        if (bool.TryParse(node.InnerText, out locked))
                            result.PrintStreamLocked = locked;
                        break;
                    case "PRIORITY":
                        if (int.TryParse(node.InnerText, out intvalue))
                            result.Priority = intvalue;
                        break;
                }
            }

            return result;
        }

        public WmsReportRedefinition GetDefaultReport(string tListParams)
        {
            string res;
            using (var session = SessionFactory.OpenSession())
            {
                res =
                    session.CreateSQLQuery(
                        string.Format("select pkgReportRedefinition.getDefaultReport({0}) as res from dual", tListParams))
                        .UniqueResult<string>();
            }

            if (string.IsNullOrEmpty(res))
                return null;

            var xmldoc = new XmlDocument { InnerXml = res };
            var result = new WmsReportRedefinition();
            foreach (XmlNode node in xmldoc.FirstChild.ChildNodes)
            {
                switch (node.Name)
                {
                    case "REPORTREDEFINITIONID":
                        int intvalue;
                        if (int.TryParse(node.InnerText, out intvalue))
                            result.ReportRedefinitionID = intvalue;
                        break;
                    case "REPORT_R":
                        result.Report_r = node.InnerText;
                        break;
                    case "REPORTREDEFINITION":
                        result.ReportRedefinition = node.InnerText;
                        break;
                    case "REPORTREDEFINITIONCOPIES":
                        if (int.TryParse(node.InnerText, out intvalue))
                            result.ReportRedefinitionCopies = intvalue;
                        break;
                    case "REPORTREDEFINITIONLOCKED":
                        bool locked;
                        if (bool.TryParse(node.InnerText, out locked))
                            result.ReportRedefinitionLocked = locked;
                        break;
                }
            }

            return result;
        }

        private string CreateTparam(string propertyname, object value)
        {
            const string tparam = "TParam";
            return string.Format(tparam + "('{0}',{1},null)",
                propertyname,
                value is string ? string.Format("'{0}'", value) : value ?? "null");
        }

        private string CreateTListParams(IEnumerable<string> tlist)
        {
            return string.Format("TListParams({0})", string.Join(",", tlist));
        }

        private string GetEpsApiUrl()
        {
            string result = null;

            if (ConfigurationManager.AppSettings.Count != 0)
                result = ConfigurationManager.AppSettings.Get(EpsApiUrlSettingsName);

            if (string.IsNullOrEmpty(result))
                throw new Exception("Не определен адрес EPSAPI сервера.");

            return result;
        }

        //public IEpsConfiguration GetEpsConfig()
        //{
        //    var url = GetEpsApiUrl() + "getepsconfig";
        //    var httpClient = new HttpClient();
        //    var res = httpClient.PostAsync(new Uri(url), null).Result;
        //    res.EnsureSuccessStatusCode();

        //    var result = JsonConvert.DeserializeObject<EpsConfigSection>(res.Content.ReadAsStringAsync().Result);
        //    return result;
        //}
    }
}
