using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MLC.Wms.Bootstrap.Abac;
using MLC.Wms.Bootstrap.Services.Impl;
using MLC.Wms.Common.Services;
using MLC.Wms.Model.Entities;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AutoMapper;
using MLC.Wms.Api;
using MLC.Wms.Bootstrap.Mapping;
using MLC.Wms.Bootstrap.Metamodel;
using MLC.Wms.Common;
using MLC.Wms.Common.DataAccess;
using Unity.Mvc5;
using WebClient.Abac;
using WebClient.Abac.Data.DataAccess.Linq;
using WebClient.Abac.Data.Saving;
using WebClient.Abac.Nh;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.Data.DataAccess.Linq;
using WebClient.Common.Data.Saving;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Metamodel.Impl.Dynamic.Bindings;
using WebClient.Common.Metamodel.Impl.Dynamic.Data;
using WebClient.Common.Metamodel.Impl.Dynamic.MappingEntities;
using WebClient.Common.Metamodel.Impl.Dynamic.Readers;
using WebClient.Common.Metamodel.Impl.Dynamic.Ui;
using WebClient.Common.Metamodel.Impl.Dynamic.Validation;
using WebClient.Common.Metamodel.Ui;
using WebClient.Common.Metamodel.Validation;
using WebClient.Common.Utils;
using WebClient.ExtDirectHandler;
using WebClient.ExtDirectHandler.Extensions;
using WebClient.ExtDirectHandler.Mvc;
using WebClient.Nh;
using WebClient.Nh.DataAccess.Linq;
using WebClient.Nh.MappingByCode;
using WebClient.Nh.Saving;
using WebClient.Unity;

namespace MLC.Wms.Bootstrap
{
    public static class UnityConfig
    {
        public static void RegisterComponents(Action<IUnityContainer> configure = null)
        {
            RegisterComponents(new JsonSerializer(), new DefaultErrorHandler(), configure);
        }

        public static void RegisterComponents(JsonSerializer jsonSerializer, IErrorHandler errorHandler,
            Action<IUnityContainer> configure = null)
        {
            var container = new UnityContainer();
            FillContainer(container, jsonSerializer, errorHandler);

            if (configure != null)
                configure(container);
        }

        public static void FillContainer(IUnityContainer container)
        {
            FillContainer(container, new JsonSerializer(), new DefaultErrorHandler());
        }

