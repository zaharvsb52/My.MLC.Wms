namespace MLC.Wms.Common.DataAccess.Impl
{
    /// <summary>
    /// ����������� ������ �������������, ���������� �� Environment
    /// </summary>
    public class EnvironmentSignSessionInterceptor : SignSessionInterceptor
    {
        protected override string GetUserCode()
        {
            return WmsEnvironment.UserName;
        }

        protected override int? GetWmsSessionId()
        {
            return null;
        }
    }
}