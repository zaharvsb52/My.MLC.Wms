using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FluentAssertions;
using Microsoft.Practices.Unity;
using MLC.Eps;
using MLC.Eps.Config;
using MLC.Eps.ExportFormat;
using MLC.Eps.ExportFormat.Impl;
using MLC.Eps.Impl;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Jobs.EPS;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NUnit.Framework;
using Quartz;

namespace MLC.Wms.Jobs.Tests
{
    /// <summary>
    /// Интеграционные тесты исполнения заданий Eps.
    /// </summary>
    [TestFixture]
    public class EpsJobOutputExecutorTest
    {
        #region .  Fields  .

        public const string AutoTestUser = "AUTOTEST";
        private IUnityContainer _container;
        private ISessionFactory _sessionFactory;

        private EpsTestReportFactory _testReportFactory;

        public class EpsTestReportFactory : EpsReportFactory
        {
            private readonly IEpsConfiguration _configuration;
            private readonly IReportExporterFactory _reportExporterFactory;

            public EpsTestReportFactory(IEpsConfiguration configuration, IReportExporterFactory reportExporterFactory)
                : base(configuration, reportExporterFactory)
            {
                _configuration = configuration;
                _reportExporterFactory = reportExporterFactory;

                Reports = new List<IEpsReport>();
            }

            public List<IEpsReport> Reports { get; private set; }

            public override IEpsReport CreateReport(IEpsReportConfig config)
            {
                var res = new EpsTestReport(config, _configuration, _reportExporterFactory);
                Reports.Add(res);
                return res;
            }

            public class EpsTestReport : EpsFastReport
            {
                public EpsTestReport(IEpsReportConfig config,
                    IEpsConfiguration epsConfiguration,
                    IReportExporterFactory reportExporterFactory)
                    : base(config, epsConfiguration, reportExporterFactory)
                {
                }

                public int Copies { get; set; }

                public string PhysicalPrinter { get; set; }

                public override void Print(string physicalPrinter, int copies)
                {
                    PhysicalPrinter = physicalPrinter;
                    Copies = copies;
                }
            }
        }

        #endregion

