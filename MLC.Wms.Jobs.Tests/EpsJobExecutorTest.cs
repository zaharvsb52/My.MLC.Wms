using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MLC.Eps.Server;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Jobs.EPS;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Transform;
using NUnit.Framework;
using Quartz;

namespace MLC.Wms.Jobs.Tests
{
    [TestFixture]
    public class EpsJobExecutorTest
    {
        [OneTimeSetUp]
        public void Setup()
        {
            var envProvider = new SvcWmsEnvironmentInfoProvider();
            envProvider.SetUserName("TestUser");
            WmsEnvironment.Init(envProvider, new ThreadStaticLocalData());
        }

        [Test]
        public void When_job_handler_is_empty_than_expect_exception()
        {
            var epsJob = new EpsJob
            {
                JobCode = "10"
            };

            var action = GetExecuteAction(epsJob);
            action.ShouldThrow<JobExecutionException>()
                .And.Message.ShouldBeEquivalentTo(
                    string.Format("Job '{0}' has no JobHandler. Please check job settings.", epsJob.JobCode));
        }

        [Test]
        public void When_job_is_locked_than_expect_lock_exception()
        {
            var epsJob = new EpsJob
            {
                JobCode = "10",
                JobHandler = 100,
                JobLocked = true
            };

            var action = GetExecuteAction(epsJob);
            action.ShouldThrow<JobExecutionException>()
                .And.Message.ShouldBeEquivalentTo(string.Format("Eps job '{0}' is locked.", epsJob.JobCode));
        }

        [Test]
        public void When_job_has_cpv_with_check_filter_false_than_execution_will_interrupt()
        {
            var epsJob = new EpsJob
            {
                JobCode = "10",
                JobHandler = 100,
                JobLocked = false,
                CPV_List = new HashSet<EpsJobCPV>(new[]
                {
                    new EpsJobCPV() {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckRoot}},
                    new EpsJobCPV()
                    {
                        CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckSql},
                        CPVValue = "select 1 from dual where 1 = 0"
                    }
                })
            };

            var action = GetExecuteAction(epsJob, s =>
            {
                var sqlQuery = new Mock<ISQLQuery>();
                sqlQuery.Setup(i => i.List()).Returns(new List<object>());
                s.Setup(i => i.CreateSQLQuery("select 1 from dual where 1 = 0")).Returns(sqlQuery.Object);
            });

