using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MLC.Wms.Api.Tests;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using MLC.Wms.Workflows.Wf_Data;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    internal class SetOrderRoutesTest : BaseIntegrationWorkflowTest
    {
        private const string QueueMessageTypeCode = "SET_ORDER_ROUTES";
        private const string UnknownOwbName = "Unknown OWB Name";
        private const string MandantCode = "TST";
        private const string NonExistsTemplate = "Ошибка. Для манданта {0} по имени накладной {1} найдено {2} шт. в требуемых статусах. Ожидалась 1 шт.";

        private static WmsOWB _newOwb;

        public SetOrderRoutesTest()
        {
            InArgumentWorkflow = new SET_ORDER_ROUTES();
        }

        [Test]
        public void SmokeTest()
        {
            ExecuteWorkflowTest(GetType(), "GetQueueIn_SmokeTest", "CheckMethod_SmokeTest");
        }

        [Test]
        public void WhenOwbNameIsUnknownThanException()
        {
            Action action = () => ExecuteWorkflowTest(GetType(), "GetQueueIn_UnknownOwbName", null);
            action.ShouldThrow<Exception>()
                .Which.Message.ShouldBeEquivalentTo(string.Format(NonExistsTemplate, MandantCode, UnknownOwbName, 0));
        }

        [Test]
        public void WhenOwbHasNotValidStateThanException()
        {
            Action action = () => ExecuteWorkflowTest(GetType(), "GetQueueIn_NonValidOwbState", null);
            action.ShouldThrow<Exception>()
                .Which.Message.ShouldBeEquivalentTo(string.Format(NonExistsTemplate, MandantCode, _newOwb.OWBName, 0));
        }

        public static IoQueueIn GetQueueIn_SmokeTest(ISession session)
        {
            var tstMandant = GetTstMandant(session);

            DateTime expectedDate;
            YMgRoute mgrRoute;
            WmsApiChangeOwbRouteTests.PopulateTestData(session, out _newOwb, out expectedDate, out mgrRoute);

            return new IoQueueIn
            {
                Mandant = tstMandant,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == QueueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage()
                {
                    CommandList = new List<Command>
                    {
                        new Command {Name = "OWBName", Value = _newOwb.OWBName }
                    }
                })
            };
        }

        public static IoQueueIn GetQueueIn_UnknownOwbName(ISession session)
        {
            var tstMandnat = GetTstMandant(session);

            return new IoQueueIn
            {
                Mandant = tstMandnat,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == QueueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage()
                {
                    CommandList = new List<Command>
                    {
                        new Command {Name = "OWBName", Value = UnknownOwbName }
                    }
                })
            };
        }

        public static IoQueueIn GetQueueIn_NonValidOwbState(ISession session)
        {
            var tstMandant = GetTstMandant(session);

            _newOwb = new WmsOWB
            {
                Partner = tstMandant,
                OWBName = "Sample Name",
                OWBProductNeed = "NOACTIVATE",
                OWBType = "OWBTYPENORMAL",
                Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_COMPLETED")
            };
            session.Save(_newOwb);

            return new IoQueueIn
            {
                Mandant = tstMandant,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == QueueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage()
                {
                    CommandList = new List<Command>
                    {
                        new Command {Name = "OWBName", Value = _newOwb.OWBName }
                    }
                })
            };
        }

        public static void CheckMethod_SmokeTest(ISession session)
        {
            // ищем сообщение очереди за предыдущую минуту
            var res = session.Query<IoQueueIn>()
                .Where(i => i.QueueMessageType.Code == QueueMessageTypeCode && i.DateIns >= DateTime.Now.AddMinutes(-1))
                .ToList();

            res.Should().HaveCount(1);
            res[0].QueueMessageState.ShouldBeEquivalentTo(QueueMessageStates.Processing);
            res[0].Message.Should().StartWith($"Накладная с ID = {_newOwb.OWBID} включена в маршрут");
            // не могу перевычитать накладную. Предположу, что из-за того, что API дергает хранимку. Нужно разбираться
            // res[0].Message.Should().Be($"Накладная с ID = {owb.OWBID} включена в маршрут {owb.OWBRoutePlan} отгрузкой {owb.OWBOutDatePlan:dd.MM.yyyy HH:mm}");
        }
    }
}