using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

// This is to specify OWIN Startup Class
[assembly: OwinStartup(typeof(MLC.Wms.WebApp.Startup))]
namespace MLC.Wms.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };
            app.MapSignalR(hubConfiguration);
        }
    }
}
