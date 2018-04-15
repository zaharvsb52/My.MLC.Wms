//using System;
//using FluentAssertions;
//using Microsoft.QualityTools.Testing.Fakes;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using MLC.Eps.Impl;

//namespace MLC.Eps.Tests
//{
//    [TestClass]
//    public class MacroProcessorTest
//    {
//        private const string MacroTestTextTemplate = "some text before {0} some text after";

//        [TestMethod]
//        public void When_source_is_empty_than_result_will_be_empty()
//        {
//            var processor = new MacroProcessor();
//            processor.Process("").Should().Be("");
//            processor.Process(null).Should().Be(null);
//        }

//        [TestMethod]
//        public void When_source_does_not_contains_any_macro_than_return_source()
//        {
//            var str = Guid.NewGuid().ToString();
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(str);
//        }

//        [TestMethod]
//        public void When_process_unknown_macro_than_value_stay_unchanging()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${UNKNOWN_CUSTOM_MACRO}");
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(str);
//        }

//        [TestMethod]
//        public void When_process_custom_macro_than_ok()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${CUSTOM_MACRO}");
//            var processor = new MacroProcessor();
//            processor.Add("CUSTOM_MACRO", "CUSTOM_MACRO_VALUE");
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, "CUSTOM_MACRO_VALUE"));
//        }

//        [TestMethod]
//        public void When_process_more_than_one_macro_all_will_be_applied()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${CUSTOM_MACRO1} ${CUSTOM_MACRO2}");
//            var processor = new MacroProcessor();
//            processor.Add("CUSTOM_MACRO1", "CUSTOM_MACRO_VALUE1");
//            processor.Add("CUSTOM_MACRO2", "CUSTOM_MACRO_VALUE2");
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, "CUSTOM_MACRO_VALUE1 CUSTOM_MACRO_VALUE2"));
//        }

//        [TestMethod]
//        public void When_process_date_with_ok_format_than_ok()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${DATE:ddMMyyyy_HHmmss}${DATE:ddMMyy_HHmm}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToString("ddMMyyyy_HHmmss") + staticDateTime.ToString("ddMMyy_HHmm")));
//            }
//        }


//        #region .  Known macroses  .
//        [TestMethod]
//        public void TestSYSUSERNAME()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${SYSUSERNAME}");
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, Environment.UserName));
//        }

//        [TestMethod]
//        public void TestSYSDOMAINNAME()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${SYSDOMAINNAME}");
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, Environment.UserDomainName));
//        }

//        [TestMethod]
//        public void TestSYSMACHINENAME()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${SYSMACHINENAME}");
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, Environment.MachineName));
//        }

//        [TestMethod]
//        public void TestNEWLINE()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${NEWLINE}");
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, Environment.NewLine));
//        }

//        [TestMethod]
//        public void TestDATE()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${DATE}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToShortDateString()));
//            }
//        }

//        [TestMethod]
//        public void TestLONGDATE()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${LONGDATE}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToLongDateString()));
//            }
//        }

//        [TestMethod]
//        public void TestTIME()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${TIME}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToShortTimeString()));
//            }
//        }

//        [TestMethod]
//        public void TestLONGTIME()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${LONGTIME}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToLongTimeString()));
//            }
//        }

//        [TestMethod]
//        public void TestPATHDATE()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${PATHDATE}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToShortDateString()));
//            }
//        }

//        [TestMethod]
//        public void TestPATHTIME()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${PATHTIME}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToShortTimeString().Replace(":", ".")));
//            }
//        }

//        [TestMethod]
//        public void TestPATHLONGTIME()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${PATHLONGTIME}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToLongTimeString().Replace(":", ".")));
//            }
//        }

//        [TestMethod]
//        public void TestPATHDATETIME()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticDateTime = DateTime.Now;
//                ShimDateTime.NowGet = () => staticDateTime;

//                var str = string.Format(MacroTestTextTemplate, "${PATHDATETIME}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticDateTime.ToShortDateString() + "-" + staticDateTime.ToShortTimeString().Replace(":", ".")));
//            }
//        }

//        [TestMethod]
//        public void TestSYSCURRENTDIRECTORY()
//        {
//            var str = string.Format(MacroTestTextTemplate, "${SYSCURRENTDIRECTORY}");
//            var processor = new MacroProcessor();
//            processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, Environment.CurrentDirectory));
//        }

//        [TestMethod, Ignore]
//        public void TestLISTGLOBALMACROSES()
//        {
//            //TODO
//        }

//        [TestMethod]
//        public void TestGUID()
//        {
//            using (ShimsContext.Create())
//            {
//                var staticGuid = Guid.NewGuid();
//                ShimGuid.NewGuid = () => staticGuid;

//                var str = string.Format(MacroTestTextTemplate, "${GUID}");
//                var processor = new MacroProcessor();
//                processor.Process(str).Should().Be(string.Format(MacroTestTextTemplate, staticGuid.ToString("N")));
//            }
//        }
//        #endregion
//    }
//}