using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using log4net;

namespace MLC.Eps.WebApi.Services
{
    public class CustomHttpControllerSelector : DefaultHttpControllerSelector
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CustomHttpControllerSelector));

        public CustomHttpControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        public override string GetControllerName(HttpRequestMessage request)
        {
            var res = base.GetControllerName(request);
            _log.Debug($"Request uri: '{request.RequestUri}'; Controller: '{res}'");
            return res;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var res = base.SelectController(request);
            _log.Debug($"Request uri: '{request.RequestUri}'; Controller type: '{res.ControllerType}'");
            return res;
        }
    }
}