using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Entities;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using MLC.Wms.Workflows.Wf_Data;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Mapping;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    internal class ContentSetOrderReserveTest : BaseIntegrationWorkflowTest
    {
        const string OwbName = "Test_SetOrderReserve";

        public ContentSetOrderReserveTest()
        {
            InArgumentWorkflow = new SET_ORDER_RESERVE();
        }

        [Test]
        public void ContentTest()
        {
            ExecuteWorkflowTest(GetType(), "GetQueueIn", "CheckMethod");
        }

        public static IoQueueIn GetQueueIn(ISession session)
        {
            var partnerCode = "TST";
            var queueMessageTypeCode = "SET_ORDER_RESERVE";

            var partner = session.Query<WmsMandant>().Single(o => o.PartnerCode == partnerCode);

            var owb = new WmsOWB()
            {
                Partner = partner,
                OWBOwner = partner,
                OWBName = OwbName,
                OWBPriority = 1,
                Status = session.Query< WmsOWBStatus>().Single(i => i.StatusCode == "OWB_CREATED"),
                OWBProductNeed = "NOACTIVATE",
                OWBType = "OWBTYPENORMAL"
            };
            session.Save(owb);

            return new IoQueueIn
            {
                Mandant = partner,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == queueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage()
                {
                    CommandList = new List<Command>()
                    {
                        new Command() {Name = "OWBName", Value = OwbName},
                        new Command() {Name = "OWBId", Value = owb.OWBID.ToString()}
                    }
                })
            };
        }

        public static void CheckMethod(ISession session)
        {
            var res = session.Query<WmsQRes>().Single(i => i.OWB.OWBName == OwbName);
            res.Should().NotBeNull("Не получили запись в очереди резервирвоания.");

            var owb = session.Query<WmsOWB>().Single(i => i.OWBName == OwbName);
            owb.Status.StatusCode.ShouldBeEquivalentTo("OWB_PROCESSING");
        }


        [Test]
        public void ContentErrorTest()
        {
            try
            {
                ExecuteWorkflowTest(GetType(), "GetErrorQueueIn", "CheckErrorMethod");
            }
            catch (Exception ex)
            {
                ex.Message.ShouldBeEquivalentTo("Накладная 'OWBNameError' не найдена");
            }
        }

        public static IoQueueIn GetErrorQueueIn(ISession session)
        {
            var partnerCode = "TST";
            var queueMessageTypeCode = "SET_ORDER_RESERVE";

            var partner = session.Query<WmsMandant>().Single(o => o.PartnerCode == partnerCode);

            return new IoQueueIn
            {
                Mandant = partner,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == queueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage()
                {
                    CommandList = new List<Command>()
                    {
                        new Command() {Name = "OWBName", Value = "OWBNameError"},
                    }
                })
            };
        }
    }
}