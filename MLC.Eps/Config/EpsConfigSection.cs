using System.Configuration;

namespace MLC.Eps.Config
{
    public class EpsConfigSection : ConfigurationSection, IEpsConfiguration
    {
        public const string DefaultSectionName = "eps";

        [ConfigurationProperty("ReportPath", DefaultValue = "", IsRequired = true)]
        public string ReportPath
        {
            get { return (string)base["ReportPath"]; }
            set { this["ReportPath"] = value; }
        }

        [ConfigurationProperty("ArchPath", DefaultValue = "", IsRequired = true)]
        public string ArchPath
        {
            get { return (string)base["ArchPath"]; }
            set { this["ArchPath"] = value; }
        }

        [ConfigurationProperty("TmpPath", DefaultValue = "", IsRequired = true)]
        public string TmpPath
        {
            get { return (string)base["TmpPath"]; }
            set { this["TmpPath"] = value; }
        }

        [ConfigurationProperty("OdbcConnectionString", DefaultValue = "", IsRequired = true)]
        public string OdbcConnectionString
        {
            get { return (string)base["OdbcConnectionString"]; }
            set { this["OdbcConnectionString"] = value; }
        }

        [ConfigurationProperty("OdacConnectionString", DefaultValue = "", IsRequired = true)]
        public string OdacConnectionString
        {
            get { return (string)base["OdacConnectionString"]; }
            set { this["OdacConnectionString"] = value; }
        }

        [ConfigurationProperty("MailSettings", IsRequired = false)]
        public EpsMailConfigElement MailSettings
        {
            get { return (EpsMailConfigElement)base["MailSettings"]; }
            set { this["MailSettings"] = value; }
        }
    }
}