        [OneTimeSetUp]
        public void Setup()
        {
            try
            {
                UnityConfig.RegisterComponents(container =>
                {
                    var config = (EpsConfigSection) ConfigurationManager.GetSection(EpsConfigSection.DefaultSectionName);
                    var mockCfg = new Mock<IEpsConfiguration>();

                    mockCfg.Setup(i => i.ArchPath).Returns(Path.Combine(TestContext.CurrentContext.TestDirectory, config.ArchPath));
                    mockCfg.Setup(i => i.ReportPath).Returns(Path.Combine(TestContext.CurrentContext.TestDirectory, config.ReportPath));
                    mockCfg.Setup(i => i.TmpPath).Returns(Path.Combine(TestContext.CurrentContext.TestDirectory, config.TmpPath));
                    mockCfg.Setup(i => i.OdacConnectionString).Returns(config.OdacConnectionString);
                    mockCfg.Setup(i => i.OdbcConnectionString).Returns(config.OdbcConnectionString);
                    //config.ReportPath = TestContext.CurrentContext.TestDirectory;

                    // конфигурируем окружение
                    var envInfoProvider = new SvcWmsEnvironmentInfoProvider();
                    envInfoProvider.SetUserName(AutoTestUser);
                    WmsEnvironment.Init(envInfoProvider, null);

                    // регистрируем нужное
                    container.RegisterInstance<IEpsConfiguration>(mockCfg.Object);
                    container.RegisterInstance<IEpsMailConfig>(config.MailSettings);
                    container.RegisterType<IEpsJobFactory, EpsJobFactory>();
                    container.RegisterType<IEpsTaskFactory, EpsTaskFactory>();
                    //container.RegisterType<IEpsReportFactory, EpsReportFactory>();
                    container.RegisterType<IReportExporterFactory, ReportExporterFactory>();
                    container.RegisterType<IMacroProcessor, MacroProcessor>(new PerResolveLifetimeManager());

                    _testReportFactory = container.Resolve<EpsTestReportFactory>();
                    container.RegisterInstance<IEpsReportFactory>(_testReportFactory);


                    _sessionFactory = container.Resolve<ISessionFactory>();

                    _container = container;
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test]
        public void When_no_outputs_then_ok()
        {
            // запускаем
            var job = _container.Resolve<EpsJobOutputExecutor>();
            var jobDataMap = new JobDataMap
            {
                {"Handler", "100"},
                {"BatchSize", "2"}
            };

            var mockContext = new Mock<IJobExecutionContext>();
            mockContext.Setup(i => i.MergedJobDataMap).Returns(jobDataMap);
            job.Execute(mockContext.Object);
        }

        [Test]
        public void When_exists_mail_task_then_export_is_ok()
        {
            var epsOutput = GetEpsOutput();

            var emailTask = GetEpsMailTask(epsOutput);
            epsOutput.Output_EpsOutputTask_List.Add(emailTask);

            // пишем в DB
            SaveOutput(epsOutput);

            // запускаем
            var job = _container.Resolve<EpsJobOutputExecutor>();
            var jobDataMap = new JobDataMap
            {
                {"Handler", "-100"},
                {"BatchSize", "1"}
            };

            var mockContext = new Mock<IJobExecutionContext>();
            mockContext.Setup(i => i.MergedJobDataMap).Returns(jobDataMap);

            job.Execute(mockContext.Object);

            CheckOutput(epsOutput.OutputID, epsOutput.Output_EpsOutputTask_List.Count);
        }

        [Test]
        public void When_exists_share_task_then_export_is_ok()
        {
            var epsOutput = GetEpsOutput();

            var shareTask = GetEpsShareTask(epsOutput, @".\ARCH");
            epsOutput.Output_EpsOutputTask_List.Add(shareTask);

            // пишем в DB
            SaveOutput(epsOutput);

            // запускаем
            var job = _container.Resolve<EpsJobOutputExecutor>();
            var jobDataMap = new JobDataMap
            {
                {"Handler", "-100"},
                {"BatchSize", "1"}
            };

            var mockContext = new Mock<IJobExecutionContext>();
            mockContext.Setup(i => i.MergedJobDataMap).Returns(jobDataMap);

            job.Execute(mockContext.Object);

            CheckOutput(epsOutput.OutputID, epsOutput.Output_EpsOutputTask_List.Count);
        }

        [Test]
        public void When_exists_ftp_task_then_export_is_ok()
        {
            var epsOutput = GetEpsOutput();

            var ftpTask = GetEpsFtpTask(epsOutput, "/TEST/INBOUND/EPS");
            epsOutput.Output_EpsOutputTask_List.Add(ftpTask);

            // пишем в DB
            SaveOutput(epsOutput);

            // запускаем
            var job = _container.Resolve<EpsJobOutputExecutor>();
            var jobDataMap = new JobDataMap
            {
                {"Handler", "-100"},
                {"BatchSize", "1"}
            };

            var mockContext = new Mock<IJobExecutionContext>();
            mockContext.Setup(i => i.MergedJobDataMap).Returns(jobDataMap);
            job.Execute(mockContext.Object);

            CheckOutput(epsOutput.OutputID, epsOutput.Output_EpsOutputTask_List.Count);
        }

        [Test]
        public void When_exists_print_task_then_print_is_ok()
        {
            var epsOutput = GetEpsOutput();

            var printerName = "printer_123";
            var printTask = GetEpsPrintTask(epsOutput, printerName, 2);
            epsOutput.Output_EpsOutputTask_List.Add(printTask);

            // пишем в DB
            SaveOutput(epsOutput);

            // запускаем
            var job = _container.Resolve<EpsJobOutputExecutor>();
            var jobDataMap = new JobDataMap
            {
                {"Handler", "-100"},
                {"BatchSize", "1"}
            };

            var mockContext = new Mock<IJobExecutionContext>();
            mockContext.Setup(i => i.MergedJobDataMap).Returns(jobDataMap);

            _testReportFactory.Reports.Clear();

            job.Execute(mockContext.Object);

            _testReportFactory.Reports.Should().HaveCount(1);
            var resultReport = (EpsTestReportFactory.EpsTestReport) _testReportFactory.Reports[0];
            resultReport.Copies.Should().Be(2);
            resultReport.PhysicalPrinter.Should().Be(printerName);

            CheckOutput(epsOutput.OutputID, epsOutput.Output_EpsOutputTask_List.Count);
        }

        [Test]
        public void When_exists_more_than_one_task_then_export_is_ok()
        {
            var epsOutput = GetEpsOutput();

            var emailTask = GetEpsMailTask(epsOutput);
            epsOutput.Output_EpsOutputTask_List.Add(emailTask);

            var shareTask = GetEpsShareTask(epsOutput, @".\ARCH");
            epsOutput.Output_EpsOutputTask_List.Add(shareTask);

            var ftpTask = GetEpsFtpTask(epsOutput, "/TEST/INBOUND/EPS");
            epsOutput.Output_EpsOutputTask_List.Add(ftpTask);

//            var archTask = GetEpsFtpTask(epsOutput, "/TEST/INBOUND/EPS/AUTO_ARCH");
//            epsOutput.Output_EpsOutputTask_List.Add(archTask);

            // пишем в DB
            SaveOutput(epsOutput);

            // запускаем
            var job = _container.Resolve<EpsJobOutputExecutor>();
            var jobDataMap = new JobDataMap
            {
                {"Handler", "-100"},
                {"BatchSize", "1"}
            };

            var mockContext = new Mock<IJobExecutionContext>();
            mockContext.Setup(i => i.MergedJobDataMap).Returns(jobDataMap);
            job.Execute(mockContext.Object);

            CheckOutput(epsOutput.OutputID, epsOutput.Output_EpsOutputTask_List.Count);
        }

        #region .  Helpers  .

        private void CheckOutput(int epsOutputId, int taskCount)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var epsOutput = session.Get<EpsOutput>(epsOutputId);
                epsOutput.OutputStatus.Should().Be(OutputStatuses.OS_COMPLETED, "ERROR: " + epsOutput.OutputFeedback);
                epsOutput.Output_EpsOutputTask_List.Should().HaveCount(taskCount);
                foreach (var resultTask in epsOutput.Output_EpsOutputTask_List)
                    resultTask.OutputTaskStatus.Should().Be(OutputStatuses.OS_COMPLETED);
            }
        }

        private EpsOutput GetEpsOutput()
        {
            var res = new EpsOutput
            {
                EpsHandler = -100,
                Host_r = Environment.MachineName,
                OutputStatus = OutputStatuses.OS_NEW,
                Login_r = AutoTestUser
            };
            res.Output_EpsOutputParam_List = new Quartz.Collection.HashSet<EpsOutputParam>
            {
                new EpsOutputParam
                {
                    Output = res,
                    OutputParamType = EpsParamTypes.REP,
                    OutputParamCode = EpsTaskParameterTypes.EpsReport,
                    OutputParamValue = "Test001.frx"
                },
                new EpsOutputParam
                {
                    Output = res,
                    OutputParamType = EpsParamTypes.REP,
                    OutputParamCode = "Parameter1",
                    OutputParamValue = "test0011",
                    OutputParamSubValue = "Test001.frx"
                },
                new EpsOutputParam
                {
                    Output = res,
                    OutputParamType = EpsParamTypes.REP,
                    OutputParamCode = "Parameter2",
                    OutputParamValue = "test0012",
                    OutputParamSubValue = "Test001.frx"
                },
                new EpsOutputParam
                {
                    Output = res,
                    OutputParamType = EpsParamTypes.REP,
                    OutputParamCode = EpsTaskParameterTypes.ResultReportFile,
                    OutputParamValue =
                        "${SQL=select 'REPORT_${SYSMACHINENAME}_${UserCode}_${DATE:yyyyMMdd}_${Parameter1}_${Parameter2}' from dual}",
                    OutputParamSubValue = "Test001.frx"
                }
            };

            return res;
        }

        private EpsOutputTask GetEpsFtpTask(EpsOutput epsOutput, string targetFolder,
            string exportFormat = "wmsMLC.EPS.wmsEPS.ExportTypes.FRExcel2007")
        {
            var task = new EpsOutputTask
            {
                Output = epsOutput,
                OutputTaskCode = EpsOutputTaskCodes.OTC_FTP,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW
            };
            task.OutputTask_EpsOutputParam_List = new Quartz.Collection.HashSet<EpsOutputParam>
            {
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.TargetFolder,
                    OutputParamValue = targetFolder
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.FTPServerName,
                    OutputParamValue = "10.0.0.19"
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.FTPServerLogin,
                    OutputParamValue = "ftp_tester"
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.FTPServerPassword,
                    OutputParamValue = "123"
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.FileFormat,
                    OutputParamValue = exportFormat
                }
            };
            return task;
        }