            action.ShouldThrow<JobExecutionException>(
                string.Format("Job '{0}' shouldn't be executed. Check return 0 rows.", epsJob.JobCode));
        }

        [Test]
        public void When_job_has_cpv_with_check_filter_and_cpvvalue_is_empty_than_expect_exception()
        {
            var epsJob = new EpsJob
            {
                JobCode = "10",
                JobHandler = 100,
                JobLocked = false,
                CPV_List = new HashSet<EpsJobCPV>(new[]
                {
                    new EpsJobCPV() {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckRoot}},
                    new EpsJobCPV() {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckSql}, CPVValue = null}
                })
            };

            var action = GetExecuteAction(epsJob, s =>
            {
                var sqlQuery = new Mock<ISQLQuery>();
                sqlQuery.Setup(i => i.List()).Returns(new List<object>());
                s.Setup(i => i.CreateSQLQuery("select 1 from dual where 1 = 0")).Returns(sqlQuery.Object);
            });

            action.ShouldThrow<Exception>(
                $"In job '{epsJob.JobCode}' cpv '{EpsHelper.CpvCheckSql}' is empty. Please enter value or remove it.");
        }

        [Test]
        public void When_job_has_cpv_with_split_query_and_cpvvalue_is_empty_than_expect_exception()
        {
            var epsJob = new EpsJob
            {
                JobCode = "10",
                JobHandler = 100,
                JobLocked = false,
                CPV_List = new HashSet<EpsJobCPV>(new[]
                {
                    new EpsJobCPV() {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckRoot}},
                    new EpsJobCPV()
                    {
                        CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckSql},
                        CPVValue = "select 1 from dual where 1 = 1"
                    },
                    new EpsJobCPV() {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvSplitSql}, CPVValue = null}
                })
            };

            var action = GetExecuteAction(epsJob, s =>
            {
                var sqlQuery = new Mock<ISQLQuery>();
                sqlQuery.Setup(i => i.List()).Returns(new[] {1});
                s.Setup(i => i.CreateSQLQuery("select 1 from dual where 1 = 1")).Returns(sqlQuery.Object);
            });

            action.ShouldThrow<JobExecutionException>(
                string.Format("In job '{0}' cpv '{1}' is empty. Please enter value or remove it.", epsJob.JobCode,
                    EpsHelper.CpvSplitSql));
        }

        [Test]
        public void When_job_has_cpv_with_split_query_returns_0_rows_job_will_be_interrupted()
        {
            var epsJob = new EpsJob
            {
                JobCode = "10",
                JobHandler = 100,
                JobLocked = false,
                CPV_List = new HashSet<EpsJobCPV>
                {
                    new EpsJobCPV {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckRoot}},
                    new EpsJobCPV
                    {
                        CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckSql},
                        CPVValue = "select 1 from dual where 1 = 1"
                    },
                    new EpsJobCPV()
                    {
                        CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvSplitSql},
                        CPVValue = "select 1 from dual where 1 = 0"
                    }
                }
            };

            var action = GetExecuteAction(epsJob, s =>
            {
                var sqlTrueQuery = new Mock<ISQLQuery>();
                sqlTrueQuery.Setup(i => i.List()).Returns(new[] {1});

                var sqlFalseQuery = new Mock<ISQLQuery>();
                sqlFalseQuery.Setup(i => i.List<Dictionary<string, object>>())
                    .Returns(new List<Dictionary<string, object>>());
                sqlFalseQuery.Setup(i => i.SetResultTransformer(It.IsAny<IResultTransformer>()))
                    .Returns(sqlFalseQuery.Object);

                s.Setup(i => i.CreateSQLQuery("select 1 from dual where 1 = 1")).Returns(sqlTrueQuery.Object);
                s.Setup(i => i.CreateSQLQuery("select 1 from dual where 1 = 0")).Returns(sqlFalseQuery.Object);
            });

            action.ShouldThrow<JobExecutionException>(
                string.Format("Job '{0}' shouldn't be executed. Split query return 0 rows.", epsJob.JobCode));
        }

        [Test]
        public void Execute_without_split_and_check_cpv()
        {
            #region prepare data

            // report
            var report = new WmsReport
            {
                EpsHandler = 100,
                Report = "AutoTestReport",
                ReportCopies = 2,
                ReportFile_r = new WmsReportFile
                {
                    ReportFile = "AutoTestReportFile.frx",
                    ReportFileName = "AutoTestReportFile",
                    ReportFileSubFolder = "AutoTests"
                }
            };
            var reportConstParam = new WmsReportCFG
            {
                REPORT = report,
                EpsConfigParamCode = "{AutoTestParam}",
                EpsConfigValue = "ConstantValue"
            };
            report.CFG_List = new HashSet<WmsReportCFG>
            {
                reportConstParam
            };

            // job
            var epsJob = new EpsJob
            {
                JobCode = "AutoTestJob",
                JobHandler = 100,
                JobLocked = false,
            };
            var epsConfigReport = new EpsJobCFG
            {
                JOB = epsJob,
                EpsConfigParamCode = "EpsReport",
                EpsConfigValue = report.Report
            };
            epsJob.CFG_List = new HashSet<EpsJobCFG>
            {
                epsConfigReport
            };
            //task
            var epsTask = new EpsTask
            {
                TaskCode = "AutoTestTask",
                TaskLocked = false,
                TaskType = EpsTaskTypes.MAIL,
                //TaskType = "MAIL",
            };
            var emailTaskParam = new EpsTaskCFG
            {
                TASK = epsTask,
                EpsConfigParamCode = "Email",
                EpsConfigValue = "testName@testDomain.test"
            };
            var fileFormatTaskParam = new EpsTaskCFG
            {
                TASK = epsTask,
                EpsConfigParamCode = "FileFormat",
                EpsConfigValue = "wmsMLC.EPS.wmsEPS.ExportTypes.FRPdf"
            };
            epsTask.CFG_List = new HashSet<EpsTaskCFG>
            {
                emailTaskParam,
                fileFormatTaskParam
            };

            //job2task
            epsJob.Job_EpsTask2Job_List = new HashSet<EpsTask2Job>
            {
                new EpsTask2Job
                {
                    Job = epsJob,
                    Task = epsTask,
                    Task2JobOrder = 1
                }
            };

            #endregion

            var results = new List<object>();

            var action = GetExecuteAction(epsJob, s =>
            {
                s.Setup(i => i.Get<WmsReport>(report.Report)).Returns(report);
                s.Setup(i => i.Save(It.IsAny<object>())).Callback(new Action<object>(o => results.Add(o)));
            });

            action();

            var outputs = results.OfType<EpsOutput>().ToArray();
            outputs.Should().HaveCount(1);
            var output = outputs[0];

            output.Login_r.Should().Be(WmsEnvironment.UserName);
            output.Host_r.Should().Be(Environment.MachineName);
            output.OutputStatus.Should().Be(OutputStatuses.OS_NEW);
            //output.OutputStatus.Should().Be("OS_NEW");
            output.EpsHandler.Should().Be(epsJob.JobHandler);

            output.Output_EpsOutputParam_List.Should().HaveCount(2);
            var outputReportParam = output.Output_EpsOutputParam_List.First(i => i.OutputParamCode == epsConfigReport.EpsConfigParamCode);
            outputReportParam.Output.Should().Be(output);
            outputReportParam.OutputTask.Should().BeNull();
            outputReportParam.OutputParamType.Should().Be(EpsParamTypes.REP);
            outputReportParam.OutputParamValue.Should().Be(report.ReportFile_r.ReportFile);

            var trueReportConstParamName = reportConstParam.EpsConfigParamCode.Replace("{", "").Replace("}", "");
            var constReportParam = output.Output_EpsOutputParam_List.First(i => i.OutputParamCode == trueReportConstParamName);
            constReportParam.Output.Should().Be(output);
            constReportParam.OutputTask.Should().BeNull();
            constReportParam.OutputParamType.Should().Be(EpsParamTypes.REP);
            constReportParam.OutputParamValue.Should().Be(reportConstParam.EpsConfigValue);

            // check task
            output.Output_EpsOutputTask_List.Should().HaveCount(1);
            var outputTask = output.Output_EpsOutputTask_List.First();
            outputTask.Output.Should().Be(output);
            //outputTask.OutputTaskCode.Should().Be("OTC_MAIL");
            outputTask.OutputTaskCode.Should().Be(EpsOutputTaskCodes.OTC_MAIL);
            outputTask.OutputTaskOrder.Should().Be(1);
            outputTask.OutputTaskStatus.Should().Be(OutputStatuses.OS_NEW);
            //outputTask.OutputTaskStatus.Should().Be("OS_NEW");

            outputTask.OutputTask_EpsOutputParam_List.Should().HaveCount(2);
            var outputTaskEmailParam = outputTask.OutputTask_EpsOutputParam_List.First(i => i.OutputParamCode == emailTaskParam.EpsConfigParamCode);
            outputTaskEmailParam.Output.Should().Be(output);
            outputTaskEmailParam.OutputTask.Should().Be(outputTask);
            outputTaskEmailParam.OutputParamType.Should().Be(EpsParamTypes.TSK);
            outputTaskEmailParam.OutputParamValue.Should().Be(emailTaskParam.EpsConfigValue);

            var outputTaskFileFormatParam = outputTask.OutputTask_EpsOutputParam_List.First(i => i.OutputParamCode == fileFormatTaskParam.EpsConfigParamCode);
            outputTaskFileFormatParam.Output.Should().Be(output);
            outputTaskFileFormatParam.OutputTask.Should().Be(outputTask);
            outputTaskFileFormatParam.OutputParamType.Should().Be(EpsParamTypes.TSK);
            outputTaskFileFormatParam.OutputParamValue.Should().Be(fileFormatTaskParam.EpsConfigValue);
        }

        [Test]
        public void Execute_without_check_cpv_and_with_split_cvp_that_returns_1_enrich_param()
        {
            #region prepare data

            // report
            var report = new WmsReport
            {
                EpsHandler = 100,
                Report = "AutoTestReport",
                ReportCopies = 2,
                ReportFile_r = new WmsReportFile
                {
                    ReportFile = "AutoTestReportFile.frx",
                    ReportFileName = "AutoTestReportFile",
                    ReportFileSubFolder = "AutoTests"
                }
            };
            var reportConstParam = new WmsReportCFG
            {
                REPORT = report,
                EpsConfigParamCode = "{AutoTestParam}",
                EpsConfigValue = "ConstantValue"
            };
            report.CFG_List = new HashSet<WmsReportCFG>
            {
                reportConstParam
            };

            // job
            var epsJob = new EpsJob
            {
                JobCode = "AutoTestJob",
                JobHandler = 100,
                JobLocked = false,
                CPV_List = new HashSet<EpsJobCPV>
                {
                    new EpsJobCPV {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckRoot}},
                    new EpsJobCPV
                    {
                        CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvSplitSql},
                        CPVValue = "select 'val' as AutoTestParam from dual where 1 = 1"
                    }
                }
            };
            var epsConfigReport = new EpsJobCFG
            {
                JOB = epsJob,
                EpsConfigParamCode = "EpsReport",
                EpsConfigValue = report.Report
            };
            epsJob.CFG_List = new HashSet<EpsJobCFG>
            {
                epsConfigReport
            };
            //task
            var epsTask = new EpsTask
            {
                TaskCode = "AutoTestTask",
                TaskLocked = false,
                TaskType = EpsTaskTypes.MAIL,
                //TaskType = "MAIL",
            };
            var emailTaskParam = new EpsTaskCFG
            {
                TASK = epsTask,
                EpsConfigParamCode = "Email",
                EpsConfigValue = "testName@testDomain.test"
            };
            var fileFormatTaskParam = new EpsTaskCFG
            {
                TASK = epsTask,
                EpsConfigParamCode = "FileFormat",
                EpsConfigValue = "wmsMLC.EPS.wmsEPS.ExportTypes.FRPdf"
            };
            epsTask.CFG_List = new HashSet<EpsTaskCFG>
            {
                emailTaskParam,
                fileFormatTaskParam
            };

            //job2task
            epsJob.Job_EpsTask2Job_List = new HashSet<EpsTask2Job>
            {
                new EpsTask2Job
                {
                    Job = epsJob,
                    Task = epsTask,
                    Task2JobOrder = 1
                }
            };

            #endregion

            var results = new List<object>();
            var action = GetExecuteAction(epsJob, s =>
            {
                s.Setup(i => i.Get<WmsReport>(report.Report)).Returns(report);
                s.Setup(i => i.Save(It.IsAny<object>())).Callback(new Action<object>(o => results.Add(o)));

                var sqlSplitQuery = new Mock<ISQLQuery>();
                sqlSplitQuery.Setup(i => i.List<Dictionary<string, object>>())
                    .Returns(new List<Dictionary<string, object>>
                    {
                        new Dictionary<string, object>()
                        {
                            {"AutoTestParam", "val"}
                        }
                    });
                sqlSplitQuery.Setup(i => i.SetResultTransformer(It.IsAny<IResultTransformer>()))
                    .Returns(sqlSplitQuery.Object);

                s.Setup(i => i.CreateSQLQuery("select 'val' as AutoTestParam from dual where 1 = 1")).Returns(sqlSplitQuery.Object);
            });

            action();

            var trueReportConstParamName = reportConstParam.EpsConfigParamCode.Replace("{", "").Replace("}", "");

            var outputs = results.OfType<EpsOutput>().ToArray();
            outputs.Should().HaveCount(1);
            outputs.Should()
                .Contain(i => i.Output_EpsOutputParam_List.Any(j =>
                    j.Output == i &&
                    j.OutputTask == null &&
                    j.OutputParamType == EpsParamTypes.REP &&
                    j.OutputParamCode == trueReportConstParamName &&
                    j.OutputParamValue == "val"));
        }

        [Test]
        public void Execute_without_check_cpv_and_with_split_cvp_that_returns_2_enrich_param()
        {
            #region prepare data

            // report
            var report = new WmsReport
            {
                EpsHandler = 100,
                Report = "AutoTestReport",
                ReportCopies = 2,
                ReportFile_r = new WmsReportFile
                {
                    ReportFile = "AutoTestReportFile.frx",
                    ReportFileName = "AutoTestReportFile",
                    ReportFileSubFolder = "AutoTests"
                }
            };
            var reportConstParam = new WmsReportCFG
            {
                REPORT = report,
                EpsConfigParamCode = "{AutoTestParam}",
                EpsConfigValue = "ConstantValue"
            };
            report.CFG_List = new HashSet<WmsReportCFG>
            {
                reportConstParam
            };

            // job
            var epsJob = new EpsJob
            {
                JobCode = "AutoTestJob",
                JobHandler = 100,
                JobLocked = false,
                CPV_List = new HashSet<EpsJobCPV>
                {
                    new EpsJobCPV {CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvCheckRoot}},
                    new EpsJobCPV
                    {
                        CustomParam = new WmsCustomParam {CustomParamCode = EpsHelper.CpvSplitSql},
                        CPVValue = "select 'val1' as AutoTestParam from dual where 1 = 1 union all select 'val2' from dual where 1 = 1"
                    }
                }
            };
            var epsConfigReport = new EpsJobCFG
            {
                JOB = epsJob,
                EpsConfigParamCode = "EpsReport",
                EpsConfigValue = report.Report
            };
            epsJob.CFG_List = new HashSet<EpsJobCFG>
            {
                epsConfigReport
            };
            //task
            var epsTask = new EpsTask
            {
                TaskCode = "AutoTestTask",
                TaskLocked = false,
                TaskType = EpsTaskTypes.MAIL,
                //TaskType = "MAIL",
            };
            var emailTaskParam = new EpsTaskCFG
            {
                TASK = epsTask,
                EpsConfigParamCode = "Email",
                EpsConfigValue = "testName@testDomain.test"
            };
            var fileFormatTaskParam = new EpsTaskCFG
            {
                TASK = epsTask,
                EpsConfigParamCode = "FileFormat",
                EpsConfigValue = "wmsMLC.EPS.wmsEPS.ExportTypes.FRPdf"
            };
            epsTask.CFG_List = new HashSet<EpsTaskCFG>
            {
                emailTaskParam,
                fileFormatTaskParam
            };

            //job2task
            epsJob.Job_EpsTask2Job_List = new HashSet<EpsTask2Job>
            {
                new EpsTask2Job
                {
                    Job = epsJob,
                    Task = epsTask,
                    Task2JobOrder = 1
                }
            };

            #endregion

            var results = new List<object>();
            var action = GetExecuteAction(epsJob, s =>
            {
                s.Setup(i => i.Get<WmsReport>(report.Report)).Returns(report);
                s.Setup(i => i.Save(It.IsAny<object>())).Callback(new Action<object>(o => results.Add(o)));

                var sqlSplitQuery = new Mock<ISQLQuery>();
                sqlSplitQuery.Setup(i => i.List<Dictionary<string, object>>())
                    .Returns(new List<Dictionary<string, object>>
                    {
                        new Dictionary<string, object>
                        {
                            {"AutoTestParam", "val1"}
                        },
                        new Dictionary<string, object>
                        {
                            {"AutoTestParam", "val2"}
                        }
                    });
                sqlSplitQuery.Setup(i => i.SetResultTransformer(It.IsAny<IResultTransformer>()))
                    .Returns(sqlSplitQuery.Object);

                s.Setup(i => i.CreateSQLQuery("select 'val1' as AutoTestParam from dual where 1 = 1 union all select 'val2' from dual where 1 = 1")).Returns(sqlSplitQuery.Object);
            });

            action();

            var trueReportConstParamName = reportConstParam.EpsConfigParamCode.Replace("{", "").Replace("}", "");

            var outputs = results.OfType<EpsOutput>().ToArray();
            outputs.Should().HaveCount(2);
            outputs.Should()
                .Contain(i => i.Output_EpsOutputParam_List.Any(j =>
                    j.Output == i &&
                    j.OutputTask == null &&
                    j.OutputParamType == EpsParamTypes.REP &&
                    j.OutputParamCode == trueReportConstParamName &&
                    j.OutputParamValue == "val1"));
            outputs.Should()
                .Contain(i => i.Output_EpsOutputParam_List.Any(j =>
                    j.Output == i &&
                    j.OutputTask == null &&
                    j.OutputParamType == EpsParamTypes.REP &&
                    j.OutputParamCode == trueReportConstParamName &&
                    j.OutputParamValue == "val2"));
        }

        private Action GetExecuteAction(EpsJob epsJob, Action<Mock<ISession>> sessionMockSetup = null)
        {
            var transaction = new Mock<ITransaction>();
            transaction.Setup(i => i.Commit());

            var session = new Mock<ISession>();
            session.Setup(i => i.BeginTransaction()).Returns(transaction.Object);
            session.Setup(i => i.Get<EpsJob>(epsJob.JobCode)).Returns(epsJob);
            if (sessionMockSetup != null)
                sessionMockSetup(session);

            var sessionFactory = new Mock<ISessionFactory>();
            sessionFactory.Setup(i => i.OpenSession()).Returns(session.Object);

            var job = new EpsJobExecutor(sessionFactory.Object);
            var executionContext = new Mock<IJobExecutionContext>();
            var data = new JobDataMap {{"EpsJobCode", epsJob.JobCode}};
            executionContext.SetupGet(i => i.MergedJobDataMap).Returns(data);

            return () => { job.Execute(executionContext.Object); };
        }
    }
}