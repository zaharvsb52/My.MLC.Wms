using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common.Message;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Расходная накладная.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class OWB
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string MandantCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Priority { get; set; }

        [DataMember]
        [BindingField("WmsOWBStatus.StatusCode")]
        public string StatusCode { get; set; }

        [DataMember]
        public DateTime? OutDatePlan { get; set; }

        /// <summary>
        /// Код получателя.
        /// </summary>
        [DataMember]
        [BindingField("WmsPartner.PartnerHostRef")]
        public string RecipientHostRef { get; set; }

        /// <summary>
        /// Код плательщика.
        /// </summary>
        [DataMember]
        [BindingField("WmsPartner.PartnerHostRef")]
        public string PayerHostRef { get; set; }

        /// <summary>
        /// Клиент-получатель.
        /// </summary>
        [DataMember]
        public EcomClient ClientRecipient { get; set; }

        /// <summary>
        /// Доставка, план.
        /// </summary>
        [DataMember]
        public DateTime? PlannedDeliveryDate { get; set; }

        /// <summary>
        /// Код клиента-плательщика.
        /// </summary>
        [DataMember]
        [BindingField("ecomClient.ClientHostRef")]
        public string ClientPayerHostRef { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Фабрика.
        /// </summary>
        [DataMember]
        [BindingField("WmsFactory.FactoryHostRef")]
        public string FactoryHostRef { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        [DataMember]
        public AddressBook Address { get; set; }

        // <summary>
        /// Номер доверенности.
        /// </summary>
        [DataMember]
        public string ProxyNumber { get; set; }

        /// <summary>
        /// Дата доверенности.
        /// </summary>
        [DataMember]
        public DateTime? ProxyDate { get; set; }

        /// <summary>
        /// Клиентская дата создания накладной.
        /// </summary>
        [DataMember]
        public DateTime? HostRefDate { get; set; }

        /// <summary>
        /// Тип накладной.
        /// </summary>
        [DataMember]
        public string TypeCode { get; set; }

        /// <summary>
        /// Плановый маршрут.
        /// </summary>
        [DataMember]
        public int? RoutePlan { get; set; }

        /// <summary>
        /// Идентификатор в хост-системе.
        /// </summary>
        [DataMember]
        public string HostRef { get; set; }

        /// <summary>
        /// Код владелеца.
        /// </summary>
        [DataMember]
        [BindingField("WmsMandant.PartnerCode")]
        public string OwnerCode { get; set; }

        /// <summary>
        /// Группа накладных.
        /// </summary>
        [DataMember]
        public string Group { get; set; }

        /// <summary>
        /// Перевозчик.
        /// </summary>
        [DataMember]
        public Partner Carrier { get; set; }

        /// <summary>
        /// Заказ КС.
        /// </summary>
        [DataMember]
        public string PartnerOrder { get; set; }

        [DataMember]
        public List<Product> ProductList { get; set; }

        [DataMember]
        public List<CargoSpace> CargoSpaceList { get; set; }

        [DataMember]
        public List<Command> CommandList { get; set; }

        /// <summary>
        /// Позиции
        /// </summary>
        [DataMember]
        public List<OWBPos> OWBPosList { get; set; }

        /// <summary>
        /// Пользовательские параметры
        /// </summary>
        [DataMember]
        public List<CPV> CPVList { get; set; }

        ///// <summary>
        ///// Дата фактической отгрузки.
        ///// </summary>
        //[DataMember]
        //public DateTime? FactShipmentDate { get; set; }

        #region .  ShouldSerialize  .

        public bool ShouldSerializeID()
        {
            return ID.HasValue;
        }

        public bool ShouldSerializeOutDatePlan()
        {
            return OutDatePlan.HasValue;
        }

        public bool ShouldSerializePlannedDeliveryDate()
        {
            return PlannedDeliveryDate.HasValue;
        }

        public bool ShouldSerializeProxyDate()
        {
            return ProxyDate.HasValue;
        }

        public bool ShouldSerializeHostRefDate()
        {
            return HostRefDate.HasValue;
        }

        public bool ShouldSerializeRoutePlan()
        {
            return RoutePlan.HasValue;
        }
        #endregion .  ShouldSerialize  .
    }
}
