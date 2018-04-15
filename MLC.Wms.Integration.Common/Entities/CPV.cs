using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// ���������������� ���������
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class CPV
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}