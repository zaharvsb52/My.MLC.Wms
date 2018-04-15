using System.Collections.Generic;
using System.Runtime.Serialization;
using MLC.Wms.Integration.Common.Entities;

namespace MLC.Wms.Integration.Common.Message
{
    /// <summary>
    /// Запрос на загрузку артикулов
    /// </summary>
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class ArticleLoad
    {
        /// <summary>
        /// Командно/сопроводительной информации
        /// </summary>
        [DataMember]
        public Dictionary<string, string> CommandList { get; set; }

        /// <summary>
        /// Массив артикулов
        /// </summary>
        [DataMember]
        public Art[] ArtList { get; set; }
    }
}
