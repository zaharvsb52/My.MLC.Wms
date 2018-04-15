using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using MLC.Wms.Workflows.Wf_Data;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    internal class GetOrderShippedTest : BaseIntegrationWorkflowTest
    {
        private static string _checkDate;
        private static string _queueInId;

        public GetOrderShippedTest()
        {
            InArgumentWorkflow = new GET_ORDER_SHIPPED();
        }

        [Test]
        public void ContentTest()
        {
            ExecuteWorkflowTest(GetType(), "GetQueueIn", "CheckMethod");
        }

        public static IoQueueIn GetQueueIn(ISession session)
        {
            var queueMessageTypeCode = "GET_ORDER_SHIPPED";
            var eventDetail = session.Query<wmsEventDetailOWB>()
                .Where(i => i.EventHeader.EventKind.EventKindCode == "OWB_COMPLETED" &&
                            i.EventHeader.Status.StatusCode == "EVENT_CREATED"
                )
                .OrderByDescending(d => d.DateIns)
                .FirstOrDefault();

            eventDetail.Should().NotBeNull("Нет данных для теста");

            var firstHeader = eventDetail.EventHeader;
            var date = firstHeader.DateIns.Value.Date.ToString("dd.MM.yyyy");
            _checkDate = date;
            _queueInId = Guid.NewGuid().ToString();

            return new IoQueueIn
            {
                Mandant = firstHeader.Partner,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == queueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                ProcessCode = _queueInId,
                Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage
                {
                    CommandList = new List<Command>
                    {
                        new Command {Name = "SHIPPED_DATE", Value = date}
                    }
                })
            };
        }

        public static void CheckMethod(ISession session)
        {
            session.Flush();
            var queueIn = session.Query<IoQueueIn>().FirstOrDefault(q => q.ProcessCode == _queueInId);
            queueIn.Should().NotBeNull();

            var queueOut =
                session.Query<IoQueueOut>()
                    .Where(q => q.QueueIn.ID == queueIn.ID && q.QueueMessageState == QueueMessageStates.Ready && q.QueueMessageType.Code == "ORDER_SHIPPED")
                    .OrderByDescending(q => q.DateIns)
                    .FirstOrDefault();

            queueOut.Should().NotBeNull();
            queueOut.Data.Should().NotBeNull();

            var outMessage = SerializationHelper.Deserialize<WHSOWBCommandMessage>(queueOut.Data);

            outMessage.Should().NotBeNull();
            outMessage.OWBList.Should().NotBeNullOrEmpty();

            var commandList = outMessage.OWBList.FirstOrDefault().CommandList;

            commandList.Should().NotBeNullOrEmpty();

            var command = commandList.FirstOrDefault();

            command.Should().NotBeNull();
            command.Name.ShouldBeEquivalentTo("FactShipmentDate");
            command.Value.ShouldBeEquivalentTo(_checkDate);
        }
    }
}