using System.Diagnostics.Contracts;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;

namespace MLC.Wms.WebApp.DataServices.TEType
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        public DataService(ClientQueryDeserializer queryDeserializer,
            ChangeSetDeserializer changeSetDeserializer,
            IChangeSetApplier changeSetApplier,
            IUnitOfWorkFactory unitOfWorkFactory,

            TETypeLookupStructureDataProvider teTypeLookupStructureDataProvider)
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            Contract.Requires(teTypeLookupStructureDataProvider != null);

            StructureDataProviders.Add(teTypeLookupStructureDataProvider);

            CommittableBindingsProvider.Register(teTypeLookupStructureDataProvider);
        }
    }
}