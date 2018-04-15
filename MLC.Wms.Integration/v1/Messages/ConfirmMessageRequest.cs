using System;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "ConfirmMessageRequest")]
    public class ConfirmMessageRequest
    {
        [DataMember]
        public Guid[] MessageIdList { get; set; }

        [DataMember]
        public String NextState { get; set; }

        [DataMember]
        public DateTime? NextRequiredProcessDate { get; set; }
    }
}