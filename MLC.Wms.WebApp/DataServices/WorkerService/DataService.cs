using System.Linq;
using MLC.Wms.Common;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.ExtDirect;

namespace MLC.Wms.WebApp.DataServices.WorkerService
{
    [ExtDirectService]
    public class DataService
    {
        private readonly ISession _session;

        public DataService(ISession session)
        {
            _session = session;
        }

        public object LoadWorkers()
        {
            var workers =
                _session.Query<WmsWorker>()
                    .Where(w => w.User != null && w.User.Login.ToUpper() == WmsEnvironment.UserName.ToUpper())
                    .ToArray();
            return BuidlWorkerDtos(workers);
        }

        public WorkerDto[] BuidlWorkerDtos(WmsWorker[] listWorkers)
        {
            var workers = listWorkers.Select(worker => new WorkerDto()
            {
                WorkerID = worker.WorkerID,
                WorkerLastName = worker.WorkerLastName,
                WorkerName = worker.WorkerName,
                WorkerMiddleName = worker.WorkerMiddleName
            }).ToArray();

            return workers;
        }
    }
}