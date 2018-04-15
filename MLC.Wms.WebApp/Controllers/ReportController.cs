using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;
using FastReport.Data;
using FastReport.Export.Pdf;
using FastReport.Web;
using MLC.Eps.Config;
using Newtonsoft.Json;

namespace MLC.Wms.WebApp.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        public const string ReportPathSettingsName = "REPORTS_PATH";
        public const string EpsApiUrlSettingsName = "EpsApiUrl";

        public ActionResult Preview()
        {
            var config = GetEpsConfig();
            var report = GetReport(config);
            ViewBag.WebReport = report;
            return View();
        }

        public ActionResult Print()
        {
            var report = GetReport(null);

            // строим отчет
            report.Report.Prepare();

            // сохраняем в нужном формате в поток
            var stream = new MemoryStream();
            report.Report.Export(new PDFExport(), stream);
            stream.Position = 0;
            // возвращаем результат в браузер
            return new FileStreamResult(stream, "application/pdf");
        }

        private WebReport GetReport(IEpsConfiguration config)
        {
            var report = new WebReport();
            var useodbc = FillParameters(report, config);
            ChangeConnectionStrings(report, config, useodbc);
            SetupReport(report);
            return report;
        }

        private bool FillParameters(WebReport report, IEpsConfiguration config)
        {
            var result = false;

            foreach (var param in Request.QueryString)
            {
                var name = param.ToString();
                var value = Request.QueryString[name];
                var upperName = name.ToUpper();
                switch (upperName)
                {
                    case "REPORTID":
                        LoadReport(report, value, config);
                        break;
                    case "REPORTFILE":
                        LoadReportByReportFile(report, value, config);
                        break;
                    case "USEODBC":
                        bool.TryParse(value, out result);
                        break;

                    default:
                        var p = new Parameter(upperName) { Value = value };
                        report.Report.Parameters.Add(p);
                        break;
                }
            }
            return result;
        }

        private static void ChangeConnectionStrings(WebReport report, IEpsConfiguration config, bool useodbc)
        {
            if (report.Report.Dictionary.Connections.Count == 0)
                return;

            string repConnection;
            if (config == null)
                repConnection = ConfigurationManager.ConnectionStrings["rep"].ConnectionString;
            else
                repConnection = useodbc ? config.OdbcConnectionString : config.OdacConnectionString;

            foreach (DataConnectionBase reportConnection in report.Report.Dictionary.Connections)
                reportConnection.ConnectionString = repConnection;
        }

        private static void SetupReport(WebReport report)
        {
            report.Width = 800;// Unit.Percentage(100);
            report.Height = 900;// Unit.Percentage(100);
            report.PdfFitWindow = true;
            //report.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            //report.PrintInBrowser = true;
            //report.PrintInPdf = true;
            //report.ShowExports = true;
            //report.ShowPrint = true;
            //report.SinglePage = true;
        }

        private static void LoadReport(WebReport report, string reportId, IEpsConfiguration config)
        {
            var fileName = string.Format("{0}.frx", reportId);
            LoadReportByReportFile(report, fileName, config);
        }

        private static void LoadReportByReportFile(WebReport report, string reportFile, IEpsConfiguration config)
        {
            var path = GetReportPath(config);
            var fullName = Path.Combine(path, reportFile);

            //ODAC
            if (!FastReport.Utils.RegisteredObjects.IsTypeRegistered(typeof(OracleDataConnection)))
                FastReport.Utils.RegisteredObjects.AddConnection(typeof(OracleDataConnection));

            report.Report.Load(fullName);
        }

        private static string GetReportPath(IEpsConfiguration config)
        {
            var path = config == null ? ConfigurationManager.AppSettings[ReportPathSettingsName] : config.ReportPath;
            if (string.IsNullOrEmpty(path))
                throw new ConfigurationErrorsException("Найстрока пути к отчетам не задана.");
            return path;
        }

        private static IEpsConfiguration GetEpsConfig()
        {
            var url = GetEpsApiUrl() + "getepsconfig";
            var httpClient = new HttpClient();
            var res = httpClient.PostAsync(new Uri(url), null).Result;
            res.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<EpsConfigSection>(res.Content.ReadAsStringAsync().Result);
            return result;
        }

        private static string GetEpsApiUrl()
        {
            string result = null;

            if (ConfigurationManager.AppSettings.Count != 0)
                result = ConfigurationManager.AppSettings.Get(EpsApiUrlSettingsName);

            if (string.IsNullOrEmpty(result))
                throw new Exception("Не определен адрес EPSAPI сервера.");

            return result;
        }
    }
}