using MLC.Wms.Model.Entities;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;

namespace MLC.Wms.WebApp.DataServices.Worker
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        public DataService(
            ClientQueryDeserializer queryDeserializer,
            IChangeSetApplier changeSetApplier,
            ChangeSetDeserializer changeSetDeserializer,
            IUnitOfWorkFactory unitOfWorkFactory,
            WorkerCardStructureDataProvider workerStructureDataProvider,
            TypedAutoGridStructureDataProvider<WmsAddressBook> addressListStructureDataProvider
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            StructureDataProviders.Add(workerStructureDataProvider);
            StructureDataProviders.Add(addressListStructureDataProvider);

            CommittableBindingsProvider.Register(workerStructureDataProvider);
        }
    }
}