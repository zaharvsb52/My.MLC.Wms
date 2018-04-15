using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using MLC.WF.Core.Common;
using Quartz;

namespace MLC.Wms.Jobs.Common
{
    [DisallowConcurrentExecution]
    public class ExecuteWorkflowJob : IJob
    {
        public const string WfIdentityParamName = "WfIdentity";
        public const string WfTimeoutInMsParamName = "WfTimeoutInMs";

        private readonly IWorkflowService _workflowService;

        public ExecuteWorkflowJob(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        public virtual void Execute(IJobExecutionContext context)
        {
            var identityStr = context.GetRequiredParameter<string>(WfIdentityParamName);
            var timeoutInMsStr = context.GetNonRequiredParameter<string>(WfTimeoutInMsParamName, null);

            var identity = JobHelper.ParseWorkflowIdentity(identityStr);
            var timeout = GetWfTimeout(timeoutInMsStr);
            var inputs = GetInputs(context);

            ExecuteWorkflow(identity, inputs, timeout);
        }

        protected virtual IDictionary<string, object> GetInputs(IJobExecutionContext context)
        {
            var res = context.MergedJobDataMap
                .Where(item => IsExtraParameter(item.Key))
                .ToDictionary(item => item.Key, item => item.Value);
            return res.Count > 0 ? res : null;
        }

        protected virtual bool IsExtraParameter(string name)
        {
            return name != WfIdentityParamName && name != WfTimeoutInMsParamName;
        }

        protected virtual IDictionary<string, object> ExecuteWorkflow(WorkflowIdentity identity,
            IDictionary<string, object> inputs, TimeSpan? timeout)
        {
            return timeout.HasValue
                ? _workflowService.Run(identity, inputs, timeout.Value)
                : _workflowService.Run(identity, inputs);
        }

        protected TimeSpan? GetWfTimeout(string timeoutInMsStr)
        {
            TimeSpan? timeout = null;
            if (!string.IsNullOrEmpty(timeoutInMsStr))
                timeout = TimeSpan.FromMilliseconds(int.Parse(timeoutInMsStr));
            return timeout;
        }
    }
}