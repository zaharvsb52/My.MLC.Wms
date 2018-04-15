using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Позиции расходной накладной
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class OWBPos
    {
        /// <summary>
        /// ID записи
        /// </summary>
        [DataMember]
        [BindingField("OWBPosID")]
        public int ID { get; set; }

        /// <summary>
        /// Номер позиции
        /// </summary>
        [DataMember]
        [BindingField("OWBPosNumber")]
        public int Line { get; set; }

        /// <summary>
        /// Наименование артикула
        /// </summary>
        [DataMember]
        [BindingField("WmsArt.ArtName")]
        public string ArtName { get; set; }

        /// <summary>
        /// Описание артикула
        /// </summary>
        [DataMember]
        [BindingField("WmsArt.ArtDesc")]
        public string ArtDesc { get; set; }

        /// <summary>
        /// Ref артикула
        /// </summary>
        [DataMember]
        [BindingField("WmsArt.ArtHostRef")]
        public string ArtHostRef { get; set; }

        /// <summary>
        /// Код единицы измерения
        /// </summary>
        [DataMember]
        [BindingField("WmsMeasure.MeasureCode")]
        public string MeasureCode { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        [DataMember]
        [BindingField("OWBPosCount")]
        public int Count { get; set; }

        /// <summary>
        /// Дробное ко-во
        /// </summary>
        [DataMember]
        [BindingField("OWBPosCount2SKU")]
        public double Count2SKU { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [DataMember]
        [BindingField("WmsOWBPosStatus.StatusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        [DataMember]
        [BindingField("OWBPosColor")]
        public string Color { get; set; }

        /// <summary>
        /// Тон
        /// </summary>
        [DataMember]
        [BindingField("OWBPosTone")]
        public string Tone { get; set; }

        /// <summary>
        /// Размер
        /// </summary>
        [DataMember]
        [BindingField("OWBPosSize")]
        public string Size { get; set; }

        /// <summary>
        /// Партия
        /// </summary>
        [DataMember]
        [BindingField("OWBPosBatch")]
        public string Batch { get; set; }

        /// <summary>
        /// Лот
        /// </summary>
        [DataMember]
        [BindingField("OWBPosLot")]
        public string Lot { get; set; }

        /// <summary>
        /// Срок годности
        /// </summary>
        [DataMember]
        [BindingField("OWBPosExpiryDate")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Дата производства
        /// </summary>
        [DataMember]
        [BindingField("OWBPosProductDate")]
        public DateTime? ProductDate { get; set; }

        /// <summary>
        /// Серийный номер
        /// </summary>
        [DataMember]
        [BindingField("OWBPosSerialNumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Фабрика
        /// </summary>
        [DataMember]
        [BindingField("WmsFactory.FactoryHostRef")]
        public string FactoryHostRef { get; set; }

        /// <summary>
        /// Квалификация
        /// </summary>
        [DataMember]
        [BindingField("WmsQLF.QLFCode")]
        public string QLFCode { get; set; }

        /// <summary>
        /// Детализация квалификации
        /// </summary>
        [DataMember]
        [BindingField("WmsQLFDetail.QLFDetailCode")]
        public string QLFDetailCode { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [DataMember]
        [BindingField("OWBPosPriceValue")]
        public double? PriceValue { get; set; }

        /// <summary>
        /// Стоимость с НДС
        /// </summary>
        [DataMember]
        [BindingField("OWBPosPriceValueVAT")]
        public double? PriceValueVAT { get; set; }

        /// <summary>
        /// Кол-во зарезервированного товара
        /// </summary>
        [DataMember]
        [BindingField("OWBPosReserved")]
        public int? Reserved { get; set; }

        /// <summary>
        /// Номер короба
        /// </summary>
        [DataMember]
        [BindingField("OWBPosBoxNumber")]
        public string BoxNumber { get; set; }

        /// <summary>
        /// Артикул комплекта
        /// </summary>
        [DataMember]
        [BindingField("OWBPosKitArtName")]
        public string KitArtName { get; set; }

        /// <summary>
        /// Владелец
        /// </summary>
        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string Owner { get; set; }

        /// <summary>
        /// Хост-идентификатор
        /// </summary>
        [DataMember]
        [BindingField("OWBPosHostRef")]
        public string HostRef { get; set; }

        /// <summary>
        /// Пользовательские параметры
        /// </summary>
        [DataMember]
        public List<CPV> CPVList { get; set; }

        #region .  ShouldSerialize  .

        public bool ShouldSerializeExpiryDate()
        {
            return ExpiryDate.HasValue;
        }

        public bool ShouldSerializeProductDate()
        {
            return ProductDate.HasValue;
        }

        public bool ShouldSerializeReserved()
        {
            return Reserved.HasValue;
        }

        public bool ShouldSerializePriceValue()
        {
            return PriceValue.HasValue;
        }

        public bool ShouldSerializePriceValueVAT()
        {
            return PriceValueVAT.HasValue;
        }

        #endregion .  ShouldSerialize  .
    }
}