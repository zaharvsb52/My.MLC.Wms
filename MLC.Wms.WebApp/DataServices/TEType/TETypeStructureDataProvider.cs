using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using MLC.WF.Core.Models;
using MLC.Wms.Model.Entities;
using WebClient.Common.Client.Model;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Querying;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.Data.DataAccess.Linq;
using WebClient.Common.DataServices.DataProviders;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Metamodel.Ui;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Server.Bindings;
using WebClient.Common.Types;
using WebClient.Common.Utils;

namespace MLC.Wms.WebApp.DataServices.TEType
{
    public class TETypeLookupStructureDataProvider : AutoStructureDataProvider, ILookupDataLoader
    {
        private readonly IQueryableFactoryProvider _queryableFactoryProvider;
        private readonly IEntityBindingsProvider _entityBindingsProvider;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly IDataTableByBindingsFactory _dataTableByBindingsFactory;
        private readonly IBindingDataTableFiller _bindingDataTableFiller;
        private readonly BindingsCreator _bindingsCreator;
        private readonly LinqQueryBuilder _linqQueryBuilder;

        public TETypeLookupStructureDataProvider(IMetamodel metamodel,
            IQueryableFactoryProvider queryableFactoryProvider,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntityBindingsProvider entityBindingsProvider,
            JsStructureEnricher jsStructureEnricher,
            IEntitiesLoader entitiesLoader,
            IUiInfoProvider uiInfoProvider,
            INamingConventionProvider namingConventionProvider,
            IDataTableByBindingsFactory dataTableByBindingsFactory,
            IBindingDataTableFiller bindingDataTableFiller,
            BindingsCreator bindingsCreator) : base(metamodel, fieldsByBindingsFactory, jsStructureFactory)
        {
            Contract.Requires(queryableFactoryProvider != null);
            Contract.Requires(entityBindingsProvider != null);
            Contract.Requires(jsStructureEnricher != null);
            Contract.Requires(entitiesLoader != null);
            Contract.Requires(dataTableByBindingsFactory != null);
            Contract.Requires(bindingDataTableFiller != null);
            Contract.Requires(bindingsCreator != null);

            _queryableFactoryProvider = queryableFactoryProvider;
            _entityBindingsProvider = entityBindingsProvider;
            _jsStructureEnricher = jsStructureEnricher;
            _entitiesLoader = entitiesLoader;
            _dataTableByBindingsFactory = dataTableByBindingsFactory;
            _bindingDataTableFiller = bindingDataTableFiller;
            _bindingsCreator = bindingsCreator;

            _linqQueryBuilder = new LinqQueryBuilder(metamodel, uiInfoProvider, namingConventionProvider);

            SetEntityType(typeof(WmsTEType));
        }

        protected override IFieldBinding[] GetBindings()
        {
            var res =  _entityBindingsProvider.GetBindingsForLookup<WmsTEType>();
            //res = res.Union(new[]
            //{
            //    new WfFieldBinding()
            //    {
            //        FieldName = "TEType_WmsSKU2TTE_List",
            //        FieldType = typeof(EntityReferenceCollection),
            //        PropertyExpression = "TEType_WmsSKU2TTE_List",
            //        Visible = false
            //    }
            //}).ToArray();
            return res;
        }

        protected override string GetStructureName()
        {
            return EntityDescriptor.EntityType + "Lookup";
        }

        protected override string GetTitle()
        {
            return _jsStructureEnricher.GetEntityGridTitle(EntityDescriptor.EntityType);
        }

        protected override IRecordStructure GetStructure()
        {
            var res = base.GetStructure();
            var filterFields = new List<IField>(res.FilterFields);
            var skuField = new Field("Filter_SKU", typeof (EntityId));
            filterFields.Add(skuField);
            return new RecordStructure(res.Name, res.KeyField.Name, res.DataFields, filterFields, res.SortFields);
        }

        public JsStoreData LoadLookup(ILoadLookupQuery loadLookupQuery)
        {
            var dataPage = LoadLookupInternal(
                loadLookupQuery.QueryText,
                loadLookupQuery.EncloseValueInPercent,
                EntityDescriptor.EntityType,
                Bindings,
                loadLookupQuery.SortItems,
                loadLookupQuery.Conditions.OfType<IFieldValueCondition>(),
                loadLookupQuery.Page,
                true);

            return TableSerializer.Serialize(dataPage.Data, dataPage.Count);
        }

        private DataPage LoadLookupInternal(string queryText, bool encloseValueInPercent, string entityType, IEnumerable<IFieldBinding> bindings, IEnumerable<ISortItem> sortItems, IEnumerable<IFieldValueCondition> conditions, IPage page, bool needTotal = false)
        {
            using (var queryFactory = _queryableFactoryProvider.CreateFactory())
            {
                var query = queryFactory.CreateQuery(entityType);
                //query = ApplyReadPolicyToQuery(query, queryFactory);
                query = ApplyFilterFields(query, conditions);
                if (!string.IsNullOrEmpty(queryText))
                    query = _linqQueryBuilder.ApplyLookupQuery(query, queryText, encloseValueInPercent, bindings.Where(b => b.Visible));
                query = _linqQueryBuilder.ApplyConditions(query, conditions, bindings);

                var count = 0;
                if (needTotal)
                    count = _linqQueryBuilder.Count(query);

                query = _linqQueryBuilder.ApplySorting(query, sortItems, bindings);
                query = _linqQueryBuilder.ApplyProjection(query, bindings);

                if (page.IsDefined)
                    query = _linqQueryBuilder.ApplyPaging(query, page.StartRow, page.Size);

                var listObj = _linqQueryBuilder.List(query);

                var dataTable = _dataTableByBindingsFactory.CreateDataTable(bindings);
                // TODO: Сделать заполнение DataTable через Reflection
                dataTable.Columns.Add(LinqQueryBuilder.SELF_PROPERTY_NAME, typeof(EntityReference));

                _bindingDataTableFiller.FillTableFromList(dataTable, listObj, bindings);
                for (int i = 0; i < listObj.Count; i++)
                {
                    var obj = listObj[i];
                    var properties = PropertyHelper.GetProperties(obj);
                    var selfProp = properties[LinqQueryBuilder.SELF_PROPERTY_NAME];
                    var row = dataTable.Rows[i];
                    row[LinqQueryBuilder.SELF_PROPERTY_NAME] = selfProp.GetValue(obj);
                }

                return new DataPage(dataTable, count);
            }
        }

        private IQueryable ApplyFilterFields(IQueryable query, IEnumerable<IFieldValueCondition> conditions)
        {
            var skuField = conditions.SingleOrDefault(f => f.Field.Name == "Filter_SKU");
            if (skuField == null)
                return query;

            var skuId = (EntityId)skuField.Value.Single();
            return ((IQueryable<WmsTEType>) query).Where(i => i.TEType_WmsSKU2TTE_List.Any(j => j.SKU.SKUID == skuId.GetConvertedId<int>()));
        }
    }
}