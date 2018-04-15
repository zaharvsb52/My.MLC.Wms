using MLC.Wms.Model.Entities;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;

namespace MLC.Wms.WebApp.DataServices.Job
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        public DataService(
            ClientQueryDeserializer queryDeserializer,
            IChangeSetApplier changeSetApplier,
            ChangeSetDeserializer changeSetDeserializer,
            IUnitOfWorkFactory unitOfWorkFactory,
            TypedAutoCardStructureDataProvider<SchJob> jobStructureDataProvider,
            TypedAutoGridStructureDataProvider<SchJobParam> jobParamListStructureDataProvider,
            TypedAutoGridStructureDataProvider<SchCronTrigger> cronTriggerStructureDataProvider,
            TypedAutoGridStructureDataProvider<SchSimpleTrigger> simpleTriggerStructureDataProvider
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            StructureDataProviders.Add(jobStructureDataProvider);
            StructureDataProviders.Add(jobParamListStructureDataProvider);
            StructureDataProviders.Add(cronTriggerStructureDataProvider);
            StructureDataProviders.Add(simpleTriggerStructureDataProvider);

            CommittableBindingsProvider.Register(jobStructureDataProvider);
            CommittableBindingsProvider.Register(jobParamListStructureDataProvider);
            CommittableBindingsProvider.Register(cronTriggerStructureDataProvider);
            CommittableBindingsProvider.Register(simpleTriggerStructureDataProvider);
        }

        /// <summary>
        /// Принудитиельный запуск задачи в контексте сервера приложений
        /// </summary>
        public void ForceExecuteSchedulerJob()
        {
        }
    }
}