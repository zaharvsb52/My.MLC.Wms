using System;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "DequeueResponse")]
    public class DequeueResponse
    {
        [DataMember]
        public String PartnerCode { get; set; }

        [DataMember]
        public String MessageType { get; set; }

        [DataMember]
        public DateTime DateIns { get; set; }

        [DataMember]
        public QueueMessage Message { get; set; }
    }
}