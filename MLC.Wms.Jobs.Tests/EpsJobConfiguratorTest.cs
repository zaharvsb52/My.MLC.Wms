using System;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLC.Eps;
using MLC.Eps.Config;
using MLC.Eps.Impl;
using MLC.Eps.Server;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Linq.Fakes;

namespace MLC.Wms.Jobs.Tests
{
    [TestClass]
    public class EpsJobConfiguratorTest
    {
        private class EpsConfiguration : IEpsConfiguration
        {
            public string OdbcConnectionString { get; set; }
            public string OdacConnectionString { get; set; }
            public string ReportPath { get; set; }
            public string ArchPath { get; set; }
            public string TmpPath { get; set; }
        }

        [TestMethod, ExpectedException(typeof(Exception), "Output with id -100 has empty Login_r field.")]
        public void When_Output_login_r_field_is_empty_than_error()
        {
            var epsConfig = GetEpsConfiguration();
            var configurator = new EpsJobConfigurator(epsConfig, new MacroProcessor());

            var output = new EpsOutput
            {
                OutputID = -100,
                OutputStatus = OutputStatuses.OS_ON_TRANSFER,
                EpsHandler = 100,
                Login_r = null, //"test_user_login",
            };

            var session = new Mock<ISession>();

            configurator.Configure(output, session.Object, (i, exception, arg3) => { });
        }

