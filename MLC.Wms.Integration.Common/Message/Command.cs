using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Message
{
    /// <summary>
    /// Командно/сопроводительная информация.
    /// </summary>
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "Command")]
    public class Command
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}
