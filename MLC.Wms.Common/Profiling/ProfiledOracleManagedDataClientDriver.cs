using NHibernate.Driver;
using StackExchange.Profiling;
using System.Data;
using System.Data.Common;

namespace MLC.Wms.Common.Profiling
{
    public class ProfiledOracleManagedDataClientDriver : OracleManagedDataClientDriver
    {
        public override IDbCommand CreateCommand()
        {
            var command = base.CreateCommand();

            if (MiniProfiler.Current != null)
                command = new ProfiledOracleDbCommand((DbCommand)command, MiniProfiler.Current);

            return command;
        }

        protected override void OnBeforePrepare(IDbCommand command)
        {
            var profiledCmd = command as ProfiledOracleDbCommand;
            base.OnBeforePrepare(profiledCmd != null ? profiledCmd.OracleCommand : command);
        }
    }
}