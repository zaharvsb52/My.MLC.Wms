using System.Collections.Generic;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common.Entities;

namespace MLC.Wms.Integration.Common.Message
{
    /// <summary>
    /// Интерфейс обмена информации о OWB.
    /// </summary>
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "WHSOWBCommandMessage")]
    public class WHSOWBCommandMessage
    {
        [DataMember]
        public List<Command> CommandList { get; set; }

        [DataMember]
        public List<OWB> OWBList { get; set; }
    }
}
