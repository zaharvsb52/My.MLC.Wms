using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Message
{
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "ErrorInfo")]
    public class ErrorInfo
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Uri { get; set; }

        [DataMember]
        public string QueueMessageTypeName { get; set; }

        [DataMember]
        public string CallStack { get; set; }

        [DataMember]
        public string ErrorType { get; set; }
    }
}