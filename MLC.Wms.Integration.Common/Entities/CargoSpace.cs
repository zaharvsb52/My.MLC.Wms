using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Грузовое место (ТЕ).
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]

    public class CargoSpace
    {
        [DataMember]
        [BindingField("TECode")]
        public string Code { get; set; }

        [DataMember]
        [BindingField("WmsTEType.TETypeCode")]
        public string TypeCode { get; set; }

        /// <summary>
        /// Код несущей.
        /// </summary>
        [DataMember]
        public string CarrierBaseCode { get; set; }

        /// <summary>
        /// Код промежуточной несущей
        /// </summary>
        [DataMember]
        public string CarrierStreakCode { get; set; }

        /// <summary>
        /// Код текущего места.
        /// </summary>
        [DataMember]
        [BindingField("WmsPlace.PlaceCode")]
        public string CurrentPlace { get; set; }

        /// <summary>
        /// Код места создания.
        /// </summary>
        [DataMember]
        public string CreationPlace { get; set; }

        /// <summary>
        /// Длина.
        /// </summary>
        [DataMember]
        public int Length { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        [DataMember]
        public int Width { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        [DataMember]
        public int Height { get; set; }

        /// <summary>
        /// Код статуса.
        /// </summary>
        [DataMember]
        [BindingField("WmsTEStatus.StatusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Статус упаковки.
        /// </summary>
        [DataMember]
        public string PackStatus { get; set; }

        /// <summary>
        /// Итоговый вес.
        /// </summary>
        [DataMember]
        public decimal? Weight { get; set; }

        /// <summary>
        /// Итоговый максимальный вес. 
        /// </summary>
        [DataMember]
        public decimal MaxWeight { get; set; }

        /// <summary>
        /// Вес тары.
        /// </summary>
        [DataMember]
        public decimal? TareWeight { get; set; }

        /// <summary>
        /// Идентификатор в хост-системе.
        /// </summary>
        [DataMember]
        public string HostRef { get; set; }

        [DataMember]
        public int Volume
        {
            get { return Length*Width*Height; }
            set { } //Для сериализации
        }

        #region .  ShouldSerialize  .
        public bool ShouldSerializeWeight()
        {
            return Weight.HasValue;
        }

        public bool ShouldSerializeTareWeight()
        {
            return TareWeight.HasValue;
        }
        #endregion .  ShouldSerialize  .
    }
}
