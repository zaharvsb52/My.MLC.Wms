using System;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common;

namespace MLC.Wms.Integration.v1.Messages
{
    [DataContract(Namespace = NamespaceHelper.V1Namespace, Name = "DequeueRequest")]
    public class DequeueRequest
    {
        [DataMember]
        public String EnableTypes { get; set; }

        [DataMember]
        public String DisableTypes { get; set; }

        [DataMember]
        public String EnablePratnersCodes { get; set; }

        [DataMember]
        public String DisablePratnersCodes { get; set; }

        [DataMember]
        public Boolean RequiresConfirmation { get; set; }

        [DataMember]
        public String Selector { get; set; }
    }
}