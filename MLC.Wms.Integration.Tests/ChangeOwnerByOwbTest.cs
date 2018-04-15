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
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    internal class ChangeOwnerByOwbTest : BaseIntegrationWorkflowTest
    {
        public ChangeOwnerByOwbTest()
        {
            InArgumentWorkflow = new CHANGE_OWNER_BY_OWB();
        }

        [Test]
        public void ContentTest()
        {
            //ExecuteWorkflowTest(GetType(), "GetQueueIn", "CheckMethod");

            Action action = () => ExecuteWorkflowTest(GetType(), "GetQueueIn", "FakeCheck");
            var message = string.Join(Environment.NewLine,
                "Владелец товара соответствует владельцу, указанному в расходной накладной 'Test-02042015' ('14249'), смена владельца не требуется.",
                "Обработка накладной 'З0BЦБ-000179' ('13526') в статусе 'OWB_CREATED' запрещена.",
                "Обработка накладной '036262456789' ('14369') в статусе 'OWB_CREATED' запрещена.") + Environment.NewLine;

            action.ShouldThrow<Exception>().Which
                .Message.ShouldBeEquivalentTo(message);
        }

        public static IoQueueIn GetQueueIn(ISession session)
        {
            var partnerCode = "BJ";
            var owbname = "Test-02042015";
            //var ownerCode = "MET";
            var queueMessageTypeCode = "CHANGE_OWNER_BY_OWB";

            var partner = session.Query<WmsMandant>().FirstOrDefault(o => o.PartnerCode == partnerCode);
            if (partner == null)
                throw new Exception(string.Format("Отсутствует партнёр {0}", partnerCode));

            var owb = session.Query<WmsOWB>().FirstOrDefault(o => o.Partner.PartnerCode == partnerCode
                   && o.OWBName == owbname);
            if (owb == null)
                throw new Exception(string.Format("Отсутствует накладная {0}", owbname));

            return new IoQueueIn
            {
                Mandant = partner,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == queueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new WHSOWBCommandMessage()
                {
                    OWBList = new List<OWB>
                    {
                        {new OWB() {Name = owbname}},
                        { new OWB() {Name = "036262456789"} },
                        { new OWB() {Name = "З0BЦБ-000179"} }

                    },
                    CommandList = new List<Command>()
                    {
                        new Command() {Name = "ClientFileName", Value = "amber"}
                    }
                })
            };
        }

        public static void FakeCheck(ISession session)
        {
            throw new InvalidOperationException("Не должно было запускаться.");
        }

        public static void CheckMethod(ISession session)
        {
        }
    }
}