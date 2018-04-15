using MLC.WF.Core.Common;
using MLC.Wms.Common.DataAccess.Impl;

namespace MLC.Wms.Workflows
{
    /// <summary>
    /// ����������� ������ �������������, ����������� ��������.
    /// Wf ����� �������� ���������� (��������� ��������� activity � ������ �������), ������ � ���� �� ��������� HttpContext.Current
    /// </summary>
    internal class WorkflowSignSessionInterceptor : ManualSignSessionInterceptor, IWorkflowSessionInterceptor
    {
        public WorkflowSignSessionInterceptor(string userCode) : base(userCode, null) { }
    }
}