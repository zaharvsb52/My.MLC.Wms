using System.Configuration;

namespace MLC.Eps.Config
{
    public class EpsMailConfigElement : ConfigurationElement, IEpsMailConfig
    {
        [ConfigurationProperty("Host", IsRequired = true)]
        public string Host
        {
            get { return ((string)(base["Host"])); }
            set { base["Host"] = value; }
        }

        [ConfigurationProperty("Port", DefaultValue = "25", IsRequired = false)]
        public int Port
        {
            get { return ((int)(base["Port"])); }
            set { base["Port"] = value; }
        }

        [ConfigurationProperty("From", IsRequired = false)]
        public string From
        {
            get { return ((string)(base["From"])); }
            set { base["From"] = value; }
        }

        [ConfigurationProperty("Subject", IsRequired = false)]
        public string Subject
        {
            get { return ((string)(base["Subject"])); }
            set { base["Subject"] = value; }
        }

        [ConfigurationProperty("Password", IsRequired = false)]
        public string Password
        {
            get { return ((string)(base["Password"])); }
            set { base["Password"] = value; }
        }

        [ConfigurationProperty("UserName", IsRequired = false)]
        public string UserName
        {
            get { return ((string)(base["UserName"])); }
            set { base["UserName"] = value; }
        }

        [ConfigurationProperty("Body", IsRequired = false)]
        public string Body
        {
            get { return ((string)(base["Body"])); }
            set { base["Body"] = value; }
        }

        [ConfigurationProperty("MailSignature", IsRequired = false)]
        public string MailSignature
        {
            get { return ((string)(base["MailSignature"])); }
            set { base["MailSignature"] = value; }
        }

        [ConfigurationProperty("IsBodyHtml", IsRequired = false)]
        public bool IsBodyHtml
        {
            get { return ((bool)(base["IsBodyHtml"])); }
            set { base["IsBodyHtml"] = value; }
        }
    }
}