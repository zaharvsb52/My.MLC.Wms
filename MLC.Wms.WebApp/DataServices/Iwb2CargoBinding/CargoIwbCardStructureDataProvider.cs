using MLC.Wms.Model.Entities;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.Iwb2CargoBinding
{
    public class CargoIwbCardStructureDataProvider : TypedAutoCardStructureDataProvider<WmsCargoIWB>
    {
        public CargoIwbCardStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntityBindingsProvider entityBindingsProvider,
            JsStructureEnricher jsStructureEnricher,
            IEntitiesLoader entitiesLoader)
            : base(
                metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher,
                entitiesLoader)
        {
            SetEntityType(typeof(WmsCargoIWB));
        }
    }
}