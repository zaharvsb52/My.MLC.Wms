using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLC.Wms.Integration.Common
{
    /// <summary>
    /// Аттрибут, который упрощает маппинг объектов
    /// </summary>
    public class BindingFieldAttribute : Attribute
    {
        public BindingFieldAttribute(string bindingPath)
        {

        }
    }
}
