using System;

namespace MLC.Wms.Api
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
        public ApiException(string message, Exception innerException) : base(message, innerException) { }
        public ApiException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args)) { }
    }
}
