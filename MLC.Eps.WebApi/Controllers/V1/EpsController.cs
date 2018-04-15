using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http;
using MLC.Eps.Config;
using MLC.Eps.WebApi.Controllers.V1.Models;
using MLC.Wms.Integration.Common;
using MLC.Wms.Model.Entities;

namespace MLC.Eps.WebApi.Controllers.V1
{
    //[Authorize]
    public class EpsController : ApiController
    {
        private readonly IEpsOutputExecutor _executor;

        public EpsController(IEpsOutputExecutor executor)
        {
            Contract.Requires(executor != null);
            _executor = executor;
        }

        /// <summary>
        /// Тестовый метод проверки работоспособности контроллера
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public bool IsOnline()
        {
            return true;
        }

        [HttpPost]
        public void Print(EpsOutputDto[] outputs)
        {
            if (outputs == null)
                return;

            var epsoutputlst = new List<EpsOutput>();
            foreach (var output in outputs)
            {
                var epsoutput = MappingHelper.DynamicMap<EpsOutput>(output);
                epsoutputlst.Add(epsoutput);
            }

            _executor.Execute(epsoutputlst.ToArray());
        }

        [HttpPost]
        public void Preview(EpsOutputDto output)
        {
        }

        [HttpPost]
        public void Schedule(EpsJobDto output)
        {
        }

        [HttpPost]
        public void ExecuteJob(EpsJobDto job)
        {
        }

        [HttpPost]
        public object GetEpsConfig()
        {
            return new
            {
                _executor.EpsConfig.ReportPath,
                _executor.EpsConfig.OdacConnectionString,
                _executor.EpsConfig.OdbcConnectionString
            };
        }
    }
}
