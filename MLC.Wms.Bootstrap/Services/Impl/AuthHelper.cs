using System.Data;
using System.Diagnostics.Contracts;
using log4net;
using NHibernate;

namespace MLC.Wms.Bootstrap.Services.Impl
{
    public class AuthHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AuthHelper));

        public void SignSession(ISession session, string userCode)
        {
            Contract.Requires(session != null);

            if (string.IsNullOrEmpty(userCode))
                return;

            using (var cmd = session.Connection.CreateCommand())
            {
                session.Transaction.Enlist(cmd);
                cmd.CommandText = "call authenticate(:pauthuser)";

                var pAuthUser = cmd.CreateParameter();
                pAuthUser.ParameterName = "pauthuser";
                pAuthUser.DbType = DbType.String;
                pAuthUser.Direction = ParameterDirection.Input;
                pAuthUser.Value = userCode;
                cmd.Parameters.Add(pAuthUser);

                cmd.ExecuteNonQuery();
                Log.Info(string.Format("Signed session for user '{0}'", userCode));
            }
        }
    }
}