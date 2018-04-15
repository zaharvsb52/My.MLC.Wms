using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Товар.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class AddressBook
    {
        [DataMember]
        public int? ID { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        [DataMember]
        public string Country { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        [DataMember]
        public int? Index { get; set; }

        /// <summary>
        /// Регион (регион, область, район, край).
        /// </summary>
        [DataMember]
        public string Region { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Район.
        /// </summary>
        [DataMember]
        public string District { get; set; }

        /// <summary>
        /// Улица.
        /// </summary>
        [DataMember]
        public string Street { get; set; }

        /// <summary>
        /// Здание.
        /// </summary>
        [DataMember]
        public string Building { get; set; }

        /// <summary>
        /// Квартира или офис.
        /// </summary>
        [DataMember]
        public string Apartment { get; set; }

        /// <summary>
        /// Тип адреса.
        /// </summary>
        [DataMember]
        public string TypeCode { get; set; }

        /// <summary>
        /// Необработанный адрес.
        /// </summary>
        [DataMember]
        public string Raw { get; set; }

        /// <summary>
        /// По умолчанию.
        /// </summary>
        [DataMember]
        public bool? Default { get; set; }

        /// <summary>
        /// HostRef
        /// </summary>
        [DataMember]
        public string HostRef { get; set; }

        #region .  ShouldSerialize  .
        public bool ShouldSerializeID()
        {
            return ID.HasValue;
        }

        public bool ShouldSerializeIndex()
        {
            return Index.HasValue;
        }

        public bool ShouldSerializeDefault()
        {
            return Default.HasValue;
        }
        #endregion .  ShouldSerialize  .
    }
}
