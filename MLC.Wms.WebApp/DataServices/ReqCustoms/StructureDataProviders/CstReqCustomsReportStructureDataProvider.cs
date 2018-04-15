using System.Diagnostics.Contracts;
using System.Linq;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Querying;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.Data.DataAccess.Linq;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Metamodel.Impl.Dynamic.Bindings;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Server.Bindings;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms.StructureDataProviders
{
    /// <summary>
    /// Список отчётов для таможенной заявки.
    /// </summary>
    public class CstReqCustomsReportStructureDataProvider : TypedAutoGridStructureDataProvider<WmsReport>
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly LinqQueryBuilder _linqQueryBuilder;
        private readonly IDataTableByBindingsFactory _dataTableByBindingsFactory;
        private readonly IBindingDataTableFiller _bindingDataTableFiller;

        public CstReqCustomsReportStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntitiesLoader entitiesLoader,
            JsStructureEnricher jsStructureEnricher,
            EntityBindingsProvider entityBindingsProvider,
            IDataTableByBindingsFactory dataTableByBindingsFactory,
            IBindingDataTableFiller bindingDataTableFiller,
            LinqQueryBuilder linqQueryBuilder,
            ISessionFactory sessionFactory)
            : base(
                metamodel, fieldsByBindingsFactory, jsStructureFactory, entityBindingsProvider, jsStructureEnricher,
                entitiesLoader)
        {
            _dataTableByBindingsFactory = dataTableByBindingsFactory;
            _bindingDataTableFiller = bindingDataTableFiller;
            _linqQueryBuilder = linqQueryBuilder;
            _sessionFactory = sessionFactory;

            SetEntityType(typeof (WmsReport));
        }

        protected override string GetStructureName()
        {
            return "CstReqCustomsReporList";
        }

        public override JsStoreData LoadList(ILoadListQuery clientQuery)
        {
            Contract.Requires(clientQuery != null);

            using (var session = _sessionFactory.OpenSession())
            {
                var query = session.Query<WmsReport2Entity>()
                            .Where(p => p.ObjectName_r == "CSTREQCUSTOMS")
                            .Select(p => p.Report_r);

                query = (IQueryable<WmsReport>)_linqQueryBuilder.ApplyConditions(query, clientQuery.Conditions.OfType<IFieldValueCondition>(), Bindings);
                var count = _linqQueryBuilder.Count(query);

                query = (IQueryable<WmsReport>)_linqQueryBuilder.ApplySorting(query, clientQuery.SortItems, Bindings);
                if (clientQuery.Page.IsDefined)
                    query = (IQueryable<WmsReport>)_linqQueryBuilder.ApplyPaging(query, clientQuery.Page.StartRow, clientQuery.Page.Size);

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
