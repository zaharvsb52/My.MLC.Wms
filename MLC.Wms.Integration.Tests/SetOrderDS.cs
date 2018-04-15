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
    internal class SetOrderDS : BaseIntegrationWorkflowTest
    {
        private const string _partnerName = "TestPartnerSetOrderDS";
        private const string _mandantCode = "TST";
        private const string _owbName = "TestOwbSetOrderDS";

        public SetOrderDS()
        {
            InArgumentWorkflow = new SET_ORDER_DS();
        }

        [Test]
        public void ContentTest()
        {
            ExecuteWorkflowTest(GetType(), "GetQueueIn", "CheckMethod");
        }

        public static IoQueueIn GetQueueIn(ISession session)
        {
            const string queueMessageTypeCode = "SET_ORDER_DS";
            const string defaultName = "TestSetOrderDS";

            var mandant = session.Query<WmsMandant>().FirstOrDefault(o => o.PartnerCode == _mandantCode);
            if (mandant == null)
                throw new Exception(string.Format("Отсутствует тестовый мандант с кодом {0}", _mandantCode));

            //var arr = new[] { "OWB_NONE", "OWB_CANCELED", "OWB_COMPLETED" };
            var status = session.Query<WmsOWBStatus>().FirstOrDefault(o => o.StatusCode == "OWB_ACTIVATED");
            if (status == null)
                throw new Exception(string.Format("Отсутствует статус с кодом  OWB_COMPLETED"));

            var partner = new WmsPartner
            {
                PartnerLink2Mandant = mandant,
                PartnerName = _partnerName
            };
            session.SaveOrUpdate(partner);

            var owbTest = new WmsOWB
            {
                Partner = mandant,
                OWBName = _owbName,
                OWBType = "OWBTYPENORMAL",
                OWBProductNeed = "PRODUCTNEED",
                Status = status
            };
            session.SaveOrUpdate(owbTest);

            session.Flush();

            return new IoQueueIn
            {
                Mandant = mandant,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == queueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Ready,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new DSState()
                {
                    OWBName = _owbName,
                    PartnerOrder = defaultName,
                    DeliveryServiceRef = _partnerName,
                    CommandList = new List<Command>() { new Command() {Name = "CommandName", Value = "CommandValue"}}
                })
            };
        }

        public static void CheckMethod(ISession session)
        {
            var owb = session.Query<WmsOWB>().FirstOrDefault(o => o.Partner.PartnerCode == _mandantCode && o.OWBName == _owbName);
            owb.Should().NotBeNull();
            owb.OWBCarrier.PartnerName.ShouldBeEquivalentTo(_partnerName);
        }
    }
}