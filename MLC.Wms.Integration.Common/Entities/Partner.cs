using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Справочник бизнес-партнеров
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class Partner
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember]
        [BindingField("PartnerName")]
        public string Name { get; set; }

        /// <summary>
        /// Полное наименование
        /// </summary>
        [DataMember]
        [BindingField("PartnerFullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Вид организации
        /// </summary>
        [DataMember]
        [BindingField("PartnerKind")]
        public string Kind { get; set; }

        /// <summary>
        /// Договор
        /// </summary>
        [DataMember]
        [BindingField("PartnerContract")]
        public string Contract { get; set; }

        /// <summary>
        /// Дата заключения договора
        /// </summary>
        [DataMember]
        [BindingField("PartnerDateContract")]
        public DateTime? DateContract { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [DataMember]
        [BindingField("PartnerPhone")]
        public string Phone { get; set; }

        /// <summary>
        /// Факс
        /// </summary>
        [DataMember]
        [BindingField("PartnerFax")]
        public string Fax { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        [BindingField("PartnerEmail")]
        public string Email { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        [DataMember]
        [BindingField("PartnerINN")]
        public string INN { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        [DataMember]
        [BindingField("PartnerKPP")]
        public string KPP { get; set; }

        /// <summary>
        /// ОГРН
        /// </summary>
        [DataMember]
        [BindingField("PartnerOGRN")]
        public string OGRN { get; set; }

        /// <summary>
        /// ОКПО
        /// </summary>
        [DataMember]
        [BindingField("PartnerOKPO")]
        public string OKPO { get; set; }

        /// <summary>
        /// ОКВЕД
        /// </summary>
        [DataMember]
        [BindingField("PartnerOKVED")]
        public string OKVED { get; set; }

        /// <summary>
        /// Расчетный счет
        /// </summary>
        [DataMember]
        [BindingField("PartnerSettlementAccount")]
        public string SettlementAccount { get; set; }

        /// <summary>
        /// Корреспондентский счет
        /// </summary>
        [DataMember]
        [BindingField("PartnerCorrespondentAccount")]
        public string CorrespondentAccount { get; set; }

        /// <summary>
        /// БИК
        /// </summary>
        [DataMember]
        [BindingField("PartnerBIK")]
        public string BIK { get; set; }

        /// <summary>
        /// Ref
        /// </summary>
        [DataMember]
        [BindingField("PartnerHostRef")]
        public string HostRef { get; set; }

        /// <summary>
        /// Адреса
        /// </summary>
        [DataMember]
        public List<AddressBook> AddressList { get; set; }

        #region .  ShouldSerialize  .

        public bool ShouldSerializeDateContract()
        {
            return DateContract.HasValue;
        }
        
        #endregion .  ShouldSerialize  .
    }
}