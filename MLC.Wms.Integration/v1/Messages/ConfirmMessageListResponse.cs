using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "ConfirmMessageListResponse")]
    public class ConfirmMessageListResponse
    {
        [DataMember]
        public ConfirmMessageResponse[] Items { get; set; }
    }
}