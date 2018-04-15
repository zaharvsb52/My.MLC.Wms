using System;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.LocalStorage;

namespace MLC.Wms.Common
{
    public static class WmsEnvironment
    {
        private static IWmsEnvironmentInfoProvider _provider;
        private static ILocalData _localData;

        public static void Init(IWmsEnvironmentInfoProvider provider, ILocalData localData)
        {
            _provider = provider;
            _localData = localData;
        }
        
        /// <summary>
        /// Current logged user name
        /// </summary>
        public static string UserName
        {
            get
            {
                CheckInitialization();
                return _provider.UserName;
            }
        }

        public static ILocalData LocalData
        {
            get
            {
                CheckInitialization();
                return _localData;
            }
        }

        private static void CheckInitialization()
        {
            if (_provider == null)
                throw new Exception("You must init WmsEnvironment before use it");
        }
    }
}