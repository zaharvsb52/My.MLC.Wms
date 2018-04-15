using MLC.Wms.Model.Entities;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Metamodel.Impl.Dynamic.Bindings;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms.StructureDataProviders
{
    public class TransportDocumentStructureDataProvider : TypedAutoGridStructureDataProvider<CstTransportDocument>
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public TransportDocumentStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntitiesLoader entitiesLoader,
            JsStructureEnricher jsStructureEnricher,
            BindingsCreator bindingsCreator,
            EntityBindingsProvider entityBindingsProvider)
            : base(metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher, entitiesLoader)
        {
            _bindingsCreator = bindingsCreator;

            SetEntityType(typeof(CstTransportDocument));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator
                .With<CstTransportDocument>()
                .CreateOrReplaceForGrid()
                .Remove(i => i.DateIns)
                .CreateOrReplaceHidden(i => i.TransportDocumentId)
                .Remove(i => i.Transact)
                .Remove(i => i.UserIns)
                .Remove(i => i.UserUpd)
                .Remove(i => i.DateUpd)
                .CreateOrReplaceHidden(i => i.ReqCustoms)
                .List();
        }
    }
}