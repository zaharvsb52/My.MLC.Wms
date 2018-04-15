using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common.Message;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Приходная накладная.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class IWB
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string MandantCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Priority { get; set; }

        [DataMember]
        [BindingField("WmsIWBStatus.StatusCode")]
        public string StatusCode { get; set; }

        [DataMember]
        public DateTime? InDatePlan { get; set; }

        [DataMember]
        [BindingField("WmsPartner.PartnerHostRef")]
        public string SenderHostRef { get; set; }

        [DataMember]
        [BindingField("WmsPartner.PartnerHostRef")]
        public string PayerHostRef { get; set; }

        [DataMember]
        [BindingField("WmsPartner.PartnerHostRef")]
        public string Recipient { get; set; }

        [DataMember]
        public string CMRNumber { get; set; }

        [DataMember]
        public DateTime? CMRDate { get; set; }

        [DataMember]
        [BindingField("WmsFactory.FactoryHostRef")]
        public string FactoryHostRef { get; set; }

        [DataMember]
        public string TypeCode { get; set; }
        
        [DataMember]
        public string HostRef { get; set; }
        
        [DataMember]
        public string Group { get; set; }

        [DataMember]
        public string OrderReturn { get; set; }

        [DataMember]
        public List<Product> ProductList { get; set; }

        [DataMember]
        public List<IWBPos>IWBPosList { get; set; }

        [DataMember]
        public List<CPV> CPVList { get; set; }

        [DataMember]
        public List<Command> CommandList { get; set; }

        #region .  ShouldSerialize  .

        public bool ShouldSerializeID()
        {
            return ID.HasValue;
        }

        public bool ShouldSerializeInDatePlan()
        {
            return InDatePlan.HasValue;
        }

        public bool ShouldSerializeCMRDate()
        {
            return CMRDate.HasValue;
        }
       
        #endregion .  ShouldSerialize  .
    }
}