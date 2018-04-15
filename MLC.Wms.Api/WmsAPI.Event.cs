using System;
using System.Data;
using MLC.Wms.Model.Entities;
using NHibernate;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        public int RegEvent(ISession session, WmsEventHeader eventHeader, BaseEntity eventDetail, int? timeout)
        {
            if (eventHeader == null)
                throw new ArgumentNullException(nameof(eventHeader));

            var eventHeaderXmlDoc = Converter.ConvertFrom(eventHeader);
            var eventDetailXmlDoc = eventDetail == null ? null : Converter.ConvertFrom(eventDetail);

            var needDispose = false;
            if (session == null)
            {
                session = SessionFactory.OpenSession();
                needDispose = true;
            }

            try
            {
                using (var command = (OracleCommand)session.Connection.CreateCommand())
                {
                    command.CommandText = "pkgEventHeader.insEventHeader";
                    command.CommandType = CommandType.StoredProcedure;
                    if (timeout.HasValue)
                        command.CommandTimeout = timeout.Value;

                    var pEntXml = command.Parameters.Add("pEntXml", OracleDbType.XmlType, ParameterDirection.Input);
                    pEntXml.Value = eventHeaderXmlDoc.InnerXml;

                    var pKey = command.Parameters.Add("pKey", OracleDbType.Decimal, ParameterDirection.Output);

                    var pEventDetailParam = command.Parameters.Add("pEventDetailParam", OracleDbType.XmlType, ParameterDirection.Input);
                    if (eventDetailXmlDoc != null)
                        pEventDetailParam.Value = eventDetailXmlDoc.InnerXml;

                    var res = command.ExecuteNonQuery();

                    if (pKey.Value != null && pKey.Value != DBNull.Value)
                    {
                        var oraid = (OracleDecimal) pKey.Value;
                        if (!oraid.IsNull)
                            eventHeader.EventHeaderID = Convert.ToInt32(oraid.Value);
                    }

                    return res;
                }
            }
            finally
            {
                if (needDispose && session != null)
                    session.Dispose();
            }
        }

        public int RegEventPl(int? partnerId, string operation, string eventKindCode, int? clientSessionId, string clientTypeCode, int? workId, int? workingId, int plId, int plposId, string placeCode, int? timeout)
        {
            if (string.IsNullOrEmpty(operation))
                throw new ArgumentNullException(nameof(operation));
            if (string.IsNullOrEmpty(eventKindCode))
                throw new ArgumentNullException(nameof(eventKindCode));

            var eventHeader = new WmsEventHeader
            {
                Partner = partnerId.HasValue ? new WmsMandant {PartnerID = partnerId.Value} : null,
                Operation = new BillOperation {OperationCode = operation},
                EventKind = new WmsEventKind {EventKindCode = eventKindCode},
                EventHeaderStartTime = DateTime.Now,
                ClientSession = clientSessionId.HasValue ? new SysClientSession {ClientSessionID = clientSessionId.Value} : null,
                ClientType = string.IsNullOrEmpty(clientTypeCode) ? null : new SysClientType {ClientTypeCode = clientTypeCode},
                Work = workId.HasValue ? new WmsWork { WorkID = workId.Value } : null,
                Working = workingId.HasValue ? new WmsWorking { WorkingID = workingId.Value} : null,
                EventHeaderInstance = "WmsApi"
            };

            var eventDetail = new wmsEventDetailPL
            {
                PLID_r = plId,
                PLPosID_r = plposId,
                PlaceCode_r = placeCode
            };

            return RegEvent(null, eventHeader, eventDetail, timeout);
        }
    }
}
