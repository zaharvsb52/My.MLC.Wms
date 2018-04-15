using System.Linq;
using MLC.Wms.Model.Entities;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Protocol.DataTransferObjects.Metadata;
using WebClient.Common.Client.Querying;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.ExternalTrafficCreate
{
    public class InternalTrafficCreateStructureDataProvider : AutoStructureDataProvider, IListDataLoader
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public InternalTrafficCreateStructureDataProvider(IMetamodel metamodel,
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

            SetEntityType(typeof (YInternalTraffic));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator
                .With<YInternalTraffic>()
                .CreateOrReplaceForGrid()
                .Remove(i => i.DateIns)
                .CreateOrReplaceHidden(i => i.InternalTrafficID)
                .Remove(i => i.Transact)
                .Remove(i => i.UserIns)
                .Remove(i => i.UserUpd)
                .Remove(i => i.DateUpd)
                .Remove(i => i.ExternalTraffic)
                .Remove(i => i.Status)
                .Remove(i => i.Gate)
                .Remove(i => i.InternalTrafficFactArrived)
                .Remove(i => i.InternalTrafficFactDeparted)
                .CreateOrReplaceHidden(i => i.ExternalTraffic)
                .List();
        }

        protected override string GetStructureName()
        {
            return "InternalTrafficCreateList";
        }

        protected override string GetTitle()
        {
            return _jsStructureEnricher.GetEntityGridTitle(EntityDescriptor.EntityType);
        }

        protected override JsStructure GetJsStructure()
        {
            var s = base.GetJsStructure();
            _jsStructureEnricher.EnrichGridStructure(s, EntityDescriptor.EntityType, Bindings);
            return s;
        }

        public JsStoreData LoadList(ILoadListQuery loadListQuery)
        {
            var dataPage = _entitiesLoader.LoadList(EntityDescriptor.EntityType,
                Bindings,
                loadListQuery.SortItems,
                loadListQuery.Conditions.OfType<IFieldValueCondition>(),
                loadListQuery.Page,
                true);

            return TableSerializer.Serialize(dataPage.Data, dataPage.Count);
        }
    }
}