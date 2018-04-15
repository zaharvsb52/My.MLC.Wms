namespace MLC.Wms.Common.Environment.Impl
{
    public class SvcWmsEnvironmentInfoProvider : IWmsEnvironmentInfoProvider, IUserNameHandler
    {
        public string UserName { get; private set; }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }
    }
}