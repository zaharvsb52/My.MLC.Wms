using FastReport.Data;
using FastReport.Utils;
using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.Helpers;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.WebApp.Common;
using MLC.Wms.Workflows;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using StackExchange.Profiling;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebClient.ExtDirectHandler.Extensions;
using WebClient.Web;

namespace MLC.Wms.WebApp
{
    public class MvcApplication : WebClientHttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));

        private static readonly Lazy<string> _lazyProductVersion =
            new Lazy<string>(
                () =>
                    FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(MvcApplication)).Location)
                        .ProductVersion);

        public static string ProductVersion
        {
            get { return _lazyProductVersion.Value; }
        }

        protected override IErrorHandler BuildErrorHandler()
        {
            return new LoggingDirectErrorHandler();
        }

        protected override void Application_Start(object sender, EventArgs e)
        {
            try
            {
                base.Application_Start(sender, e);

                XmlConfigurator.Configure();

                AreaRegistration.RegisterAllAreas();
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                UnityConfig.RegisterComponents(JsonSerializer, ErrorHandler, Configure);
            }
            catch (Exception ex)
            {
                Log.Error("Unhandled exception", ex);
                throw;
            }
        }

        private static void Configure(IUnityContainer container)
        {
            // инициализируем Environment
            container.RegisterType<IWmsEnvironmentInfoProvider, WebWmsEnvironmentInfoProvider>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<ILocalData, WebLocalData>(new ContainerControlledLifetimeManager());
            WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

            // запускаем wf
            WorkflowServicesUnityConfigurator.Configure(container, true);

            // настраиваем fr
            FastReport.Utils.Config.WebMode = true;
            RegisteredObjects.AddConnection(typeof(OracleDataConnection));
        }

        protected override void Application_BeginRequest(object sender, EventArgs e)
        {

            if (AppSettings.EnableMiniProfiler.ToUpperInvariant() == "TRUE"
                //если запрос идет от signalr, его не нужно отслеживать MiniProfiler
                && !((HttpApplication)sender).Request.Path.Contains("signalr"))
            {
                MiniProfiler.Start();
            }
            
            base.Application_BeginRequest(sender, e);
            // для целей логирования
            HttpContext.Current.Items["requestId"] = StringHelper.RandomString(6);

            // get worker cookie
            if (Request.Cookies["WorkerID"] == null) return;

            WmsEnvironment.LocalData.SetValueFor("WorkerID", Request.Cookies["WorkerID"].Value);
        }

        protected void Application_EndRequest()
        {
            //если запрос идет от signalr, его не нужно отслеживать MiniProfiler
            if (HttpContext.Current.Request.Path.Contains("signalr")) return;
            
            HttpContext.Current.Response.Headers["Access-Control-Expose-Headers"] = "X-MiniProfiler-Ids";
            HttpContext.Current.Response.Headers["Access-Control-Allow-Origin"] = "*";
            MiniProfiler.Stop();
        }

        protected override void Application_Error(object sender, EventArgs e)
        {
            base.Application_Error(sender, e);
            Log.Error("Unhandled exception", Server.GetLastError());
        }

        protected override JsonSerializer BuildJsonSerializer()
        {
            var ser = base.BuildJsonSerializer();
            ser.ContractResolver = new DefaultContractResolver();
            ser.Converters.Insert(0, new StringEnumConverter());
            return ser;
        }
    }
}