using MLC.Wms.Model.Entities;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Metamodel.Impl.Dynamic.Bindings;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms.StructureDataProviders
{
    public class CstReqCustomsPosDataProvider : TypedAutoGridStructureDataProvider<CstReqCustomsPos>
    {
            private readonly BindingsCreator _bindingsCreator;

            public CstReqCustomsPosDataProvider(IMetamodel metamodel,
                FieldsByBindingsFactory fieldsByBindingsFactory,
                JsStructureFactory jsStructureFactory,
                IEntitiesLoader entitiesLoader,
                JsStructureEnricher jsStructureEnricher,
                BindingsCreator bindingsCreator,
                EntityBindingsProvider entityBindingsProvider)
                : base(metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher, entitiesLoader)
            {
                _bindingsCreator = bindingsCreator;

                SetEntityType(typeof(CstReqCustomsPos));
            }

            protected override IFieldBinding[] GetBindings()
            {
                return _bindingsCreator
                    .With<CstReqCustomsPos>()
                    .CreateOrReplaceForGrid()
                    .CreateOrReplaceHidden(i => i.ReqCustoms)
                    .List();
            }
        }
    }