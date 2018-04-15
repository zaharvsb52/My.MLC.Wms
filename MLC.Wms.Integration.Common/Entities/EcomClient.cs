using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class EcomClient
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        [DataMember]
        [BindingField("ClientLastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [DataMember]
        [BindingField("ClientName")]
        public string Name { get; set; }

        /// <summary>
        /// Очество
        /// </summary>
        [DataMember]
        [BindingField("ClientMiddleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        [DataMember]
        [BindingField("ClientPhoneMobile")]
        public string PhoneMobile { get; set; }

        /// <summary>
        /// Рабочий телефон
        /// </summary>
        [DataMember]
        [BindingField("ClientPhoneWork")]
        public string PhoneWork { get; set; }

        /// <summary>
        /// Добавочный номер
        /// </summary>
        [DataMember]
        [BindingField("ClientPhoneInternal")]
        public string PhoneInternal { get; set; }

        /// <summary>
        /// Домашний телефон
        /// </summary>
        [DataMember]
        [BindingField("ClientPhoneHome")]
        public string PhoneHome { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [DataMember]
        [BindingField("ClientEmail")]
        public string Email { get; set; }

        /// <summary>
        /// HostRef
        /// </summary>
        [DataMember]
        [BindingField("ClientHostRef")]
        public string HostRef { get; set; }

        /// <summary>
        /// Адреса
        /// </summary>
        [DataMember]
        public List<AddressBook> AddressList { get; set; }
    }
}