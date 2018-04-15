using System.Linq;
using MLC.Wms.Model.Entities;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Protocol.DataTransferObjects.Metadata;
using WebClient.Common.Client.Querying;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.Iwb2CargoBinding
{
    public class IwbGridStructureDataProvider : TypedAutoGridStructureDataProvider<WmsIWB>
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public IwbGridStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntityBindingsProvider entityBindingsProvider,
            JsStructureEnricher jsStructureEnricher,
            IEntitiesLoader entitiesLoader,
            BindingsCreator bindingsCreator)
            : base(metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher, entitiesLoader)
        {
            _entitiesLoader = entitiesLoader;
            _jsStructureEnricher = jsStructureEnricher;
            _bindingsCreator = bindingsCreator;
            SetEntityType(typeof(WmsIWB));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator.With<WmsIWB>()
                .CreateOrReplaceHidden(i => i.IWBID)
                .CreateOrReplace(i => i.IWBName)
                .CreateOrReplace(i => i.IWBCMRNumber)
                .CreateOrReplace(i => i.IWBCMRDate)
                //TODO: iwbPos.TTN .CreateOrReplace(i => i.IWBID)
                //TODO: iwbPos.TTN2 .CreateOrReplace(i => i.IWBID)
                //TODO: cargoIwb.id list .CreateOrReplace(i => i.WmsCargoIWB_List)
                .List();
        }

        protected override string GetStructureName()
        {
            return "NotBindedIwbGrid";
        }

        protected override string GetTitle()
        {
            return _jsStructureEnricher.GetEntityGridTitle(EntityDescriptor.EntityType);
        }

        protected override JsStructure GetJsStructure()
        {
            var s = base.GetJsStructure();
            _jsStructureEnricher.EnrichGridStructure(s, EntityDescriptor.EntityType, Bindings);

            foreach (var f in s.Fields)
                f.Persist = new[]
                {
                    "IWBCMRNumber",
                    "IWBCMRDate"
                }
                .Contains(f.Name);

            return s;
        }

        public override JsStoreData LoadList(ILoadListQuery loadListQuery)
        {
            var noPageLimitLoadListQuery = new LoadListQuery(loadListQuery.RecordStructure, loadListQuery.Conditions, loadListQuery.SortItems, new Page(0, 1000));
            var res = base.LoadList(noPageLimitLoadListQuery);
            return res;
        }
    }
}