using System;
using System.Linq;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.Client.Model;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Protocol.DataTransferObjects.Metadata;
using WebClient.Common.Client.Querying;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.Data.DataAccess.Linq;
using WebClient.Common.DataServices.DataProviders;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Server.Bindings;
using WebClient.Common.Types;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms.WF.WBGrid
{
    public class OwbGridStructureDataProvider : EntityStructureDataProvider, IListDataLoader
    {
        private readonly FieldsByBindingsFactory _fieldsByBindingsFactory;
        private readonly JsStructureFactory _jsStructureFactory;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        private readonly LinqQueryBuilder _linqQueryBuilder;
        private readonly ISessionFactory _sessionFactory;
        private readonly IDataTableByBindingsFactory _dataTableByBindingsFactory;
        private readonly IBindingDataTableFiller _bindingDataTableFiller;


        public OwbGridStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IDataTableByBindingsFactory dataTableByBindingsFactory,
            IBindingDataTableFiller bindingDataTableFiller,
            JsStructureEnricher jsStructureEnricher,
            BindingsCreator bindingsCreator,
            LinqQueryBuilder linqQueryBuilder,
            ISessionFactory sessionFactory)
            : base(metamodel)
        {
            _fieldsByBindingsFactory = fieldsByBindingsFactory;
            _jsStructureFactory = jsStructureFactory;
            _dataTableByBindingsFactory = dataTableByBindingsFactory;
            _bindingDataTableFiller = bindingDataTableFiller;
            _jsStructureEnricher = jsStructureEnricher;
            _bindingsCreator = bindingsCreator;
            _linqQueryBuilder = linqQueryBuilder;
            _sessionFactory = sessionFactory;

            SetEntityType(typeof(WmsOWB));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator
                .With<WmsOWB>()
                .CreateOrReplaceForGrid()
                .List();
        }

        protected override IRecordStructure GetStructure()
        {
            var dataFields = _fieldsByBindingsFactory.CreateDataFields(Bindings);
            var filterFields = dataFields.Union(new[] { new Field("WBType", typeof(string)), new Field("MandantID", typeof(EntityReference)) });
            var pkFieldBinding =
                Bindings.FirstOrDefault(b => b.PropertyExpression == EntityDescriptor.IdPropertyDescriptor.Name);
            var recordStructure = (IRecordStructure)new RecordStructure("SelectOWB", pkFieldBinding != null ? pkFieldBinding.FieldName : null, dataFields, filterFields, dataFields);
            return recordStructure;
        }

        protected override JsStructure GetJsStructure()
        {
            var jsStructure = _jsStructureFactory.CreateJsStructure(RecordStructure, EntityDescriptor.EntityType,
                _jsStructureEnricher.GetEntityGridTitle(EntityDescriptor.EntityType));
            _jsStructureEnricher.EnrichGridStructure(jsStructure, EntityDescriptor.EntityType, Bindings);
            return jsStructure;
        }

        public JsStoreData LoadList(ILoadListQuery clientQuery)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var query = session.Query<WmsOWB>().Where(i => !session.Query<CstReqCustoms2WB>().Any(j => j.OWB.OWBID == i.OWBID));

                var mandantIDField = clientQuery.Conditions.OfType<IFieldValueCondition>().SingleOrDefault(f => f.Field.Name == "MandantID");
                if (mandantIDField != null)
                {
                    var mandantEntityID = (EntityReference)mandantIDField.Value.Single();
                    var mandantID = mandantEntityID.GetConvertedId<Int32>(); ;
                    query = query.Where(i => i.Partner.PartnerID == mandantID);
                }
                else
                {
                    query = query.Where(i => 1 == 0);
                }

                query = (IQueryable<WmsOWB>)_linqQueryBuilder.ApplyConditions(query, clientQuery.Conditions.OfType<IFieldValueCondition>(), Bindings);
                var count = _linqQueryBuilder.Count(query);

                query = (IQueryable<WmsOWB>)_linqQueryBuilder.ApplySorting(query, clientQuery.SortItems, Bindings);
                if (clientQuery.Page.IsDefined)
                    query = (IQueryable<WmsOWB>)_linqQueryBuilder.ApplyPaging(query, clientQuery.Page.StartRow, clientQuery.Page.Size);

                var dynamicQuery = _linqQueryBuilder.ApplyProjection(query, Bindings);
                var listObj = _linqQueryBuilder.List(dynamicQuery);

                var dataTable = _dataTableByBindingsFactory.CreateDataTable(Bindings);
                _bindingDataTableFiller.FillTableFromList(dataTable, listObj, Bindings);

                var dataPage = new DataPage(dataTable, count);
                return TableSerializer.Serialize(dataPage.Data, dataPage.Count);
            }
        }
    }
}