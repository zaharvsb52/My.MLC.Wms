using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Артикул
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class Art
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        //[BindingField("Factory.FactoryHostRef")]
        public string FactoryHostRef { get; set; }

        [DataMember]
        //[BindingField("Partner.MandantCode")]
        public string MandantCode { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string DescriptionExt { get; set; }

        [DataMember]
        public char ABCD { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public string ColorTone { get; set; }

        [DataMember]
        public string Size { get; set; }

        [DataMember]
        public int PickOrder { get; set; }

        [DataMember]
        public double? TempMin { get; set; }

        [DataMember]
        public double? TempMax { get; set; }

        // [DataMember]
        // public SYSENUM_ART_FIFO ArtInputDateMethod { get; set; }

        [DataMember]
        public int? LifeTime { get; set; }

        [DataMember]
        public string LifeTimeMeasure { get; set; }

        [DataMember]
        public string IWBType { get; set; }

        [DataMember]
        public string DangerLevel { get; set; }

        [DataMember]
        public string DangerSubLevel { get; set; }

        [DataMember]
        public string HostRef { get; set; }

        [DataMember]
        public int CommercTime { get; set; }

        [DataMember]
        public string CommercTimeMeasure { get; set; }

        [DataMember]
        public string Mark { get; set; }

        [DataMember]
        public string Brand { get; set; }

        [DataMember]
        public string Model { get; set; }

        [DataMember]
        public Mandant Manufacturer { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        //[BindingField("Country.CountryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Сущность файл
        /// </summary>
        [DataMember]
        public ArtPicture ArtPicture { get; set; }

        #region .  ShouldSerialize  .
        public bool ShouldSerializeLifeTime()
        {
            return LifeTime.HasValue;
        }
        
        public bool ShouldSerializeTempMin()
        {
            return TempMin.HasValue;
        }

        public bool ShouldSerializeTempMax()
        {
            return TempMax.HasValue;
        }
        #endregion
    }
}
