using System.Web;
using WebClient.ExtDirectHandler;

namespace MLC.Wms.WebApp.Common
{
    public class CustomDirectHttpHandler : StubDirectHttpHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            if (!context.Request.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                context.Response.End();
                return;
            }

            base.ProcessRequest(context);
        }
    }

    public class StubDirectHttpHandler : DirectHttpHandler, IHttpHandler
    {
        public new virtual void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
        }
    }
}