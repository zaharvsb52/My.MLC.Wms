using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.DirectoryServices;
using System.Linq;
using log4net;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Services;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;

namespace MLC.Wms.Bootstrap.Services.Impl
{
    public class AuthService : IAuthService
    {
        #region .  Fields  .
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthService));

        private readonly ISessionFactory _sessionFactory;
        private readonly IWmsEnvironmentInfoProvider _environmentInfoProvider;
        #endregion

        public AuthService(ISessionFactory sessionFactory, IWmsEnvironmentInfoProvider environmentInfoProvider)
        {
            Contract.Requires(sessionFactory != null);
            Contract.Requires(environmentInfoProvider != null);

            _sessionFactory = sessionFactory;
            _environmentInfoProvider = environmentInfoProvider;
        }

        public bool Authenticate(string login, string password, out string userName)
        {
            userName = null;
            SetUserNameIfNeed(null);
            using (var session = _sessionFactory.OpenSession())
            {
                var user = session.Query<WmsUser>().SingleOrDefault(i => i.Login.ToUpper() == login.ToUpper());
                if (user == null)
                {
                    Log.Info($"User '{login}' not found.");
                    return false;
                }

                if (user.UserLocked)
                {
                    Log.Info($"User '{login}' is locked.");
                    return false;
                }

                var res = user.UserAuthentication
                    ? LdapAuth(login, password)
                    : BasicAuth(user, password);

                Log.InfoFormat(res
                    ? "Authentication succeeded. Login: '{0}'."
                    : "Authentication failed. Login: '{0}'.", login);

                if (res)
                {
                    userName = user.UserCode;
                    SetUserNameIfNeed(userName);
                }

                return res;
            }
       }

        private bool BasicAuth(WmsUser user, string password)
        {
            return user.UserPassword == password;
        }

        private bool LdapAuth(string login, string password)
        {
            var pathAd = ConfigurationManager.AppSettings["AdPath"];
            if (string.IsNullOrEmpty(pathAd))
                throw new ConfigurationErrorsException("Settrings 'AdPath' is not set. Please check config.");

            var dentry = new DirectoryEntry(pathAd, login, password);
            var dirSearcher = new DirectorySearcher(dentry, $"(sAMAccountName={login})");

            try
            {
                var ret = dirSearcher.FindOne();
                if (ret == null)
                    return false;
                return true;
            }
            catch (DirectoryServicesCOMException ex)
            {
                // чтобы не мусорить лишний раз в логах - в случае корректной ошибки выводим просто сообщение
                Log.Info($"Authentication failed (0x{ex.ErrorCode:X}). Login: '{login}'. {ex.Message}.");
            }
            catch (Exception ex)
            {
                Log.Warn($"Authentication error. Login: '{login}'. {ex.Message}.", ex);
            }
            return false;
        }

        private void SetUserNameIfNeed(string userName)
        {
            var userNameHandler = _environmentInfoProvider as IUserNameHandler;
            userNameHandler?.SetUserName(userName);
        }
    }
}