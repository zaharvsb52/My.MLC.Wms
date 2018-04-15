using System;
using System.Linq;
using MLC.Wms.Api.Properties;
using MLC.Wms.Model.Entities;
using NHibernate.Linq;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        /// <summary>
        /// Указать ГТД для выбранных накладных.
        /// </summary>
        public void UpdateIwbGtd(int[] iwbIds, string gtd, int? timeout)
        {
            if (iwbIds == null || iwbIds.Length == 0)
                return;

            using (var session = SessionFactory.OpenSession())
            {
                var transaction = session.BeginTransaction();
                try
                {
                    foreach (var id in iwbIds)
                    {
                        var query = session.Query<WmsIWBPos>();
                        if (timeout.HasValue)
                            query.Timeout(timeout.Value);
                        var iwbposcol = query.Where(p => p.IWB.IWBID == id).ToArray();
                        foreach (var iwbpos in iwbposcol)
                        {
                            iwbpos.IWBPosGTD = gtd;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApiException(Resources.ApiErrorChangeIwbGtd, ex);
                }
            }
        }
    }
}
