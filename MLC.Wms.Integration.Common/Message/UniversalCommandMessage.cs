using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Message
{
    /// <summary>
    /// ��������� ������ ���������
    /// </summary>
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace, Name = "UniversalCommandMessage")]
    public class UniversalCommandMessage
    {
        [DataMember]
        public List<Command> CommandList { get; set; }
    }
}