using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "ConfirmMessageListRequest")]
    public class ConfirmMessageListRequest
    {
        [DataMember]
        public ConfirmMessageRequest[] Items { get; set; }
    }
}