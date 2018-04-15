using System;

namespace MLC.Wms.Model.Entities
{
    [Serializable]
    public abstract class BaseEntity
    {
        public virtual string EntityName
        {
            get { return GetType().Name; }
            set { }
        }
    }
}