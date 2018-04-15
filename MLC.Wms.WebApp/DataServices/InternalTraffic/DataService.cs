using MLC.Wms.Model.Entities;
using NHibernate;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;

namespace MLC.Wms.WebApp.DataServices.InternalTraffic
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
            TypedAutoGridStructureDataProvider<YInternalTrafficMonitor> internalTrafficMonitorStructureDataProvider,
            ISessionFactory factory
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            _factory = factory;
            StructureDataProviders.Add(internalTrafficMonitorStructureDataProvider);

            //CommittableBindingsProvider.Register(internalTrafficStructureDataProvider);
        }
    }
}