using System.Data;
using System.Linq;
using MLC.Wms.Common;
using MLC.Wms.Model.Entities;
using MLC.Wms.WebApp.DataServices.ReqCustoms.StructureDataProviders;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;
using WebClient.Common.Types;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        private readonly ISessionFactory _factory;

        public DataService(
            ClientQueryDeserializer queryDeserializer,
            IChangeSetApplier changeSetApplier,
            ChangeSetDeserializer changeSetDeserializer,
            IUnitOfWorkFactory unitOfWorkFactory,
            ISessionFactory factory,
            TypedAutoCardStructureDataProvider<CstReqCustoms> cstReqCustomsStructureDataProvider,
            TransportDocumentStructureDataProvider transportDocumentStructureDataProvider,
            TransportContractStructureDataProvider transportContractStructureDataProvider,
            CstReqCustomsPosDataProvider cstReqCustomsPosDataProvider,
            CstReqCustoms2WBStructureDataProvider cstReqCustoms2WbStructureDataProvider
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            _factory = factory;
            StructureDataProviders.Add(cstReqCustomsStructureDataProvider);
            StructureDataProviders.Add(transportDocumentStructureDataProvider);
            StructureDataProviders.Add(transportContractStructureDataProvider);
            StructureDataProviders.Add(cstReqCustomsPosDataProvider);
            StructureDataProviders.Add(cstReqCustoms2WbStructureDataProvider);

            CommittableBindingsProvider.Register(cstReqCustomsStructureDataProvider);
            CommittableBindingsProvider.Register(transportDocumentStructureDataProvider);
            CommittableBindingsProvider.Register(transportContractStructureDataProvider);
        }

        public object GetAvailableMandants()
        {
            using (var session = _factory.OpenSession())
            {
                var currUser = session
                    .Query<WmsUser>()
                    .FirstOrDefault(i => i.UserCode == WmsEnvironment.UserName);

                return currUser?.WmsUser2Mandant_List.Count(
                    m =>
                        m.Partner.CPV_List.Any(
                            x => x.CustomParam.CustomParamCode == "MandantUseCustoms" && x.CPVValue == "1"));
            }
        }

        public object GetAccountsList(EntityId entityId)
        {
            using (var session = _factory.OpenSession())
            {


                var wb2Customs = session
                    .Query<CstReqCustoms2WB>()
                    .Where(i => i.ReqCustoms.ReqCustomsID == int.Parse(entityId.Id.ToString()));


                var dataTable = new DataTable();
                dataTable.Columns.Add(new DataColumn("AccountNumber", typeof (string)));
                dataTable.Columns.Add(new DataColumn("AccountAmount", typeof (decimal)));
                dataTable.Columns.Add(new DataColumn("AccountCurrency", typeof (string)));

                if (wb2Customs.Any(i => i.IWB != null))
                {
                    var iwbCpvLsts =
                        wb2Customs.SelectMany(i => i.IWB.CPV_List)
                            .Where(
                                c =>
                                    new[] {"IWBTIRAccountAmount", "IWBTIRAccountCurrency", "IWBTIRAccountNumber"}
                                        .Contains(c.CustomParam.CustomParamCode));


                    foreach (
                        var cpvParent in iwbCpvLsts.Where(x => x.CustomParam.CustomParamCode == "IWBTIRAccountNumber").Distinct())
                    {
                        var raw = dataTable.NewRow();

                        var accCurrency =
                            iwbCpvLsts.FirstOrDefault(
                                x =>
                                    x.Parent.CPVID == cpvParent.CPVID &&
                                    x.CustomParam.CustomParamCode == "IWBTIRAccountCurrency");
                        var accountAmount = iwbCpvLsts.Where(x => x.Parent.CPVID == cpvParent.CPVID &&
                                                                  x.CustomParam.CustomParamCode == "IWBTIRAccountAmount").ToList();
                         
                        var accountAmountSum = accountAmount.Sum(i => decimal.Parse(i.CPVValue));

                        raw["AccountNumber"] = cpvParent.CPVValue;
                        raw["AccountCurrency"] = accCurrency == null ? string.Empty : accCurrency.CPVValue;
                        raw["AccountAmount"] = accountAmountSum;

                        dataTable.Rows.Add(raw);
                    }
                }
                var dataPage = new DataPage(dataTable, dataTable.Rows.Count);
                return TableSerializer.Serialize(dataPage.Data, dataPage.Count);
            }
        }
    }
}