        [TestMethod, ExpectedException(typeof(Exception), "For output task with id -101 set more then one FileFormat. Please, check the settings.")]
        public void When_outputtask_has_more_than_one_export_parameter_than_error()
        {
            var epsConfig = GetEpsConfiguration();
            var configurator = new EpsJobConfigurator(epsConfig, new MacroProcessor());

            var output = new EpsOutput
            {
                OutputID = -100,
                OutputStatus = OutputStatuses.OS_ON_TRANSFER,
                EpsHandler = 100,
                Login_r = "test_user_login"
            };

            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.EPS,
                OutputParamCode = EpsTaskParameterTypes.Zip,
                OutputParamValue = "1"
            });
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.EPS,
                OutputParamCode = EpsTaskParameterTypes.ReserveCopy,
                OutputParamValue = "1"
            });

            var emailTask = new EpsOutputTask
            {
                OutputTaskID = -101,
                OutputTaskCode = EpsOutputTaskCodes.OTC_MAIL,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW,
            };

            emailTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam()
            {
                OutputParamType = EpsParamTypes.TSK,
                OutputParamCode = EpsTaskParameterTypes.FileFormat,
                OutputParamValue = "test1"
            });
            emailTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam()
            {
                OutputParamType = EpsParamTypes.TSK,
                OutputParamCode = EpsTaskParameterTypes.FileFormat,
                OutputParamValue = "test2"
            });
            output.Output_EpsOutputTask_List.Add(emailTask);

            var session = new Mock<ISession>();
            var resultConfig = configurator.Configure(output, session.Object, (i, exception, arg3) => { });
        }

        [TestMethod, ExpectedException(typeof(Exception), "For output task with id -101 set empty FileFormat. Please, check the settings.")]
        public void When_outputtask_has_empty_export_parameter_than_error()
        {
            var epsConfig = GetEpsConfiguration();
            var configurator = new EpsJobConfigurator(epsConfig, new MacroProcessor());

            var output = new EpsOutput
            {
                OutputID = -100,
                OutputStatus = OutputStatuses.OS_ON_TRANSFER,
                EpsHandler = 100,
                Login_r = "test_user_login"
            };

            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.EPS,
                OutputParamCode = EpsTaskParameterTypes.Zip,
                OutputParamValue = "1"
            });
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.EPS,
                OutputParamCode = EpsTaskParameterTypes.ReserveCopy,
                OutputParamValue = "1"
            });

            var emailTask = new EpsOutputTask
            {
                OutputTaskID = -101,
                OutputTaskCode = EpsOutputTaskCodes.OTC_MAIL,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW,
            };

            emailTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam()
            {
                OutputParamType = EpsParamTypes.TSK,
                OutputParamCode = EpsTaskParameterTypes.FileFormat,
                OutputParamValue = ""
            });
            output.Output_EpsOutputTask_List.Add(emailTask);

            var session = new Mock<ISession>();
            var resultConfig = configurator.Configure(output, session.Object, (i, exception, arg3) => { });
        }

        [TestMethod, Ignore]
        public void When_outputtask_has_more_than_one_encoding_parameter_than_error()
        {
        }

        [TestMethod, Ignore]
        public void When_outputtask_has_empty_encoding_parameter_than_error()
        {
        }

        [TestMethod, Ignore]
        public void When_output_has_more_than_one_report_with_uniq_name_than_error()
        {
        }

        [TestMethod, Ignore]
        public void When_report_name_contain_sql_macro_than_macro_executed()
        {
        }

        [TestMethod]
        public void When_parameters_is_pased_than_its_recognized()
        {
            var epsConfig = GetEpsConfiguration();
            var configurator = new EpsJobConfigurator(epsConfig, new MacroProcessor());

            var output = new EpsOutput
            {
                OutputID = -100,
                OutputStatus = OutputStatuses.OS_ON_TRANSFER,
                EpsHandler = 100,
                Login_r = "test_user_login",
                ReportFileSubFolder_r = "TST"
            };

            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.EPS,
                OutputParamCode = EpsTaskParameterTypes.Zip,
                OutputParamValue = "1"
            });
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.EPS,
                OutputParamCode = EpsTaskParameterTypes.ReserveCopy,
                OutputParamValue = "1"
            });

            var emailTask = new EpsOutputTask
            {
                OutputTaskID = -101,
                OutputTaskCode = EpsOutputTaskCodes.OTC_MAIL,
                OutputTaskOrder = 1,
                OutputTaskStatus = OutputStatuses.OS_NEW,
            };
            output.Output_EpsOutputTask_List.Add(emailTask);

            emailTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.TSK,
                OutputParamCode = EpsTaskParameterTypes.FileFormat,
                OutputParamValue = "wmsMLC.EPS.wmsEPS.ExportTypes.FRExcel2007"
            });

            emailTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.TSK,
                OutputParamCode = EpsTaskParameterTypes.Conversion,
                OutputParamValue = "UTF-32"
            });

            emailTask.OutputTask_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.TSK,
                OutputParamCode = EpsTaskParameterTypes.Spacelife,
                OutputParamValue = "1"
            });

            var reportParam = new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.REP,
                OutputParamCode = EpsTaskParameterTypes.EpsReport,
                OutputParamValue = "Test001.frx"
            };
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.REP,
                OutputParamCode = "Parameter1",
                OutputParamValue = "value1",
                OutputParamSubValue = "Test001.frx"
            });
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.REP,
                OutputParamCode = "Parameter2",
                OutputParamValue = "value2",
                OutputParamSubValue = "Test001.frx"
            });
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.REP,
                OutputParamCode = EpsTaskParameterTypes.ResultReportFile,
                OutputParamValue = "${SQL=select REPORT_${SYSMACHINENAME}_${UserCode}_${DATE:yyyyMMdd}_${Parameter1}_${Parameter2}.txt from dual}",
                OutputParamSubValue = "Test001.frx"
            });
            output.Output_EpsOutputParam_List.Add(new EpsOutputParam
            {
                OutputParamType = EpsParamTypes.REP,
                OutputParamCode = EpsTaskParameterTypes.ChangeODBC,
                OutputParamValue = "1"
            });

            output.Output_EpsOutputParam_List.Add(reportParam);
            var resultReportName = string.Format("REPORT_{0}_{1}_{2:yyyyMMdd}_value1_value2.txt", Environment.MachineName, output.Login_r, DateTime.Now);

            var sqlQuery = new Mock<ISQLQuery>();
            sqlQuery.Setup(i => i.UniqueResult<string>()).Returns(resultReportName);

            var session = new Mock<ISession>();
            session.Setup(i => i.CreateSQLQuery(It.IsAny<string>())).Returns(sqlQuery.Object);
            var reportUseODACCpv = new WmsReportCPV
            {
                CPVValue = "1",
                CustomParam = new WmsCustomParam {CustomParamCode = WmsReportCPV.ReportUseODACParameter},
                REPORT = new WmsReport {Report = Path.GetFileNameWithoutExtension(reportParam.OutputParamValue)}
            };

            using (ShimsContext.Create())
            {
                ShimLinqExtensionMethods.QueryOf1ISession(s => new[] {reportUseODACCpv}.AsQueryable());

                var resultConfig = configurator.Configure(output, session.Object, (i, exception, arg3) => { });

                resultConfig.JobId.Should().Be(output.OutputID);
                resultConfig.Tasks.Should().HaveCount(1);
                resultConfig.Reports.Should().HaveCount(1);

                var resultEmailTask = resultConfig.Tasks.Single(i => i.TaskId == emailTask.OutputTaskID);
                ("OTC_" + resultEmailTask.TaskExecutorType).Should().Be(emailTask.OutputTaskCode.ToString());
                resultEmailTask.IsNeedZip.Should().BeTrue();
                resultEmailTask.IsNeedReserveCopy.Should().BeTrue();
                resultEmailTask.ExportType.Should().NotBeNull();
                resultEmailTask.ExportType.Encoding.Should().Be(Encoding.UTF32);
                resultEmailTask.ExportType.Spacelife.Should().BeTrue();
                resultEmailTask.ExportType.Format.Should().Be("wmsMLC.EPS.wmsEPS.ExportTypes.FRExcel2007");
                resultEmailTask.HandleTaskComplete.Should().NotBeNull();

                var resultReport = resultConfig.Reports.Single(i => i.ReportName == reportParam.OutputParamValue);
                resultReport.ReportCode.Should().Be(Path.GetFileNameWithoutExtension(reportParam.OutputParamValue));
                resultReport.ConnectionString.Should().Be(epsConfig.OdacConnectionString);
                resultReport.ReportFullFileName.Should().Be(Path.Combine(epsConfig.ReportPath, output.ReportFileSubFolder_r, reportParam.OutputParamValue));
                resultReport.Parameters.Should().Contain("Parameter1", "value1");
                resultReport.Parameters.Should().Contain("Parameter2", "value2");
                resultReport.Parameters.Should().Contain(EpsReportParameterTypes.UserCode, output.Login_r);
                resultReport.ReportResultFileName.Should().Be(resultReportName);
            }
        }

        private static EpsConfiguration GetEpsConfiguration()
        {
            return new EpsConfiguration
            {
                ArchPath = @".\Arch",
                ReportPath = @".\Reports",
                TmpPath = @".\Tmp",
                OdacConnectionString = "OdacConnectionString",
                OdbcConnectionString = "OdbcConnectionString"
            };
        }
    }
}