        public static void FillContainer(IUnityContainer container, JsonSerializer jsonSerializer,
            IErrorHandler errorHandler)
        {
            container.RegisterInstance(container);
            container.RegisterInstance(jsonSerializer);
            container.RegisterInstance(errorHandler);

            container.RegisterType<HttpContextBase>(
                new InjectionFactory(c => new HttpContextWrapper(HttpContext.Current)));

            SystemServicesUnityConfigurator.Configure((UnityContainer) container);

            ConfigureAutoMapper();

            WithMetadata(
                (policies, entities, cardViewFieldBindings, listViewFieldBindings, lookupViewFieldBindings,
                    referenceFieldBindings) =>
                {
                    var metamodel = new MetamodelBuilder(new PropertyAccessorFactory()).Build(entities);
                    container.RegisterInstance<IMetamodel>(metamodel);

                    var cfg = GetDbConfiguration();
                    var mapping = new WmsMappingBuilder().Build(entities).ToXmlDocument();
                    cfg.AddDocument(mapping);

                    container.RegisterType<ISessionFactory, SessionFactoryDecorator>(
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor(
                            cfg.BuildSessionFactory()));

                    container.RegisterType<ISession>(
                        new HierarchicalLifetimeManager(),
                        new InjectionFactory(u =>
                        {
                            var factory = u.Resolve<ISessionFactory>();
                            return factory.OpenSession();
                        }));

                    container.RegisterType<IQueryableFactoryProvider, NhQueryableFactoryProvider>();
                    container.RegisterType<IUnitOfWorkFactory, NhUnitOfWorkFactory>();

                    // ABAC
                    container.RegisterType<IRootObjectNodeApplier, AbacRootObjectNodeApplier>();
                    container.RegisterType<IEntitiesLoader, AbacEntitiesLoader>(new HierarchicalLifetimeManager());
                    container.RegisterType<IAbacContext, Context>();
                    container.RegisterInstance(typeof (IPolicyEnforcementService),
                        GetPolicyEnforcementService(metamodel, policies));

                    // UI meta
                    var infoProvider = new UiInfoProviderBuilder().Build(metamodel, entities, cardViewFieldBindings,
                        listViewFieldBindings, lookupViewFieldBindings, referenceFieldBindings);
                    container.RegisterInstance<IUiInfoProvider>(infoProvider);

                    // Validators
                    var validatorProvider = new ValidatorsProviderBuilder().Build(entities);
                    container.RegisterInstance<IValidatorsProvider>(validatorProvider);

                    // Bindings
                    container.RegisterType<IEntityBindingsProvider, EntityBindingsProvider>(
                        new ContainerControlledLifetimeManager(),
                        new InjectionConstructor(
                            typeof (IMetamodel),
                            typeof (INamingConventionProvider),
                            cardViewFieldBindings,
                            listViewFieldBindings,
                            lookupViewFieldBindings));
                });

            //WmsXmlConverter
            container.RegisterType<IWmsXmlConverter, WmsXmlConverter>(new ContainerControlledLifetimeManager());

            RegisterAppServices(container);

            InitServiceLocator(container);

            //Добавлен кастомный NamingConventionProvider
            var ncp = new DefaultNamingConventionProvider {ToCamelCase = false};
            container.RegisterInstance<INamingConventionProvider>(ncp);

            var section = (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            if (section != null)
                container.LoadConfiguration(section);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            var objectFactory = new DependencyResolverObjectFactory(DependencyResolver.Current, jsonSerializer,
                errorHandler);
            DirectHttpHandler.SetObjectFactory(objectFactory);

            RegisterKnownTypes();
        }

        #region .  Metadata  .

        private static void WithMetadata(
            Action<IEnumerable<Policy>,
                IEnumerable<Entity>,
                IEnumerable<EntityCardViewFieldBinding>,
                IEnumerable<EntityListViewFieldBinding>,
                IEnumerable<EntityLookupViewFieldBinding>,
                IEnumerable<EntityReferenceFieldBinding>> init)
        {
            var metadataFileName = GetMetamodelFile();
            //var metadataFileName = @".\Metamodel.xml";
            if (string.IsNullOrEmpty(metadataFileName))
                WithDbMetadata(init);
            else
                WithLocalMetadata(metadataFileName, init);
        }

        private static string GetMetamodelFile()
        {
            var fileName = ConfigurationManager.AppSettings["MetadataFileName"];
            if (string.IsNullOrEmpty(fileName))
                return null;

            bool isWebApp = HttpRuntime.AppDomainId != null;
            var rootPath = isWebApp
                ? Path.GetDirectoryName(
                    WebConfigurationManager.OpenWebConfiguration("/").FilePath) + "\\bin"
                : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (string.IsNullOrEmpty(rootPath))
                throw new ConfigurationErrorsException("Can't find web.config path");

            return Path.Combine(rootPath, fileName);
        }

        private static void WithLocalMetadata(string fileName,
            Action
                <IEnumerable<Policy>, IEnumerable<Entity>, IEnumerable<EntityCardViewFieldBinding>,
                    IEnumerable<EntityListViewFieldBinding>, IEnumerable<EntityLookupViewFieldBinding>,
                    IEnumerable<EntityReferenceFieldBinding>> init)
        {
            var persister = new LocalMetadataPersister();
            var dataSet = persister.Load(fileName);
            var builder = new MetamodelDataSetReader(dataSet);
            var propOwners = builder.ReadPropertiesOwners();
            var bindings = builder.ReadBindings();

            var policiesReader = new PolicyDataSetReader(dataSet);
            var policies = policiesReader.ReadPolicies();

            init(policies,
                propOwners.OfType<Entity>(),
                bindings.OfType<EntityCardViewFieldBinding>(),
                bindings.OfType<EntityListViewFieldBinding>(),
                bindings.OfType<EntityLookupViewFieldBinding>(),
                bindings.OfType<EntityReferenceFieldBinding>());
        }

        private static void WithDbMetadata(
            Action
                <IEnumerable<Policy>, IEnumerable<Entity>, IEnumerable<EntityCardViewFieldBinding>,
                    IEnumerable<EntityListViewFieldBinding>, IEnumerable<EntityLookupViewFieldBinding>,
                    IEnumerable<EntityReferenceFieldBinding>> init)
        {
            var entityMappingTypes = typeof (PropertiesOwnerMap).Assembly.GetExportedTypes();
            var abacMappingTypes = typeof (PolicyMap).Assembly.GetExportedTypes();

            var entityMappingMapper = new ModelMapper();
            entityMappingMapper.AddMappings(entityMappingTypes);
            entityMappingMapper.AddMappings(abacMappingTypes);

            var cfg = GetDbConfiguration();
            cfg.AddMapping(entityMappingMapper.CompileMappingForAllExplicitlyAddedEntitiesFixxed(entityMappingTypes));

            using (var factory = cfg.BuildSessionFactory())
            using (var session = factory.OpenSession())
            {
                //var policies = session.Query<Policy>().ToFuture();
                //var entities = session.Query<PropertiesOwner>().FetchMany(po => po.Properties).ToFuture();
                //var cardViewFieldBindings = session.Query<EntityCardViewFieldBinding>().ToFuture();
                //var listViewFieldBindings = session.Query<EntityListViewFieldBinding>().ToFuture();
                //var lookupViewFieldBindings = session.Query<EntityLookupViewFieldBinding>().ToFuture();
                //var refFieldBindings = session.Query<EntityReferenceFieldBinding>().ToList();

                //init(policies, entities.OfType<Entity>(), cardViewFieldBindings, listViewFieldBindings, lookupViewFieldBindings,
                //    refFieldBindings);

                // Задача - вычитать метаданные за меньшее кол-во запросов с максимальной скоростью
                // ниже приведено 2 варианта решения:
                // * большими блоками с явным fetch-ем
                // * малыми блоками с fetch-ем на hibernate
                // По результатам тестов пока быстрее читать малыми блоками

                //var sw = new Stopwatch();
                //sw.Start();

                var policies = session.Query<Policy>().ToFuture();

                /*
                // Вариант 1
                var associations = session.Query<Association>()
                    .Fetch(i => i.RightRole).ThenFetch(i => i.Owner)
                    .Fetch(i => i.LeftRole).ThenFetch(i => i.Owner)
                    .ToList();
                var entities = session.Query<Entity>()
                    .FetchMany(po => po.Properties).ThenFetchMany(i => i.Validators)
                    .FetchMany(i => i.JoinTables).ThenFetch(i => i.JoinToEntity)
                    .ToList();
                 */

                // Вариант 2
                var subselects =
                    session.Query<SubselectEntity>().FetchMany(i => i.Properties).FetchMany(i => i.SyncTables).ToList();
                var entities = session.Query<TableEntity>().FetchMany(i => i.JoinTables).ToList();
                var associations = session.Query<Association>().Fetch(i => i.RightRole).Fetch(i => i.LeftRole).ToList();
                var propsWithValidators = session.Query<Property>().FetchMany(i => i.Validators).ToList();
                var propertiesOwners = session.Query<PropertiesOwner>().FetchMany(i => i.Properties).ToList();
                var bindings = session.Query<EntityPropertyBinding>().ToList();

                init(policies, propertiesOwners.OfType<Entity>(),
                    bindings.OfType<EntityCardViewFieldBinding>(),
                    bindings.OfType<EntityListViewFieldBinding>(),
                    bindings.OfType<EntityLookupViewFieldBinding>(),
                    bindings.OfType<EntityReferenceFieldBinding>());
            }
        }

        #endregion

        public static void ConfigureAutoMapper()
        {
            var profiles = typeof(WmsTEMappingProfile).Assembly.GetTypes()
                .Where(t => t.Namespace == typeof(WmsTEMappingProfile).Namespace
                            && typeof(Profile).IsAssignableFrom(t)
                            && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>()
                .ToList();

            // Initialize AutoMapper with each instance of the profiles found.
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;

                profiles.ForEach(cfg.AddProfile);
            });
        }

