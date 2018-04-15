using System;
using System.Activities.DurableInstancing;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.DurableInstancing;
using Microsoft.Practices.Unity;
using MLC.WF.Core;
using MLC.WF.Core.Common;
using MLC.WF.Core.Common.Impl;
using MLC.WF.Core.Models;

namespace MLC.Wms.Workflows
{
    /// <summary> Класс для регистрации в UnityContainer системных сервисов. </summary>
    public static class WorkflowServicesUnityConfigurator
    {
        /// <summary> Регистрация сервисов. </summary>
        public static void Configure(IUnityContainer container, bool isInstanceStoreEnabled)
        {
            // инициализируем библиотеку
            MLC.WF.Core.UnityConfig.Configure(container);

            InitKnownTypeProvider(container);

            container.RegisterType<IWorkflowChildContainerConfigurator, ChildContainerConfigurator>();
            container.RegisterType<IWorkflowStorage, WorkflowStorage>(new ContainerControlledLifetimeManager());
            container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(), new InjectionFactory(
                c =>
                {
                    var wfPath = ConfigurationManager.AppSettings["WF_XAML_PATH"];
                    if (string.IsNullOrEmpty(wfPath) || !Path.IsPathRooted(wfPath))
                    {
                        bool isWebApp = System.Web.HttpRuntime.AppDomainId != null;
                        var rootPath = isWebApp
                            ? System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/").FilePath
                            : System.Reflection.Assembly.GetExecutingAssembly().Location;
                        rootPath = Path.GetDirectoryName(rootPath);
                        if (string.IsNullOrEmpty(rootPath))
                            throw new ConfigurationErrorsException("Can't find web.config path");

                        wfPath = string.IsNullOrEmpty(wfPath)
                            ? rootPath
                            : Path.Combine(rootPath, wfPath);
                    }
                    return new FileWorkflowLoader(wfPath, true);
                }));

            if (isInstanceStoreEnabled)
            {
                container.RegisterType<InstanceStore>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => InitializeWorkflowInstanceStore()));
                container.RegisterType<IWorkflowApplicationFactory, WorkflowApplicationFactory>();
            }
            else
            {
                container.RegisterType<IWorkflowApplicationFactory, WorkflowApplicationFactory>(new InjectionConstructor(new InjectionParameter<InstanceStore>(null), typeof(IWorkflowStorage)));
            }

            var webClientSvc = container.Resolve<WebClientWorkflowService>();
            container.RegisterInstance<IWebClientWorkflowService>(webClientSvc, new ContainerControlledLifetimeManager());
            //container.RegisterType<IWebClientWorkflowService, WebClientWorkflowService>(new ContainerControlledLifetimeManager());

            //var wfSvc = container.Resolve<WebClientWorkflowService>();
            container.RegisterInstance<IWorkflowService>(webClientSvc, new ContainerControlledLifetimeManager());
            //container.RegisterType<IWorkflowService, WebClientWorkflowService>(new ContainerControlledLifetimeManager());
        }

        internal static InstanceStore InitializeWorkflowInstanceStore()
        {
            //return new XmlWorkflowInstanceStore();

            string connectionString = ConfigurationManager.ConnectionStrings["wf"].ConnectionString;
            var store = new SqlWorkflowInstanceStore(connectionString);

            //TODO: выставить после отладки
            //store.InstanceEncodingOption = InstanceEncodingOption.GZip;

            // про настройки тут: https://msdn.microsoft.com/ru-ru/library/ee395770(v=vs.110).aspx
            store.InstanceLockedExceptionAction = InstanceLockedExceptionAction.AggressiveRetry;
            store.InstanceCompletionAction = InstanceCompletionAction.DeleteAll;
            store.HostLockRenewalPeriod = new TimeSpan(0, 0, 5);
            store.RunnableInstancesDetectionPeriod = new TimeSpan(0, 0, 10);

            InstanceHandle handle = null;
            try
            {
                handle = store.CreateInstanceHandle();
                var view = store.Execute(handle, new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(5));
                store.DefaultInstanceOwner = view.InstanceOwner;
            }
            finally
            {
                if (handle != null)
                    handle.Free();
            }
            return store;
        }

        internal static void InitKnownTypeProvider(IUnityContainer container)
        {
            var knownTypes = new List<Type>();
            // добавляем модели
            var rootType = typeof(WfStructure);
            var modelAssemply = Assembly.GetAssembly(rootType);
            var entitiesTypes = modelAssemply.ExportedTypes
                .Where(i => i.Namespace == rootType.Namespace
                            && i.GetCustomAttribute<SerializableAttribute>() != null)
                .ToArray();
            knownTypes.AddRange(entitiesTypes);
            //knownTypes.AddRange(entitiesTypes.Select(i => i.MakeArrayType()));

            //var prov = container.Resolve<WfKnownTypeProvider>();
            WfKnownTypeProvider.RegisterKnownTypes(knownTypes);
            //container.RegisterInstance<IWfKnownTypeProvider>(prov, new ContainerControlledLifetimeManager());
        }
    }
}