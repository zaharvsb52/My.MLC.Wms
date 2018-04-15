using System;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "QueueMessage")]
    public class QueueMessage
    {
        [DataMember]
        public Guid? ID { get; set; }

        [DataMember]
        public String QueueMessageTypeCode { get; set; }

        [DataMember]
        public String QueueMessageStateCode { get; set; }

        [DataMember]
        public Guid? GroupCode { get; set; }

        [DataMember]
        public String ProcessCode { get; set; }

        [DataMember]
        public Guid? RelatedQueue { get; set; }

        [DataMember]
        public String Message { get; set; }

        [DataMember]
        public String Data { get; set; }

        [DataMember]
        public String Selector { get; set; }

        [DataMember]
        public String Uri { get; set; }

    }
}