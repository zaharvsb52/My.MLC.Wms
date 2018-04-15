using System.Linq;
using MLC.Wms.Model.Entities;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Protocol.DataTransferObjects.Metadata;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Server.Bindings;
using WebClient.Common.Types;

namespace MLC.Wms.WebApp.DataServices.ExternalTrafficCreate
{
    public class ExternalTrafficCreateStructureDataProvider : AutoStructureDataProvider, ICardDataLoader
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public ExternalTrafficCreateStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntitiesLoader entitiesLoader,
            JsStructureEnricher jsStructureEnricher,
            BindingsCreator bindingsCreator)
            : base(metamodel, fieldsByBindingsFactory, jsStructureFactory)
        {
            _entitiesLoader = entitiesLoader;
            _jsStructureEnricher = jsStructureEnricher;
            _bindingsCreator = bindingsCreator;

            SetEntityType(typeof (YExternalTraffic));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator.With<YExternalTraffic>()
                .CreateOrReplace(i => i.ExternalTrafficID)
                .CreateOrReplace(i => i.ExternalTrafficDriver)
                .CreateOrReplace(i => i.ExternalTrafficDriver.WorkerPhoneMobile)
                .CreateOrReplace(i => i.ExternalTrafficPlanArrived)
                .CreateOrReplace(i => i.ExternalTrafficDriver.WorkerPhoto)
                .CreateOrReplace(i => i.Vehicle)
                .CreateOrReplace(i => i.ExternalTrafficForvarder)
                .CreateOrReplace(i => i.ExternalTrafficCarrier)
                .List();
        }

        protected override string GetStructureName()
        {
            return "ExternalTrafficCard";
        }

        protected override string GetTitle()
        {
            return _jsStructureEnricher.GetEntityCardTitleFormat(EntityDescriptor.EntityType);
        }

        protected override JsStructure GetJsStructure()
        {
            var s = base.GetJsStructure();
            _jsStructureEnricher.EnrichCardStructure(s, EntityDescriptor.EntityType, Bindings);

            foreach (var f in s.Fields)
                f.Persist = IsPersistField(f);

            return s;
        }

        private static bool IsPersistField(JsField f)
        {
            return (new[]
            {
                "ExternalTrafficDriver",
                "ExternalTrafficDriver_WorkerPhoneMobile",
                "ExternalTrafficPlanArrived",
                "ExternalTrafficDriver_WorkerPhoto",
                "Vehicle",
                "ExternalTrafficForvarder",
                "ExternalTrafficCarrier"
            })
                .Contains(f.Name);
        }

        public JsStoreData LoadCard(EntityId entityId)
        {
            var source = _entitiesLoader.LoadCard(entityId, Bindings);
            return TableSerializer.Serialize(source, 1);
        }
    }
}