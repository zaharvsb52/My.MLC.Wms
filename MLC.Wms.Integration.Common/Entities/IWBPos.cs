using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Позиция приходная накладная.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class IWBPos
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosNumber")]
        public int? Line { get; set; }

        [DataMember]
        [BindingField("WmsArt.ArtName")]
        public string ArtName { get; set; }

        [DataMember]
        [BindingField("WmsArt.ArtHostRef")]
        public string ArtHostRef { get; set; }

        [DataMember]
        [BindingField("WmsMeasure.MeasureCode")]
        public string MeasureCode { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosCount")]
        public int? Count { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosCount2SKU")]
        public double? Count2SKU { get; set; }

        [DataMember]
        [BindingField("WmsIWBPosStatus.StatusCode")]
        public string StatusCode { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public string Tone { get; set; }

        [DataMember]
        public string Size { get; set; }

        [DataMember]
        public string Batch { get; set; }

        [DataMember]
        public string Lot { get; set; }

        [DataMember]
        public DateTime? ExpiryDate { get; set; }

        [DataMember]
        public DateTime? ProductDate { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        [BindingField("WmsFactory.FactoryHostRef")]
        public string FactoryHostRef { get; set; }

        [DataMember]
        public string QLFCode { get; set; }

        [DataMember]
        [BindingField("WmsQLFDetail.QLFDetailCode")]
        public string QLFDetailCode { get; set; }

        [DataMember]
        public double? PriceValue { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosManual")]
        public bool IsManual { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosTE")]
        public string TECode { get; set; }

        [DataMember]
        public string BatchCode { get; set; }

        [DataMember]
        public string BoxNumber { get; set; }

        [DataMember]
        public string KitArtName { get; set; }

        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string Owner { get; set; }

        [DataMember]
        public string InvoiceNumber { get; set; }

        [DataMember]
        public DateTime? InvoiceDate { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosProductCount")]
        public double? ProductCount { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosProductPriority")]
        public int? Priority { get; set; }

        [DataMember]
        [BindingField("WmsIWBPos.IWBPosGTD")]
        public string GTD { get; set; }

        [DataMember]
        public string HostRef { get; set; }

        [DataMember]
        public List<CPV> CPVList { get; set; }


        #region .  ShouldSerialize  .

        public bool ShouldSerializeID()
        {
            return ID.HasValue;
        }

        public bool ShouldSerializeLine()
        {
            return Line.HasValue;
        }

        public bool ShouldSerializeCount()
        {
            return Count.HasValue;
        }

        public bool ShouldSerializeCount2SKU()
        {
            return Count2SKU.HasValue;
        }

        public bool ShouldSerializeExpiryDate()
        {
            return ExpiryDate.HasValue;
        }

        public bool ShouldSerializeProductDate()
        {
            return ProductDate.HasValue;
        }

        public bool ShouldSerializePriceValue()
        {
            return PriceValue.HasValue;
        }

        public bool ShouldSerializeInvoiceDate()
        {
            return InvoiceDate.HasValue;
        }

        public bool ShouldSerializeProductCount()
        {
            return ProductCount.HasValue;
        }

        public bool ShouldSerializePriority()
        {
            return Priority.HasValue;
        }
        #endregion .  ShouldSerialize  .
    }
}