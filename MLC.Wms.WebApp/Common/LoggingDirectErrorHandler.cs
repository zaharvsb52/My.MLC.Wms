using System;
using log4net;
using WebClient.ExtDirectHandler.Extensions;

namespace MLC.Wms.WebApp.Common
{
    public class LoggingDirectErrorHandler : DefaultErrorHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoggingDirectErrorHandler));

        public override void OnException(Exception e)
        {
            base.OnException(e);
            Log.Error("Unhandled exception", e);
        }
    }
}