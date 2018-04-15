using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.Owin;

namespace MLC.Eps.WebApi.Middleware
{
    public class CustomExceptionMiddleware : OwinMiddleware
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(CustomExceptionMiddleware));

        public CustomExceptionMiddleware(OwinMiddleware next) : base(next)
        { }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                _log.Error($"Unhandled exception: {ex.Message}", ex);
                throw;
            }
        }
    }
}