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

namespace MLC.Wms.WebApp.DataServices.Worker
{
    public class WorkerCardStructureDataProvider : AutoStructureDataProvider, ICardDataLoader
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public WorkerCardStructureDataProvider(IMetamodel metamodel,
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

            SetEntityType(typeof(WmsWorker));
        }

        protected override string GetStructureName()
        {
            return "WmsWorkerCard";
        }

        protected override string GetTitle()
        {
            return _jsStructureEnricher.GetEntityCardTitleFormat(EntityDescriptor.EntityType);
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator.With<WmsWorker>()
                .CreateOrReplaceForCard()
                .List();
        }

        protected override JsStructure GetJsStructure()
        {
            var s = base.GetJsStructure();
            _jsStructureEnricher.EnrichCardStructure(s, EntityDescriptor.EntityType, Bindings);
            return s;
        }

        public JsStoreData LoadCard(EntityId entityId)
        {
            var source = _entitiesLoader.LoadCard(entityId, Bindings);
            return TableSerializer.Serialize(source, 1);
        }
    }
}