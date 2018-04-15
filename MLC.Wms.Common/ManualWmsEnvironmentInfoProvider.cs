using MLC.Wms.Common.Environment;

namespace MLC.Wms.Common
{
    public class ManualWmsEnvironmentInfoProvider : IWmsEnvironmentInfoProvider, IUserNameHandler
    {
        public string UserName { get; private set; }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }
    }
}