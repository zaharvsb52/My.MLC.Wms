using System.Diagnostics.Contracts;

namespace MLC.Wms.Common.Services
{
    [ContractClass(typeof (IAuthServiceContract))]
    public interface IAuthService
    {
        bool Authenticate(string login, string password, out string userName);
    }

    [ContractClassFor(typeof (IAuthService))]
    abstract class IAuthServiceContract : IAuthService
    {
        bool IAuthService.Authenticate(string login, string password, out string userName)
        {
            Contract.Requires(login != null);
            Contract.Requires(password != null);

            throw new System.NotImplementedException();
        }
    }
}