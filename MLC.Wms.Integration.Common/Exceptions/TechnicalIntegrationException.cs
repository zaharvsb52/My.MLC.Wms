using System;
using MLC.Wms.Integration.Common.Message;

namespace MLC.Wms.Integration.Common.Exceptions
{
    public class TechnicalIntegrationException : BaseIntegrationException
    {
        public string CallStack { get; set; }
        public ErrorMessage ErrorMessage { get; set; }

        public TechnicalIntegrationException()
        {
        }

        public TechnicalIntegrationException(string message) : base(message)
        {
        }

        public TechnicalIntegrationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}