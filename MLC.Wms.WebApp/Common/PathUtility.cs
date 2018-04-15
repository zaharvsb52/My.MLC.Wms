using System.Web.Configuration;

namespace MLC.Wms.WebApp.Common
{
    public class PathUtility
    {
        private const string PathKey = "MLC.Wms.WebApp.Version";
#if PACKAGE
     private static readonly string DefaultPath = "~/Resources/app-" + System.Diagnostics.FileVersionInfo.GetVersionInfo(typeof(PathUtility).Assembly.Location).FileVersion;
#else
        private static readonly string DefaultPath = "~/Resources/app";
#endif

        public string CommonResourcesPath
        {
            get
            {
                var ret = WebConfigurationManager.AppSettings[PathKey];
                return string.IsNullOrEmpty(ret) ? DefaultPath : ret;
            }
        }

        public string CommonScriptsPath
        {
            get { return CommonResourcesPath + "/scripts"; }
        }

        public string CommonStylesPath
        {
            get { return CommonResourcesPath + "/styles"; }
        }

        public string CommonImagesPath
        {
            get { return CommonResourcesPath + "/images"; }
        }

        public string CommonFontsPath
        {
            get { return CommonResourcesPath + "/fonts"; }
        }

        public static readonly PathUtility Singleton = new PathUtility();

        protected PathUtility()
        {
        }
    }
}