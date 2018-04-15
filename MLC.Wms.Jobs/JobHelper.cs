using System;
using System.Activities;
using Quartz;

namespace MLC.Wms.Jobs
{
    public static class JobHelper
    {
        public static TRes GetRequiredParameter<TRes>(this IJobExecutionContext context, string parameterName)
        {
            var obj = context.MergedJobDataMap[parameterName];
            if (obj == null)
                throw new ArgumentNullException(parameterName);
            return (TRes)obj;
        }

        public static TRes GetNonRequiredParameter<TRes>(this IJobExecutionContext context, string parameterName, TRes nullValue)
        {
            var obj = context.MergedJobDataMap[parameterName];
            if (obj == null)
                return nullValue;
            return (TRes)obj;
        }

        public static WorkflowIdentity ParseWorkflowIdentity(string code)
        {
            var identityParts = code.Split('$');
            if (identityParts.Length != 3)
                throw new ArgumentException("Неправильный формат WfIdentity: " + code);

            return new WorkflowIdentity(identityParts[1], new Version(identityParts[2]), identityParts[0]);
        }

    }
}