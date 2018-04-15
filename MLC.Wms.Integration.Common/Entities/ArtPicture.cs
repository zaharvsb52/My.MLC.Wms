using System;
using System.Runtime.Serialization;

namespace MLC.Wms.Integration.Common.Entities
{
    /// <summary>
    /// Файл
    /// </summary>
    [Serializable]
    [DataContract(Namespace = NamespaceHelper.V1EntitiesNamespace)]
    public class ArtPicture
    {
        [DataMember]
        public int? ID { get; set; }

        [DataMember]
        public string Entity { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public int? Size { get; set; }

        [DataMember]
        public string Version { get; set; }

        //[DataMember(Name = "DBFile")]
        //public string DBFile { get; set; }

        [DataMember]
        public string FileData { get; set; }

        #region .  ShouldSerialize  .
        public bool ShouldSerializeFileSize()
        {
            return Size.HasValue;
        }

        public bool ShouldSerializeID()
        {
            return ID.HasValue;
        }
        #endregion

    }
}