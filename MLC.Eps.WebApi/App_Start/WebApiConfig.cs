using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using MLC.Eps.WebApi.Services;
using Newtonsoft.Json.Serialization;

namespace MLC.Eps.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "v1",
                routeTemplate: "v1/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // добавляем своего ActionSelector-а для возможности отладки (без него оч. трудно искать почему не работает route)
            //config.Services.Replace(typeof(IHttpActionSelector), new CustomApiControllerActionSelector());
            //config.Services.Replace(typeof(IHttpControllerSelector), new CustomHttpControllerSelector(config));
        }
    }
}
