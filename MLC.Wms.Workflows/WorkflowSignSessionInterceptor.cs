using MLC.WF.Core.Common;
using MLC.Wms.Common.DataAccess.Impl;

namespace MLC.Wms.Workflows
{
    /// <summary>
    /// ѕодписывает сесиию пользователем, переданными локально.
    /// Wf может работать асинхронно (выполн€ть отдельные activity в разных потоках), потому у него не определен HttpContext.Current
    /// </summary>
    internal class WorkflowSignSessionInterceptor : ManualSignSessionInterceptor, IWorkflowSessionInterceptor
    {
        public WorkflowSignSessionInterceptor(string userCode) : base(userCode, null) { }
    }
}