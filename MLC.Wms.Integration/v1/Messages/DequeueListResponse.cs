using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "DequeueListResponse")]
    public class DequeueListResponse
    {
        [DataMember]
        public DequeueResponse[] Items { get; set; }
    }
}