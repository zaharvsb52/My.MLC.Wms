using MLC.Wms.Model.Entities;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Querying;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.Iwb2CargoBinding
{
    public class Iwb2CargoGridStructureDataProvider : TypedAutoGridStructureDataProvider<WmsIWB>
    {
        public Iwb2CargoGridStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntityBindingsProvider entityBindingsProvider,
            JsStructureEnricher jsStructureEnricher,
            IEntitiesLoader entitiesLoader)
            : base(
                metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher,
                entitiesLoader)
        {
            SetEntityType(typeof(WmsIWB));
        }

        protected override string GetStructureName()
        {
            //return EntityDescriptor.EntityType + "List";
            return "BindedIwbGrid";
        }

        public override JsStoreData LoadList(ILoadListQuery loadListQuery)
        {
            return base.LoadList(loadListQuery);
        }
    }
}