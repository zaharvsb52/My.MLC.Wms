using System.Collections.Generic;
using System.Linq;
using MLC.Wms.Jobs.Common;
using MLC.WF.Core.Common;
using Quartz;

namespace MLC.Wms.Jobs.Integration
{
    [DisallowConcurrentExecution]
    public class ExecuteIntegrationWorkflowJob : ExecuteWorkflowJob
    {
        public const string QueueMessageTypeCodeParamName = "QueueMessageTypeCode";
        public const string PartnerCodeParamName = "MandantCode";
        public const string ContentWorkflowIdentityParamName = "ContentWorkflowIdentity";
        public const string CustomWfParametersParamName = "Setting";

        public ExecuteIntegrationWorkflowJob(IWorkflowService workflowService) : base(workflowService) { }
        
        protected override IDictionary<string, object> GetInputs(IJobExecutionContext context)
        {
            var inputParams = context.MergedJobDataMap
                .Where(item => IsExtraParameter(item.Key));

            // заполняем параметры, которые принимает на вход MAIN_DOWHILE
            var res = inputParams.Where(p => !IsCustomSetting(p.Key))
                .ToDictionary(item => item.Key, item => item.Value);

            // параметры, которые MAIN_DOWHILE не ожидает на вход, заворачиваем в параметр Setting, 
            // его MAIN_DIWHILE прозрачно пробросит во внутренний WF
            res[CustomWfParametersParamName] = inputParams.Where(p => IsCustomSetting(p.Key))
                .ToDictionary(item => item.Key, item => item.Value);

            return res.Count > 0 ? res : null;
        }

        public bool IsCustomSetting(string paramName)
        {
            return paramName != ContentWorkflowIdentityParamName &&
                   paramName != PartnerCodeParamName &&
                   paramName != QueueMessageTypeCodeParamName;
        }
    }
}