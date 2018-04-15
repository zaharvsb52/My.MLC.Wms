using System.Diagnostics.Contracts;
using WebClient.Abac;
using WebClient.Common.Types;

namespace MLC.Wms.Workflows
{
    public class WfAbacContext : IAbacContext
    {
        private readonly string _userName;

        public WfAbacContext(string userName)
        {
            Contract.Requires(!string.IsNullOrEmpty(userName));
            _userName = userName;
        }

        public EntityId GetCurrentUserId()
        {
            return new EntityId(_userName, "WmsUser");
        }

        public object GetEnvironment()
        {
            return new Bootstrap.Abac.Environment();
        }
    }
}