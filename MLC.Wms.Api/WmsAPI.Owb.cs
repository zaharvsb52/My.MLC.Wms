using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MLC.Wms.Api.Properties;
using MLC.Wms.Model.Entities;
using NHibernate.Linq;
using Oracle.ManagedDataAccess.Client;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        /// <summary>
        /// API APP 'Сменить владельца'.
        /// </summary>
        public void ChangeOwnerByOwb(int owbid, string operation, string clientType, int? timeout)
        {
            if (string.IsNullOrEmpty(operation))
                throw new ArgumentNullException(operation);
            if (string.IsNullOrEmpty(operation))
                throw new ArgumentNullException(clientType);

            const string cEventKindCode = "PRD_CHANGE_OWNER";
            const string cEventHeaderInstance = "WmsAPI_ChangeOwnerByOwb";

            var owbStatusCodes = new List<string>
            {
                "OWB_PICKING",
                "OWB_PICK",
                "OWB_PART_SHIPPED",
                "OWB_PACKING",
                "OWB_PACK",
                "OWB_ACTIVATED"
            };

            using (var session = SessionFactory.OpenSession())
            {
                var owb = session.Get<WmsOWB>(owbid);

                //Проверки
                if (owb == null)
                    throw new LogicalException(Resources.OwbNotFound, owbid);

                if (owb.Status == null || !owbStatusCodes.Contains(owb.Status.StatusCode))
                {
                    throw new LogicalException(Resources.OwbBadStatus,
                        owb.OWBName, owbid,
                        owb.Status == null ? null : owb.Status.StatusCode);
                }

                if (owb.OWBOwner == null)
                    throw new LogicalException(Resources.OwbOwnerUndefined, owb.OWBName, owbid);

                //Получим товар по накладной
                var query = session.Query<WmsProduct>();
                if (timeout.HasValue)
                    query.Timeout(timeout.Value);

                var products = query
                    .Where(p => p.OWBPos.OWB == owb && p.ProductOwner != owb.OWBOwner)
                    .ToArray();

                if (products.Length == 0)
                    throw new LogicalException(Resources.NotFoundProductsByOwner, owb.OWBName, owbid);

                var transaction = session.BeginTransaction();

                try
                {
                    foreach (var product in products)
                    {
                        //Изменяем владельца товара
                        product.ProductOwner = owb.OWBOwner;
                        session.Flush();

                        //Пишем событие
                        var eventHeader = new WmsEventHeader
                        {
                            Operation = new BillOperation {OperationCode = operation},
                            EventHeaderStartTime = DateTime.Now,
                            EventKind = new WmsEventKind {EventKindCode = cEventKindCode},
                            Partner = new WmsMandant {PartnerID = owb.Partner.PartnerID},
                            EventHeaderInstance = cEventHeaderInstance,
                            ClientType = new SysClientType {ClientTypeCode = clientType}
                        };

                        var eventDetail = new wmsEventDetailPRD
                        {
                            PRODUCTID_R = product.ProductID
                        };

                        RegEvent(session, eventHeader, eventDetail, null);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApiException(Resources.ApiErrorChangeOwnerByOwb, ex);
                }
            }
        }

        /// <summary>
        /// API "Рассчитать маршрут"
        /// См. описание в OneNote
        /// <exception cref="ApiException">
        /// Возникшая ошибока в DB API будет обернута в ApiException
        /// </exception>
        /// </summary>
        /// <param name="owbid">Id накладной, для которой требуется рассчитать маршрут</param>
        /// <param name="routeId">Id целевого маршрута. Если передан, то присваивается</param>
        /// <param name="planDate">Плановая дата маршрута. Если передана, то присваивается</param>
        /// <param name="allowChangeDate">Разрешать менять дату, если для накладной уже проставлена дата</param>
        /// <param name="allowChangeRoute">Разрешать менять маршрут, если для накладной маршрут уже проставлен</param>
        /// <returns>Сообщение об успешной маршрутизации</returns>
        public string ChangeOwbRoute(int owbid, int? routeId = null, DateTime? planDate = null,
            bool allowChangeDate = true, bool allowChangeRoute = true)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                using (var cmd = (OracleCommand) session.Connection.CreateCommand())
                {
                    cmd.CommandText = "pkgBpRoute.bpChangeOWBRoute";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pOWBID", OracleDbType.Int32, owbid, ParameterDirection.Input);
                    cmd.Parameters.Add("pRouteID", OracleDbType.Int32, routeId, ParameterDirection.Input);
                    cmd.Parameters.Add("pPlanDate", OracleDbType.Date, planDate,
                        ParameterDirection.Input);
                    cmd.Parameters.Add("pAllowChangeDate", OracleDbType.Byte, allowChangeDate,
                        ParameterDirection.Input);
                    cmd.Parameters.Add("pAllowChangeRoute", OracleDbType.Byte, allowChangeRoute,
                        ParameterDirection.Input);
                    var pSuccessMessage = cmd.Parameters.Add("pSuccessMessage", OracleDbType.Varchar2,
                        ParameterDirection.Output);
                    pSuccessMessage.Size = 4000;
                    pSuccessMessage.DbType = DbType.String; // это нужно, чтобы в Value был string, а не OracleString

                    cmd.ExecuteNonQuery();

                    return (string) pSuccessMessage.Value;
                }
            }
            catch (DbException ex)
            {
                // TODO: вычленять сообщение ORA
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Неизвестная ошибка при расчете маршрута накладной {0}. ", ex.Message), ex);
            }
        }

        public void ReserveOwbList(int[] owbids, string operationCode, int? timeout)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var cmd = (OracleCommand) session.Connection.CreateCommand())
                {
                    cmd.CommandText = "pkgBpReserv.bpReserveOWBLst";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (timeout.HasValue)
                        cmd.CommandTimeout = timeout.Value;

                    var pOwbidLst = cmd.Parameters.Add("pOWBIDLst", OracleDbType.Int32);
                    pOwbidLst.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pOwbidLst.Size = owbids.Length;
                    pOwbidLst.Value = owbids;

                    cmd.Parameters.Add("pOperationCode", OracleDbType.Varchar2, operationCode, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
