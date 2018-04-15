using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Message
{
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "DSState")]
    public class DSState
    {
        [DataMember]
        public List<Command> CommandList { get; set; }

        [DataMember]
        public string OWBName { get; set; }

        [DataMember]
        public string PartnerOrder { get; set; }

        [DataMember]
        public string DeliveryServiceRef { get; set; }

        [DataMember]
        public DateTime? OperationDate { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string StateDetail { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public DateTime? PlannedDeliveryDate { get; set; }

        #region .  ShouldSerialize  .

        public bool ShouldSerializeID()
        {
            return OperationDate.HasValue;
        }

        public bool ShouldSerializeOutDatePlan()
        {
            return PlannedDeliveryDate.HasValue;
        }

        #endregion
    }
}