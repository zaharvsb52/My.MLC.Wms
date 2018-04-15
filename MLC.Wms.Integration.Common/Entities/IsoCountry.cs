using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Страна
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class IsoCountry
    {
        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string CountryNameEng { get; set; }

        [DataMember]
        public string CountryNameRus { get; set; }

        [DataMember]
        public string CountryAlpha2 { get; set; }

        [DataMember]
        public string CountryNumeric { get; set; }
    }
}