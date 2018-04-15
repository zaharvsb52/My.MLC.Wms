using MLC.Wms.Common;
using MLC.Wms.Common.DataAccess.Impl;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        public int GetAvailablePickListCount(string truckCode)
        {
            //System.Threading.Thread.Sleep(1000);
            using (var session = SessionFactory.OpenSession())
            {
                var res = session
                    .GetNamedQuery("getAvailablePickListCount")
                    .SetAnsiString("pTruckCode", truckCode)
                    .UniqueResult<int>();
                return res;
            }
        }

        /// <summary>
        /// Получает кол-во доступных транспортных заданий с разбивкой по типам заданий
        /// </summary>
        /// <returns></returns>
        public object GetAvailableTransportTaskCount(int wmsSessionId)
        {
            //System.Threading.Thread.Sleep(1000);
            var interceptor = new ManualSignSessionInterceptor(WmsEnvironment.UserName, wmsSessionId);
            using (var session = SessionFactory.OpenSession(interceptor))
            {
                var res = session
                    .GetNamedQuery("getAvailableTransportTaskCount")
                    .List();
                //var di = res.Cast<dynamic>().ToDictionary(i => (string)i.TransportTypeCode, i => (int)i.Cnt);
                return res;
            }
        }

        public object GetRclInfo(string userCode, string trackCode)
        {
            return new
            {
                TransportTaskCount = 10,
                PickListCount = 20
            };
        }
    }
}