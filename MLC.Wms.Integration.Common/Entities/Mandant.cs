using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Мандант
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class Mandant
    {
        [DataMember]
        public int PartnerID { get; set; }

        [DataMember]
        public string PartnerCode { get; set; }

        [DataMember]
        public string PartnerName { get; set; }

        [DataMember]
        public string PartnerFullName { get; set; }

        [DataMember]
        public string PartnerKind { get; set; }

        [DataMember]
        public bool PartnerLocked { get; set; }

        [DataMember]
        public string PartnerContract { get; set; }

        [DataMember]
        public DateTime? PartnerDateContract { get; set; }

        [DataMember]
        public string PartnerPhone { get; set; }

        [DataMember]
        public string PartnerFax { get; set; }

        [DataMember]
        public string PartnerEmail { get; set; }

        [DataMember]
        public string PartnerINN { get; set; }

        [DataMember]
        public string PartnerKPP { get; set; }

        [DataMember]
        public string PartnerOGRN { get; set; }

        [DataMember]
        public string PartnerOKPO { get; set; }

        [DataMember]
        public string PartnerOKVED { get; set; }

        [DataMember]
        public string PartnerSettlementAccount { get; set; }

        [DataMember]
        public string PartnerCorrespondentAccount { get; set; }

        [DataMember]
        public string PartnerBIK { get; set; }

        [DataMember]
        public int PartnerCommercTime { get; set; }

        [DataMember]
        public string PartnerCommercTimeMeasure { get; set; }

        [DataMember]
        public string PartnerHostRef { get; set; }

        #region .  ShouldSerialize  .
        public bool ShouldSerializePartnerDateContract()
        {
            return PartnerDateContract.HasValue;
        }
        #endregion

    }
}