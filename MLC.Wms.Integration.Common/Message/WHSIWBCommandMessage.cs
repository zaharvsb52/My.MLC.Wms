using System.Collections.Generic;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common.Entities;

namespace MLC.Wms.Integration.Common.Message
{
    /// <summary>
    /// Интерфейс обмена информации о IWB.
    /// </summary>
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "WHSIWBCommandMessage")]
    public class WHSIWBCommandMessage
    {
        [DataMember]
        public List<Command> CommandList { get; set; }

        [DataMember]
        public List<IWB> IWBList { get; set; }
    }
}