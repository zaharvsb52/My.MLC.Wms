using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class ImageLoadArt : BaseIntegrationWorkflowTest
    {
        public ImageLoadArt()
        {
            InArgumentWorkflow = new IMAGE_ART_LOAD();
        }

        [Test]
        public void ContentTest()
        {
            ExecuteWorkflowTest(GetType(), "GetQueueIn", "CheckMethod");
        }

        public static IoQueueIn GetQueueIn(ISession session)
        {
            var partnerCode = "RGL";
            var queueMessageTypeCode = "IP_LOAD_ART";

            var partner = session.Query<WmsMandant>().FirstOrDefault(o => o.PartnerCode == partnerCode);
            if (partner == null)
                throw new Exception(string.Format("Отсутствует партнёр {0}", partnerCode));

            var artSample = session.Query<WmsArt>().FirstOrDefault();

            return new IoQueueIn
            {
                Mandant = partner,
                QueueMessageType = session.Query<IoQueueMessageType>().First(i => i.Code == queueMessageTypeCode),
                QueueMessageState = QueueMessageStates.Processing,
                Message = null,
                Data = SerializationHelper.SerializeToBytes(new ArticleLoad()
                {
                    ArtList = new[]
                    {
                        new Art()
                        {
                            Code = artSample.ArtCode,
                            Name = artSample.ArtName
                        }
                    },
                    CommandList = new Dictionary<string, string>()
                    {
                        {"ClientFileName", "amber"}
                    }
                })
            };
        }

        public static void CheckMethod(ISession session)
        {
        }
    }
}