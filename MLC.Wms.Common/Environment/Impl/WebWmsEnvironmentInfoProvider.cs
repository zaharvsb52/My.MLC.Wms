using System.Web;

namespace MLC.Wms.Common.Environment.Impl
{
    public class WebWmsEnvironmentInfoProvider : IWmsEnvironmentInfoProvider
    {
        public string UserName
        {
            get
            {
                return HttpContext.Current.User == null ? null : HttpContext.Current.User.Identity.Name;
            }
        }
    }
}