using MLC.WF.Core.Common;
using MLC.Wms.Api;
using NHibernate;
using WebClient.Common.ExtDirect;

namespace MLC.Wms.WebApp.DataServices.Api
{
    [ExtDirectService]
    public class DataService : WmsAPI
    {
        public DataService(ISessionFactory sessionFactory, IWmsXmlConverter converter, IWorkflowLoader loader) : base(sessionFactory, converter, loader)
        {
        }
    }
}