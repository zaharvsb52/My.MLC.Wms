using System.Data;
using log4net;
using NHibernate;

namespace MLC.Wms.Common.DataAccess.Impl
{
    public abstract class SignSessionInterceptor : EmptyInterceptor, ISignSessionInterceptor
    {
        #region .  Fields  .

        private static readonly ILog Log = LogManager.GetLogger(typeof(SignSessionInterceptor));

        #endregion

        public override void SetSession(ISession session)
        {
            SignSession(session);
        }

        private void SignSession(ISession session)
        {
            var userCode = GetUserCode();
            if (string.IsNullOrEmpty(userCode))
            {
                Log.WarnFormat("Session was not signed. Unknown user code.");
                return;
            }

            var wmsSessionId = GetWmsSessionId();

            using (var cmd = session.Connection.CreateCommand())
            {
                session.Transaction.Enlist(cmd);

                var pAuthUser = cmd.CreateParameter();
                pAuthUser.ParameterName = "pAuthUser";
                pAuthUser.DbType = DbType.String;
                pAuthUser.Direction = ParameterDirection.Input;
                pAuthUser.Value = userCode;
                cmd.Parameters.Add(pAuthUser);

                if (wmsSessionId.HasValue)
                {
                    cmd.CommandText = "call set_sessionparam(:pAuthUser, :pSessionId)";

                    var pSessionId = cmd.CreateParameter();
                    pSessionId.ParameterName = "pSessionId";
                    pSessionId.DbType = DbType.Int32;
                    pSessionId.Direction = ParameterDirection.Input;
                    pSessionId.Value = wmsSessionId.Value;
                    cmd.Parameters.Add(pSessionId);
                }
                else
                {
                    cmd.CommandText = "call authenticate(:pAuthUser)";
                }

                cmd.ExecuteNonQuery();
            }
        }

        protected abstract string GetUserCode();

        protected abstract int? GetWmsSessionId();
    }
}