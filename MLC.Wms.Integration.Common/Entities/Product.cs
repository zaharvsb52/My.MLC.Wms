using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Товар.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class Product
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        public string TECode { get; set; }

        [DataMember]
        [BindingField("WmsArt.ArtHostRef")]
        public string ArtHostRef { get; set; }

        [DataMember]
        [BindingField("WmsMeasure.MeasureCode")]
        public string MeasureCode { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        [DataMember]
        [BindingField("WmsProduct.ProductCountSKU")]
        public int Count { get; set; }

        /// <summary>
        /// Количество SKU.
        /// </summary>
        [DataMember]
        [BindingField("WmsProduct.ProductCount")]
        public double Count2SKU { get; set; }

        [DataMember]
        public int TTEQuantity { get; set; }

        [DataMember]
        public string QLFCode { get; set; }

        [DataMember]
        public string QLFDetailCode { get; set; }

        [DataMember]
        public DateTime InputDate { get; set; }

        /// <summary>
        /// Дата производства.
        /// </summary>
        [DataMember]
        public DateTime? ProductDate { get; set; }

        [DataMember]
        public string Pack { get; set; }

        [DataMember]
        public int? PackCountSKU { get; set; }

        [DataMember]
        public DateTime? ExpiryDate { get; set; }

        [DataMember]
        public string Batch { get; set; }

        [DataMember]
        public string Lot { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public string Tone { get; set; }

        [DataMember]
        public string Size { get; set; }

        [DataMember]
        [BindingField("WmsArt.ArtName")]
        public string ArtName { get; set; }

        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string MandantCode { get; set; }

        [DataMember]
        public int? IWBPosID { get; set; }

        [DataMember]
        public int? OWBPosID { get; set; }

        [DataMember]
        [BindingField("WmsFactory.FactoryHostRe")]
        public string FactoryHostRef { get; set; }

        [DataMember]
        [BindingField("WmsProductStatus.StatusCode")]
        public string StatusCode { get; set; }

        [DataMember]
        public string BatchCode { get; set; }

        [DataMember]
        public string BoxNumber { get; set; }

        [DataMember]
        public string HostRef { get; set; }

        [DataMember]
        public string KitArtName { get; set; }

        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string OwnerCode { get; set; }

        [DataMember]
        public int? Priority { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        /// <summary>
        /// Номер позиции расходной накладной.
        /// </summary>
        [DataMember]
        [BindingField("WmsOWBPos.OWBPosNumber")]
        public int? Line { get; set; }

        [DataMember]
        public string GTD { get; set; }

        #region .  ShouldSerialize  .

        public bool ShouldSerializeID()
        {
            return ID.HasValue;
        }

        public bool ShouldSerializeProductDate()
        {
            return ProductDate.HasValue;
        }

        public bool ShouldSerializePackCountSKU()
        {
            return PackCountSKU.HasValue;
        }

        public bool ShouldSerializeExpiryDate()
        {
            return ExpiryDate.HasValue;
        }

        public bool ShouldSerializeIWBPosID()
        {
            return IWBPosID.HasValue;
        }

        public bool ShouldSerializeOWBPosID()
        {
            return OWBPosID.HasValue;
        }

        public bool ShouldSerializePriority()
        {
            return Priority.HasValue;
        }

        public bool ShouldSerializeLine()
        {
            return Line.HasValue;
        }
        #endregion .  ShouldSerialize  .
    }
}
