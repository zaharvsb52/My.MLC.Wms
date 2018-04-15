using System.Diagnostics.Contracts;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;

namespace MLC.Wms.WebApp.DataServices.Iwb2CargoBinding
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        public DataService(ClientQueryDeserializer queryDeserializer,
            ChangeSetDeserializer changeSetDeserializer,
            IChangeSetApplier changeSetApplier,
            IUnitOfWorkFactory unitOfWorkFactory,
            CargoIwbCardStructureDataProvider cargoIwbCardStructureDataProvider,
            CargoIwbLookupStructureDataProvider cargoIwbLookupStructureDataProvider,
            CargoIwbPosByIwbGridStructureDataProvider cargoIwbPosByIwbGridStructureDataProvider,
            CargoIwbPosGridStructureDataProvider cargoIwbPosGridStructureDataProvider,
            Iwb2CargoGridStructureDataProvider iwb2CargoGridStructureDataProvider,
            IwbCardStructureDataProvider iwbCardStructureDataProvider,
            IwbGridStructureDataProvider iwbGridStructureDataProvider
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            Contract.Requires(cargoIwbCardStructureDataProvider != null);
            Contract.Requires(cargoIwbLookupStructureDataProvider != null);
            Contract.Requires(cargoIwbPosByIwbGridStructureDataProvider != null);
            Contract.Requires(cargoIwbPosGridStructureDataProvider != null);
            Contract.Requires(iwb2CargoGridStructureDataProvider != null);
            Contract.Requires(iwbCardStructureDataProvider != null);
            Contract.Requires(iwbGridStructureDataProvider != null);

            StructureDataProviders.Add(cargoIwbCardStructureDataProvider);
            StructureDataProviders.Add(cargoIwbLookupStructureDataProvider);
            StructureDataProviders.Add(cargoIwbPosByIwbGridStructureDataProvider);
            StructureDataProviders.Add(cargoIwbPosGridStructureDataProvider);
            StructureDataProviders.Add(iwb2CargoGridStructureDataProvider);
            StructureDataProviders.Add(iwbCardStructureDataProvider);
            StructureDataProviders.Add(iwbGridStructureDataProvider);

            CommittableBindingsProvider.Register(cargoIwbCardStructureDataProvider);
            CommittableBindingsProvider.Register(cargoIwbPosByIwbGridStructureDataProvider);
            CommittableBindingsProvider.Register(cargoIwbPosGridStructureDataProvider);
            CommittableBindingsProvider.Register(iwb2CargoGridStructureDataProvider);
            CommittableBindingsProvider.Register(iwbCardStructureDataProvider);
        }
    }
}