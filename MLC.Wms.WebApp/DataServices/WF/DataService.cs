using System.Collections.Generic;
using MLC.WF.Core.Client.Protocol;
using MLC.WF.Core.Common;
using Newtonsoft.Json.Linq;
using WebClient.Common.DataServices;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Querying;
using WebClient.Common.Types;

namespace MLC.Wms.WebApp.DataServices.WF
{
    [ExtDirectService]
    public class DataService : MultiStructuredReadOnlyDataService
    {
        private readonly IWebClientWorkflowService _service;

        public DataService(ClientQueryDeserializer queryDeserializer,
            IWebClientWorkflowService service
            )
            : base(queryDeserializer)
        {
            _service = service;
        }

        public object ExecuteWorkflow(
            JsWorkflowIdentity workflowIdentity,
            JsWorkflowInstanceIdentity workflowInstanceIdentity,
            EntityId entityId,
            string actionCode,
            JObject parameters)
        {
            var inputs = entityId == null
                ? new Dictionary<string, object>()
                : new Dictionary<string, object> {{"EntityId", entityId.Id}};

            var request = new JsWfRequest
            {
                WorkflowIdentity = workflowIdentity,
                WorkflowInstanceIdentity = workflowInstanceIdentity,
                Action = actionCode,
                ChangeSet = parameters
            };

            return _service.Execute(request, inputs);
        }

        public object RunWorkflow(
            JsWorkflowIdentity workflowIdentity,
            JsWorkflowInstanceIdentity workflowInstanceIdentity,
            JObject inArguments,
            string actionCode,
            JObject parameters)
        {
            var inputs = new Dictionary<string, object>();
            if (inArguments != null)
            {
                foreach (var a in inArguments)
                    //TODO: понять как быть с типизацией (пока делаю только string)
                    inputs.Add(a.Key, a.Value.Value<string>());
            }

            var request = new JsWfRequest
            {
                WorkflowIdentity = workflowIdentity,
                WorkflowInstanceIdentity = workflowInstanceIdentity,
                Action = actionCode,
                ChangeSet = parameters
            };

            return _service.Execute(request, inputs);
        }
    }
}