using System.Collections.Generic;
using System.Web;

namespace MLC.Wms.Common.LocalStorage
{
    public class WebLocalData : DictionaryBasedLocalData
    {
        private static readonly object localDataDictionaryKey = new object();

        protected override IDictionary<object, object> LocalDictionary
        {
            get
            {
                var webDictionary = HttpContext.Current.Items[localDataDictionaryKey] as Dictionary<object, object>;
                if (webDictionary == null)
                    HttpContext.Current.Items[localDataDictionaryKey] = webDictionary = new Dictionary<object, object>();

                return webDictionary;
            }
        }
    }
}