        private EpsOutputTask GetEpsShareTask(EpsOutput epsOutput, string targetFolder,
            string exportFormat = "wmsMLC.EPS.wmsEPS.ExportTypes.FRExcel2007")
        {
            var task = new EpsOutputTask
            {
                Output = epsOutput,
                OutputTaskCode = EpsOutputTaskCodes.OTC_SHARE,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW
            };
            task.OutputTask_EpsOutputParam_List = new Quartz.Collection.HashSet<EpsOutputParam>
            {
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.TargetFolder,
                    OutputParamValue = targetFolder
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.FileFormat,
                    OutputParamValue = exportFormat
                }
            };
            return task;
        }

        private EpsOutputTask GetEpsMailTask(EpsOutput epsOutput,
            string exportFormat = "wmsMLC.EPS.wmsEPS.ExportTypes.FRText")
        {
            var task = new EpsOutputTask
            {
                Output = epsOutput,
                OutputTaskCode = EpsOutputTaskCodes.OTC_MAIL,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW
            };
            task.OutputTask_EpsOutputParam_List = new Quartz.Collection.HashSet<EpsOutputParam>
            {
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.AsAttachment,
                    OutputParamValue = "1"
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.Email,
                    OutputParamValue = "my@my.ru"
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.FileFormat,
                    OutputParamValue = exportFormat
                }
            };
            return task;
        }

        private EpsOutputTask GetEpsPrintTask(EpsOutput epsOutput, string printerName = "some physical printer",
            int copies = 1)
        {
            var task = new EpsOutputTask
            {
                Output = epsOutput,
                OutputTaskCode = EpsOutputTaskCodes.OTC_PRINT,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW
            };
            task.OutputTask_EpsOutputParam_List = new Quartz.Collection.HashSet<EpsOutputParam>
            {
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.Copies,
                    OutputParamValue = copies.ToString()
                },
                new EpsOutputParam
                {
                    Output = epsOutput,
                    OutputTask = task,
                    OutputParamCode = EpsTaskParameterTypes.PhysicalPrinter,
                    OutputParamValue = printerName
                }
            };
            return task;
        }

        private void SaveOutput(EpsOutput epsOutput)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(epsOutput);
                foreach (var epsOutputTask in epsOutput.Output_EpsOutputTask_List)
                {
                    session.Save(epsOutputTask);
                    foreach (var taskParam in epsOutputTask.OutputTask_EpsOutputParam_List)
                        session.Save(taskParam);
                }
                foreach (var outputParam in epsOutput.Output_EpsOutputParam_List)
                    session.Save(outputParam);
                transaction.Commit();
            }
        }

        #endregion
    }
}