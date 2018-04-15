using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "DequeueListRequest")]
    public class DequeueListRequest : DequeueRequest
    {
        [DataMember]
        public int MessagesCount { get; set; }
    }
}