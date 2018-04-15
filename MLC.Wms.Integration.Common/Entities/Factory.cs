using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Фабрика
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class Factory
    {
        [DataMember]
        public int FactoryID { get; set; }

        [DataMember]
        public string FactoryCode { get; set; }

        [DataMember]
        public string FactoryName { get; set; }

        [DataMember]
        public string FactoryDesc { get; set; }

        [DataMember]
        public Mandant Partner { get; set; }

        [DataMember]
        public string FactoryBatchCode { get; set; }

        [DataMember]
        public string FactoryHostRef { get; set; }
    }
}