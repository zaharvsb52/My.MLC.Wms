using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;

namespace MLC.Wms.WebApp.DataServices.PassRequest
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        public DataService(
            ClientQueryDeserializer queryDeserializer,
            IChangeSetApplier changeSetApplier,
            ChangeSetDeserializer changeSetDeserializer,
            IUnitOfWorkFactory unitOfWorkFactory,
            PassRequestCardStructureDataProvider cardStructureDataProvider,
            PassRequestListStructureDataProvider listStructureDataProvider
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            StructureDataProviders.Add(cardStructureDataProvider);
            StructureDataProviders.Add(listStructureDataProvider);

            CommittableBindingsProvider.Register(cardStructureDataProvider);
            CommittableBindingsProvider.Register(listStructureDataProvider);
        }
    }
}