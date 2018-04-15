using System;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "EnqueueListResponse")]
    public class EnqueueListResponse
    {
        [DataMember]
        public String PartnerCode { get; set; }

        [DataMember]
        public QueueMessage[] MessageList { get; set; }
    }
}