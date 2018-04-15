using Oracle.ManagedDataAccess.Client;
using StackExchange.Profiling.Data;
using System.Data.Common;

namespace MLC.Wms.Common.Profiling
{
    public class ProfiledOracleDbCommand : ProfiledDbCommand
    {
        private readonly OracleCommand _oracleCommand;

        public ProfiledOracleDbCommand(DbCommand command, IDbProfiler profiler)
            : base(command, null, profiler)
        {
            _oracleCommand = (OracleCommand)command;
        }

        public OracleCommand OracleCommand
        {
            get { return _oracleCommand; }
        }
    }
}