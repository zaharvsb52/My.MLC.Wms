using System;
using MLC.Wms.Integration.Common.Message;

namespace MLC.Wms.Integration.Common.Exceptions
{
  public class LogicalIntegrationException : BaseIntegrationException
    {
        public ErrorMessage ErrorMessage { get; set; }

        public LogicalIntegrationException()
        {
        }

        public LogicalIntegrationException(string message) : base(message)
        {
        }

        public LogicalIntegrationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}