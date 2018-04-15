using System;
using System.Collections.Generic;
using System.Linq;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using NHibernate.Linq;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        /// <summary>
        /// Добавление сообщения SET_ORDER_RESERVE в очередь In.
        /// </summary>
        public void IntegrationInSetOrderReserve(int owbId)
        {
            using (var session = SessionFactory.OpenSession())
            {
                //Получим накладную
                var owb = session.Get<WmsOWB>(owbId);
                if (owb == null)
                    throw new Exception(string.Format("Не найдена расходная накладная с ид. '{0}'.", owbId));

                var queueIn = new IoQueueIn
                {
                    QueueMessageType = session.Query<IoQueueMessageType>().Single(p => p.Code == "SET_ORDER_RESERVE"),
                    QueueMessageState = QueueMessageStates.Ready,
                    Mandant = owb.Partner,
                    Data = SerializationHelper.SerializeToBytes(new UniversalCommandMessage
                    {
                        CommandList = new List<Command>
                        {
                            new Command {Name = "OWBName", Value = owb.OWBName},
                            new Command {Name = "OWBId", Value = owb.OWBID.ToString()}
                        }
                    })
                };
                session.Save(queueIn);
                session.Flush();
            }
        }
    }
}