        private static void RegisterKnownTypes()
        {
            var knownTypes = new List<Type>();
            // добавляем бизнес сущности
            var modelAssemply = Assembly.GetAssembly(typeof (BaseEntity));
            var entitiesTypes = modelAssemply.ExportedTypes.Where(i => i.IsSubclassOf(typeof (BaseEntity))).ToArray();
            knownTypes.AddRange(entitiesTypes);
            knownTypes.AddRange(entitiesTypes.Select(i => i.MakeArrayType()));
            // могут передаваться массивы стандартных типов
            var standartTypes = new[]
            {
                typeof (bool), typeof (byte), typeof (char), typeof (decimal), typeof (double), typeof (float),
                typeof (int), typeof (long), typeof (sbyte), typeof (short), typeof (uint), typeof (ulong),
                typeof (ushort),
                typeof (Guid), typeof (String)
            };
            knownTypes.AddRange(standartTypes.Select(i => i.MakeArrayType()));

            // добавляем сущности Workflow
            knownTypes.Add(typeof (WorkflowIdentity));
            knownTypes.Add(typeof (WorkflowIdentity[]));

            // регистрируем
            //KnownTypesProvider.RegisterKnownTypes(knownTypes);
        }

        private static void InitServiceLocator(IUnityContainer container)
        {
            var locator = new DependencyResolverServiceLocator();
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        private static void RegisterAppServices(IUnityContainer container)
        {
            container.RegisterType<IAuthService, AuthService>(new HierarchicalLifetimeManager());
        }

        private static NHibernate.Cfg.Configuration GetDbConfiguration()
        {
            return new NHibernate.Cfg.Configuration().Configure();
        }

        private static IPolicyEnforcementService GetPolicyEnforcementService(IMetamodel metamodel,
            IEnumerable<Policy> policies)
        {
            var pes = new PolicyEnforcementService(metamodel);

            foreach (var policy in policies)
            {
                pes.AddPolicy(policy.Name, policy.Expression, policy.UserType, policy.ResourceType,
                    policy.EnvironmentType);
            }

            return pes;
        }
    }
}