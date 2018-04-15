using MLC.Wms.Model.Entities;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Metamodel.Impl.Dynamic.Bindings;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms.StructureDataProviders
{
    public class CstReqCustoms2WBStructureDataProvider : TypedAutoGridStructureDataProvider<CstReqCustoms2WB>
    {
        private readonly BindingsCreator _bindingsCreator;

        public CstReqCustoms2WBStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntitiesLoader entitiesLoader,
            JsStructureEnricher jsStructureEnricher,
            BindingsCreator bindingsCreator,
            EntityBindingsProvider entityBindingsProvider)
            : base(metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher, entitiesLoader)
        {
            _bindingsCreator = bindingsCreator;

            SetEntityType(typeof(CstReqCustoms2WB));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator
                .With<CstReqCustoms2WB>()
                .CreateOrReplaceForGrid()
                .Remove(i => i.DateIns)
                .Remove(i => i.Transact)
                .Remove(i => i.UserIns)
                .Remove(i => i.UserUpd)
                .Remove(i => i.DateUpd)
                .CreateOrReplaceHidden(i => i.ReqCustoms)
                .CreateOrReplaceHidden(i => i.ReqCustoms2WBId)
                .CreateOrReplaceHidden(i => i.IWB)
                .CreateOrReplaceHidden(i => i.OWB)
                .List();
        }
    }
}