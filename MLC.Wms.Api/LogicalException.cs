using System;

namespace MLC.Wms.Api
{
    public class LogicalException : ApiException
    {
        public LogicalException(string message) : base(message) { }
        public LogicalException(string message, Exception innerException) : base(message, innerException) { }
        public LogicalException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args)) { }
    }
}
