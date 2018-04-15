using System;
using System.Configuration;

namespace MLC.Wms.WebApp
{
    public static class AppSettings
    {
        private static string _enableMiniProfiler;
        private static string _adPath;
        private static string _wF_XAML_PATH;
        private static string _rEPORTS_PATH;

        #region Public

        public static string EnableMiniProfiler
        {
            get { return _enableMiniProfiler ?? (_enableMiniProfiler = GetConfigurationSetting("enableMiniProfiler")); }
            set { _enableMiniProfiler = value; }
        }

        public static string AdPath
        {
            get { return _adPath ?? (_adPath = GetConfigurationSetting("AdPath")); }
            set { _adPath = value; }
        }

        public static string WF_XAML_PATH
        {
            get { return _wF_XAML_PATH ?? (_wF_XAML_PATH = GetConfigurationSetting("WF_XAML_PATH")); }
            set { _wF_XAML_PATH = value; }
        }

        public static string REPORTS_PATH
        {
            get { return _rEPORTS_PATH ?? (_rEPORTS_PATH = GetConfigurationSetting("REPORTS_PATH")); }
            set { _rEPORTS_PATH = value; }
        }

        public static void Reset()
        {
            _enableMiniProfiler = null;
            _adPath = null;
            _wF_XAML_PATH = null;
            _rEPORTS_PATH = null;
        }

        #endregion

        #region Connection strings

        public static class ConnectionStrings
        {
            private static string _localSqlServer;
            private static string _oraAspNetConString;
            private static string _wms;
            private static string _rep;
            private static string _wf;

            public static string LocalSqlServer
            {
                get { return _localSqlServer ?? (_localSqlServer = GetConnectionString("LocalSqlServer")); }
                set { _localSqlServer = value; }
            }

            public static string OraAspNetConString
            {
                get { return _oraAspNetConString ?? (_oraAspNetConString = GetConnectionString("OraAspNetConString")); }
                set { _oraAspNetConString = value; }
            }

            public static string Wms
            {
                get { return _wms ?? (_wms = GetConnectionString("wms")); }
                set { _wms = value; }
            }

            public static string Rep
            {
                get { return _rep ?? (_rep = GetConnectionString("rep")); }
                set { _rep = value; }
            }

            public static string Wf
            {
                get { return _wf ?? (_wf = GetConnectionString("wf")); }
                set { _wf = value; }
            }

        }

        #endregion

        #region Helpers

        private static string GetConfigurationSetting(string settingName)
        {
            if (ConfigurationManager.AppSettings.Count != 0)
            {
                try
                {
                    var value = ConfigurationManager.AppSettings.Get(settingName);
                    if (value == null)
                    {
                        throw new ConfigurationErrorsException("Invalid configuration setting: " + settingName);
                    }
                    return value;
                }
                catch (Exception e)
                {
                    throw new ConfigurationErrorsException("Invalid configuration setting: " + settingName, e);
                }
            }
            throw new ConfigurationErrorsException("Invalid configuration. Required AppSettings section is missing.");
        }

        private static string GetConnectionString(string connectionStringName)
        {
            try
            {
                var value = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                if (value == null)
                {
                    throw new ConfigurationErrorsException("Invalid connection string name: " + connectionStringName);
                }
                return value;
            }
            catch (Exception e)
            {
                throw new ConfigurationErrorsException("Invalid connection string name: " + connectionStringName, e);
            }
        }

        #endregion
    }
}

