using System;
using System.Collections.Generic;

namespace MLC.Wms.Common.LocalStorage
{
    public class ThreadStaticLocalData : DictionaryBasedLocalData
    {
        [ThreadStatic]
        private static IDictionary<object, object> threadDictionary;

        protected override IDictionary<object, object> LocalDictionary
        {
            get
            {
                return threadDictionary ?? (threadDictionary = new Dictionary<object, object>());
            }
        }
    }
}