using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MLC.Wms.WebApp.Hubs
{
    public class DclHub : Hub
    {
        public void ShowEntityCard(string entityType, string primaryKeyDatatype, string primaryKeyValue)
        {
            var userName = GetUniqueUserIdentifier();
            var entityInstance = new BusinessEntityDescriptor
            {
                EntityType = entityType,
                PrimaryKeyDatatype = primaryKeyDatatype,
                PrimaryKeyValue = primaryKeyValue
            };
            Clients.OthersInGroup(userName).showEntityCard(entityInstance);
            //Clients.Client(Context.ConnectionId).writeConsole("groupName = '" + userName + "' id = " + primaryKeyValue + " at " + DateTime.Now);
        }

        public override Task OnConnected()
        {
            var userName = GetUniqueUserIdentifier();
            Groups.Add(Context.ConnectionId, userName);
            //Clients.All.writeConsole("user " + Context.ConnectionId + " connected in groupName = '" + userName + "'");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var userName = GetUniqueUserIdentifier();
            Groups.Remove(Context.ConnectionId, userName);
            //Clients.All.writeConsole("user " + Context.ConnectionId + " disconnected from groupName = '" + userName + "'");
            return base.OnDisconnected(stopCalled);
        }

        private string GetUniqueUserIdentifier()
        {
            var userName = Context.User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
                userName = Context.QueryString["userName"];

            //var machineName = Context.QueryString["machineName"];
            //userName = userName + machineName;

            return userName.ToLower();
        }
    }

    public class BusinessEntityDescriptor
    {
        public string EntityType;
        public string PrimaryKeyDatatype;
        public string PrimaryKeyValue;
    }
}