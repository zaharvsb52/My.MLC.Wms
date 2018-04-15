using MLC.Wms.Common;
using WebClient.Abac;
using WebClient.Common.Types;

namespace MLC.Wms.Bootstrap.Abac
{
    public class Context : IAbacContext
    {
        public EntityId GetCurrentUserId()
        {
            return new EntityId(WmsEnvironment.UserName, "WmsUser");
        }

        public object GetEnvironment()
        {
            return new Environment();
        }
    }
}