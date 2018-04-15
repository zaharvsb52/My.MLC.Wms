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

namespace MLC.Wms.WebApp.DataServices.PassRequest
{
    public class PassRequestListStructureDataProvider : AutoStructureDataProvider, IListDataLoader
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public PassRequestListStructureDataProvider(IMetamodel metamodel,
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

            SetEntityType(typeof(YPassRequest));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator
                .With<YPassRequest>()
                .CreateOrReplaceForGrid()
                .CreateOrReplaceHidden(i => i.PassRequestID)
                .Remove(i => i.Transact)
                .Remove(i => i.UserIns)
                .Remove(i => i.UserUpd)
                .Remove(i => i.DateIns)
                .Remove(i => i.DateUpd)
                .Remove(i => i.WorkerPassNumber)
                .Remove(i => i.WorkerPass)
                .Remove(i => i.WorkerFio)
                .Remove(i => i.Worker)
                .Remove(i => i.Vehicle)
                .Remove(i => i.PhoneNumber)
                .Remove(i => i.ArrivalDatePlan)
                .Remove(i => i.PassNumber)
                .Remove(i => i.VehicleNumber)
                .Remove(i => i.State)
                .List();
        }

        protected override string GetStructureName()
        {
            return "YPassRequestList";
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

        public JsStoreData LoadList(ILoadListQuery query)
        {
            var dataPage = _entitiesLoader.LoadList(EntityDescriptor.EntityType,
                Bindings,
                query.SortItems,
                query.Conditions.OfType<IFieldValueCondition>(),
                query.Page,
                true);

            return TableSerializer.Serialize(dataPage.Data, dataPage.Count);
        }
    }
}