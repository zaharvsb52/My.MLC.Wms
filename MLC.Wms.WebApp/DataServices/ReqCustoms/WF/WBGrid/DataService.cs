using MLC.WF.Core.Client.Protocol;
using MLC.WF.Core.Common;
using MLC.WF.Core.DataServices;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Protocol.DataTransferObjects.Query;
using WebClient.Common.DataServices.DataProviders;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Querying;
using JsFilter = WebClient.Common.Client.Protocol.DataTransferObjects.Query.JsFilter;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms.WF.WBGrid
{
    [ExtDirectService]
    public class DataService : WorkflowDataService
    {
        public DataService(ClientQueryDeserializer queryDeserializer,
            IwbGridStructureDataProvider iwbGridStructureDataProvider,
            OwbGridStructureDataProvider owbGridStructureDataProvider,
            IWebClientWorkflowService service, IWorkflowStorage workflowStorage)
            : base(queryDeserializer, service, workflowStorage)
        {
            StructureDataProviders.Add(iwbGridStructureDataProvider);
            StructureDataProviders.Add(owbGridStructureDataProvider);
        }

        public override JsStoreData LoadList(string entityType, int start, int limit, JsFilter[] filter, JsSorter[] sort, string structureName,
            JsWorkflowIdentity workflowIdentity, JsWorkflowInstanceIdentity workflowInstanceIdentity)
        {
            var structureDataProvider = StructureDataProviders[structureName];
            var loadListQuery = QueryDeserializer.DeserializeListQuery(structureDataProvider.RecordStructure, start, limit, filter, sort);
            return ((IListDataLoader)structureDataProvider).LoadList(loadListQuery);
        }
    }
}