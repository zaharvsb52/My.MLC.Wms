using System.Collections.Generic;
using System.Configuration;
using System.Net.Http.Formatting;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using MLC.Eps.Config;
using MLC.Eps.ExportFormat;
using MLC.Eps.ExportFormat.Impl;
using MLC.Eps.Impl;
using MLC.Eps.Server;
using MLC.Eps.WebApi;
using MLC.Eps.WebApi.Middleware;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MLC.Eps.WebApi
{
    public class Startup
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(Startup));

        public void Configuration(IAppBuilder app)
        {
            // configure log4net
            XmlConfigurator.Configure();
            _log.DebugFormat("Application starting...");

            // build httpConfig
            var config = BuildHttpConfiguration();
            WebApiConfig.Register(config);

            // configure OWIN
            //app.UseBasicAuthentication("", BasicAuth);
            ConfigureErrorHandling(app);
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

            UnityConfig.RegisterComponents(container =>
            {
                LocalConfigure(container);
                config.DependencyResolver = new UnityDependencyResolver(container);
            });

            _log.DebugFormat("Application started");
        }

        private static void LocalConfigure(IUnityContainer container)
        {
            InitEps(container);

            // инициализируем Environment
            container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<ILocalData, WebLocalData>(new ContainerControlledLifetimeManager());
            WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());
        }

        private static void InitEps(IUnityContainer container)
        {
            var config = (EpsConfigSection) ConfigurationManager.GetSection(EpsConfigSection.DefaultSectionName);

            // регистрируем нужное
            container.RegisterInstance<IEpsConfiguration>(config);
            container.RegisterInstance<IEpsMailConfig>(config.MailSettings);
            container.RegisterType<IEpsJobFactory, EpsJobFactory>();
            container.RegisterType<IEpsTaskFactory, EpsTaskFactory>();
            container.RegisterType<IEpsReportFactory, EpsReportFactory>();
            container.RegisterType<IReportExporterFactory, ReportExporterFactory>();
            container.RegisterType<IMacroProcessor, MacroProcessor>(new PerResolveLifetimeManager());
            container.RegisterType<IEpsOutputExecutor, EpsOutputExecutor>();
        }

        private static HttpConfiguration BuildHttpConfiguration()
        {
            var config = new HttpConfiguration();
            config.Formatters.Insert(0, new JsonMediaTypeFormatter());
            return config;
        }

        private static void ConfigureErrorHandling(IAppBuilder app)
        {
            app.Use<CustomExceptionMiddleware>();
        }

        private static Task<IEnumerable<Claim>> BasicAuth(string id, string secret)
        {
            List<Claim> list = null;
            if (id == secret)
            {
                list = new List<Claim>();
                list.Add(new Claim(ClaimTypes.Name, id));
            }

            return Task.FromResult<IEnumerable<Claim>>(list);
        }
    }

}