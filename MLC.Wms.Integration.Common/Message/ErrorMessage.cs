using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Message
{
    /// <summary>
    /// Интерфейс обмена информации об ошибках.
    /// </summary>
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "ErrorMessage")]
    public class ErrorMessage
    {
        [DataMember]
        public List<Command> CommandList { get; set; }

        [DataMember]
        public List<ErrorInfo> ErrorInfoList { get; set; }
    }
}