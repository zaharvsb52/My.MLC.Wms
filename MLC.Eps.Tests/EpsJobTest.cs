using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MLC.Eps.Config;
using MLC.Eps.ExportFormat.Impl;
using MLC.Eps.Impl;
using Moq;
using NUnit.Framework;

namespace MLC.Eps.Tests
{
    [TestFixture]
    public class EpsJobTest
    {
        [Test, Ignore("Тест только для отладки")]
        public void SmokeTest()
        {
            var reportConfig = new TestEpsReportConfig()
            {
                ReportCode = "ReportCode",
                ConnectionString = "ConnectionString",
                ReportFullFileName = Path.Combine(TestContext.CurrentContext.TestDirectory, "TELabel.frx"),
                ReportName = "ReportName",
                ReportResultFileName = "ReportResultFileName"
            };

            var shareTaskConfig = new TestEpsTaskConfig
            {
                ExportType = new ExportType
                {
                    Format = "txt",
                    Encoding = Encoding.ASCII,
                    Spacelife = true
                },
                IsNeedReserveCopy = true,
                IsNeedZip = true,
                TaskId = 100500,
                TaskOrder = 1,
                TaskExecutorType = EpsTaskExecutorTypes.SHARE,
                HandleTaskComplete = (i, exception, arg3) => { }
            };

            var jobConfig = new TestEpsJobConfig
            {
                JobId = 42,
                Reports = new[] {reportConfig},
                Tasks = new[] {shareTaskConfig}
            };

            var epsConfig = new EpsConfiguration
            {
                ArchPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ArchPath"),
                ReportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ReportPath"),
                TmpPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "ReportPath"),
                OdacConnectionString = "OdacConnectionString",
                OdbcConnectionString = "OdbcConnectionString"
            };

            var archiver = new Archiver();

            var moqTaskFactory = new Mock<IEpsTaskFactory>();
            moqTaskFactory.Setup(i => i.CreateTask(shareTaskConfig))
                .Returns(new EpsTaskShareExport(shareTaskConfig, epsConfig, archiver));

            var moqReportFactory = new Mock<IEpsReportFactory>();
            moqReportFactory.Setup(i => i.CreateReport(reportConfig))
                .Returns(new EpsFastReport(reportConfig, epsConfig, new ReportExporterFactory()));

            using (var job = new EpsJob(jobConfig, epsConfig, moqTaskFactory.Object, moqReportFactory.Object))
                job.Execute();
        }

        public class EpsConfiguration : IEpsConfiguration
        {
            public string OdbcConnectionString { get; set; }
            public string OdacConnectionString { get; set; }
            public string ReportPath { get; set; }
            public string ArchPath { get; set; }
            public string TmpPath { get; set; }
        }

        public class TestEpsJobConfig : IEpsJobConfig
        {
            public int JobId { get; set; }
            public IEpsTaskConfig[] Tasks { get; set; }
            public IEpsReportConfig[] Reports { get; set; }
            public EpsJobParameter[] Parameters { get; set; }
        }

        public class TestEpsTaskConfig : IEpsTaskConfig
        {
            public int TaskId { get; set; }
            public int TaskOrder { get; set; }
            public EpsTaskExecutorTypes TaskExecutorType { get; set; }
            public EpsTaskParameter[] Parameters { get; set; }
            public ExportType ExportType { get; set; }
            public bool IsNeedZip { get; set; }
            public bool IsNeedReserveCopy { get; set; }
            public Action<int, Exception, TimeSpan> HandleTaskComplete { get; set; }
        }

        public class TestEpsReportConfig : IEpsReportConfig
        {
            public string ReportCode { get; set; }
            public string ReportName { get; set; }
            public string ReportFullFileName { get; set; }
            public string ReportResultFileName { get; set; }
            public string ConnectionString { get; set; }
            public Dictionary<string, string> Parameters { get; set; }
        }
    }
}