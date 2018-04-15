using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using log4net;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.v1.Messages;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace MLC.Wms.Integration.v1
{
    public class QueueService : IQueueService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (QueueService));
        private readonly ISessionFactory _sessionFactory;

        public QueueService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public DequeueResponse DequeueOut(DequeueRequest request)
        {
            Contract.Requires(request != null);

            var enabledTypesList = new string[0];
            if (!string.IsNullOrEmpty(request.EnableTypes))
                enabledTypesList = request.EnableTypes.Split(';');

            var disableTypesList = new string[0];
            if (!string.IsNullOrEmpty(request.DisableTypes))
                disableTypesList = request.DisableTypes.Split(';');

            DequeueResponse dequeueResponse = null;

            using (var session = _sessionFactory.OpenSession())
            {
                IoQueueOut queueOut = null;
                try
                {
                    queueOut = GetIoQueueOut(session, enabledTypesList, disableTypesList, request.Selector);

                    if (queueOut == null)
                        return new DequeueResponse();

                    var queueMessage = new QueueMessage
                    {
                        ID = queueOut.ID,
                        GroupCode = queueOut.GroupCode,
                        Message = queueOut.Message,
                        ProcessCode = queueOut.ProcessCode,
                        QueueMessageStateCode = queueOut.QueueMessageState.ToString().ToUpper(),
                        QueueMessageTypeCode = queueOut.QueueMessageType.Code,
                        RelatedQueue = queueOut.QueueIn != null ? queueOut.QueueIn.ID : (Guid?)null,
                        Data = queueOut.Data != null ? Encoding.UTF8.GetString(queueOut.Data) : null,
                        Selector = queueOut.Selector,
                        Uri = queueOut.Uri
                    };

                    dequeueResponse = new DequeueResponse
                    {
                        // если партнера нет - то так и передаем. (возможно стоит ругаться)
                        PartnerCode = queueOut.Mandant == null ? null : queueOut.Mandant.PartnerCode,
                        MessageType = queueOut.QueueMessageType.Code,
                        DateIns = queueOut.DateIns,
                        Message = queueMessage
                    };

                    // фиксируем статус обработки
                    using (var transaction = session.BeginTransaction())
                    {
                        queueOut.QueueMessageState = request.RequiresConfirmation
                            ? QueueMessageStates.Processing
                            : QueueMessageStates.Completed;
                        dequeueResponse.Message.QueueMessageStateCode = queueOut.QueueMessageState.ToString().ToUpper();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Dequeue out error:", ex);
                    if (dequeueResponse != null)
                    {
                        dequeueResponse.Message.QueueMessageStateCode = QueueMessageStates.Error.ToString().ToUpper();
                        dequeueResponse.Message.Message = ex.Message;
                        Log.Debug(dequeueResponse.DumpToXML());
                    }

                    if (queueOut != null)
                        FillError(_sessionFactory, queueOut.ID, ex);

                    throw new FaultException(new FaultReason("Process dequeue exception: " + ex.Message));
                }
            }
            return dequeueResponse;
        }

        public DequeueListResponse DequeueListOut(DequeueListRequest requestList)
        {
            Contract.Requires(requestList != null);

            var enabledTypesList = new string[0];
            if (!string.IsNullOrEmpty(requestList.EnableTypes))
                enabledTypesList = requestList.EnableTypes.Split(';');

            var disableTypesList = new string[0];
            if (!string.IsNullOrEmpty(requestList.DisableTypes))
                disableTypesList = requestList.DisableTypes.Split(';');

            DequeueResponse dequeueResponse = null;
            var dequeueListResponse = new List<DequeueResponse>();

            using (var session = _sessionFactory.OpenSession())
            {
                try
                {
                    var queueOutList = GetIoQueueOutList(session, enabledTypesList, disableTypesList,
                        requestList.MessagesCount, requestList.Selector);

                    foreach (var queueOut in queueOutList)
                    {
                        var queueMessage = new QueueMessage
                        {
                            ID = queueOut.ID,
                            GroupCode = queueOut.GroupCode,
                            Message = queueOut.Message,
                            ProcessCode = queueOut.ProcessCode,
                            QueueMessageStateCode = queueOut.QueueMessageState.ToString().ToUpper(),
                            QueueMessageTypeCode = queueOut.QueueMessageType.Code,
                            RelatedQueue = queueOut.QueueIn == null ? (Guid?)null : queueOut.QueueIn.ID,
                            Data = queueOut.Data != null ? Encoding.UTF8.GetString(queueOut.Data) : null,
                            //DocNumber = queueOut.Order != null ? queueOut.Order.ID.ToString() : null,
                            Selector = queueOut.Selector,
                            Uri = queueOut.Uri
                        };

                        dequeueResponse = new DequeueResponse
                        {
                            // если партнера нет - то так и передаем. (возможно стоит ругаться)
                            PartnerCode = queueOut.Mandant == null ? null : queueOut.Mandant.PartnerCode,
                            MessageType = queueOut.QueueMessageType.Code,
                            DateIns = queueOut.DateIns,
                            Message = queueMessage
                        };

                        dequeueListResponse.Add(dequeueResponse);

                        // фиксируем статус обработки
                        using (var transaction = session.BeginTransaction())
                        {
                            queueOut.QueueMessageState = requestList.RequiresConfirmation
                                ? QueueMessageStates.Processing
                                : QueueMessageStates.Completed;
                            dequeueResponse.Message.QueueMessageStateCode =
                                queueOut.QueueMessageState.ToString().ToUpper();
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Dequeue out error:", ex);
                    if (dequeueResponse != null)
                    {
                        dequeueResponse.Message.QueueMessageStateCode = QueueMessageStates.Error.ToString().ToUpper();
                        dequeueResponse.Message.Message = ex.Message;
                        Log.Debug(dequeueResponse.DumpToXML());
                    }

                    throw new FaultException(new FaultReason("Process dequeue exception: " + ex.Message));
                }
            }
            return new DequeueListResponse() {Items = dequeueListResponse.ToArray()};
        }

        public ConfirmMessageListResponse ConfirmOutMessageList(ConfirmMessageListRequest requestList)
        {
            Contract.Requires(requestList != null);

            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    foreach (var reqItems in requestList.Items)
                    {
                        var request = reqItems;
                        QueueMessageStates nextState;
                        var isNextState = Enum.TryParse(request.NextState, true, out nextState);

                        if (!isNextState)
                            throw new InvalidOperationException("NextState is invalid");

                        if (request.MessageIdList == null)
                            throw new InvalidOperationException("MessageIdList is null or empty");

                        var wmsQueueOutItems =
                            session.Query<IoQueueOut>().Where(q => request.MessageIdList.Contains(q.ID));

                        foreach (var wmsQueueOutItem in wmsQueueOutItems)
                        {
                            if (wmsQueueOutItem.QueueMessageState != QueueMessageStates.Processing)
                                throw new InvalidOperationException(
                                    string.Format("IoQueueOut row with ID = {0} has incorrect state", wmsQueueOutItem.ID));

                            wmsQueueOutItem.QueueMessageState = nextState;

                            if (nextState == QueueMessageStates.Created && request.NextRequiredProcessDate != null)
                                wmsQueueOutItem.RequiredProcessDate = request.NextRequiredProcessDate;
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Log.Error("EnqueueListIn error:", ex);
                    throw;
                }
            }
            return new ConfirmMessageListResponse();
        }

        public EnqueueListResponse EnqueueListIn(EnqueueListRequest request)
        {
            Contract.Requires(request != null);
            try
            {
                if (request == null)
                    throw new InvalidOperationException("EnqueueListRequest is empty");

                if (string.IsNullOrEmpty(request.PartnerCode))
                    throw new InvalidOperationException("EnqueueListRequest.PartnerCode is empty");

                if (request.MessageList == null || request.MessageList.Length == 0)
                    throw new InvalidOperationException("EnqueueListRequest.MessageList is empty");

                using (var session = _sessionFactory.OpenSession())
                {
                    // получим все типы сообщений
                    var messageTypes = session.Query<IoQueueMessageType>().ToList();

                    // получаем партнера по коду
                    var partner = session.Query<WmsMandant>().FirstOrDefault(p => p.PartnerCode == request.PartnerCode);
                    if (partner == null)
                        throw new InvalidOperationException(string.Format("Unknown partner code '{0}'.", request.PartnerCode));

                    Log.DebugFormat("EnqueueListIn for Partner='{0}' with MessagesCount={1}", request.PartnerCode,
                        request.MessageList.Length);

                    var queueInList = request.MessageList.Select(m => new IoQueueIn()
                    {
                        GroupCode = m.GroupCode,
                        Message = m.Message,
                        Mandant = partner,
                        ProcessCode = m.ProcessCode,
                        QueueMessageState = QueueMessageStates.Ready,
                        QueueMessageType = ValidateMessageType(messageTypes, m.QueueMessageTypeCode),
                        QueueOut = m.RelatedQueue != null
                            ? session.Query<IoQueueOut>().FirstOrDefault(o => o.ID == m.RelatedQueue)
                            : null,
                        Data = Encoding.UTF8.GetBytes(m.Data)
                    }).ToList();

                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (var q in queueInList)
                            session.Save(q);
                        transaction.Commit();
                    }

                    var messageList = queueInList.Select(q => new QueueMessage
                    {
                        GroupCode = q.GroupCode,
                        ID = q.ID,
                        Message = q.Message,
                        ProcessCode = q.ProcessCode,
                        QueueMessageStateCode = q.QueueMessageState.ToString().ToUpper(),
                        QueueMessageTypeCode = q.QueueMessageType.Code,
                        RelatedQueue = q.QueueOut == null ? (Guid?)null : q.QueueOut.ID,
                        Data = q.Data != null ? Encoding.UTF8.GetString(q.Data) : null
                    }).ToList();

                    return new EnqueueListResponse
                    {
                        MessageList = messageList.ToArray(),
                        PartnerCode = partner.PartnerCode
                    };
                }
            }
            catch (Exception ex)
            {
                Log.Error("EnqueueListIn error:", ex);
                Log.Debug(request.DumpToXML());
                throw;
            }
        }

        private static IoQueueOut GetIoQueueOut(ISession session, string[] enabledTypesList, string[] disableTypesList, string selector)
        {
            using (var transaction = session.BeginTransaction())
            {
                var connection = session.Connection;
                using (var command = connection.CreateCommand())
                {
                    transaction.Enlist(command);
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Format(
                            "update IoQueueOut set queuemessagestate = 'PROCESSING' where dateins in (select min(dateins) from IoQueueOut where queuemessagestate = 'READY' and requiredprocessdate < systimestamp{0}{1}{2}) and queuemessagestate = 'READY' and requiredprocessdate < systimestamp{0}{1}{2} and ROWNUM <= 1 returning id into :pId",
                            enabledTypesList.Length == 0
                                ? string.Empty
                                : string.Format(" and queuemessagetypeid in (select t.id from IoQueueMessageType t where code in ({0}))", string.Join(",", enabledTypesList.Select(i => "'" + i + "'"))),
                            disableTypesList.Length == 0
                                ? string.Empty
                                : string.Format(" and queuemessagetypeid not in (select t.id from IoQueueMessageType t where code in ({0}))", string.Join(",", disableTypesList.Select(i => "'" + i + "'"))),
                            string.IsNullOrEmpty(selector)
                                ? string.Empty
                                : string.Format(" and instr(Selector, '{0}') > 0 ", selector)
                                );

                    var pId = new OracleParameter
                    {
                        ParameterName = "pId",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.Raw,
                        Size = 32
                    };
                    command.Parameters.Add(pId);
                    var result = command.ExecuteNonQuery();
                    if (result == 0)
                        return null;
                    var id = new Guid(((OracleBinary) (pId.Value)).Value);
                    var res = session.Get<IoQueueOut>(id);
                    transaction.Commit();
                    return res;
                }
            }
        }

        private static IoQueueOut[] GetIoQueueOutList(ISession session, string[] enabledTypesList,
            string[] disableTypesList, int messagesCount, string selector)
        {
            using (var transaction = session.BeginTransaction())
            {
                var connection = session.Connection;
                using (var command = connection.CreateCommand())
                {
                    transaction.Enlist(command);
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        string.Format(
                            @"DECLARE
                                vCountRec PLS_INTEGER := 0;
                                vMaxRec   PLS_INTEGER := {0};
                                vID       IoQueueOut.ID%TYPE;
                                vRID      ROWID;
                                resource_busy exception;
                                pragma exception_init(resource_busy, -54);
	
                                cursor l_cur is
                                    select rowid rid
                                      from IoQueueOut
                                     where queuemessagestate = 'READY'
                                       and requiredprocessdate < systimestamp{1}{2}{3}
                                  order by dateins;
                            BEGIN
                                open l_cur;
                                LOOP
                                    fetch l_cur into vRID;
                                    exit when vCountRec >= vMaxRec or l_cur%NOTFOUND;
                                    begin
                                        select ID into vID
                                          from IoQueueOut
                                         where queuemessagestate = 'READY'
                                           and requiredprocessdate < systimestamp{1}{2}{3}
                                           and rowid = vRID
                                           for update of QueueMessageState, GroupCode nowait;
			   
                                        update IoQueueOut
                                           set QueueMessageState = 'PROCESSING', GroupCode = :pId
                                         where rowid = vRID;
			 
                                        if SQL%ROWCOUNT = 1 then
                                            vCountRec := vCountRec + 1;
                                        end if;
                                    exception
                                        when no_data_found then null;
                                        when resource_busy then null;
                                    end;
                                END LOOP;
                                COMMIT;
                            END;",
                            messagesCount,
                            enabledTypesList.Length == 0
                                ? string.Empty
                                : string.Format(" and queuemessagetypeid in (select t.id from IoQueueMessageType t where code in ({0}))", string.Join(",", enabledTypesList.Select(i => "'" + i + "'"))),
                            disableTypesList.Length == 0
                                ? string.Empty
                                : string.Format(" and queuemessagetypeid not in (select t.id from IoQueueMessageType t where code in ({0}))", string.Join(",", disableTypesList.Select(i => "'" + i + "'"))),
                            string.IsNullOrEmpty(selector)
                                ? string.Empty
                                : string.Format(" and instr(Selector, '{0}') > 0 ", selector)
                            );

                    var guidBatch = Guid.NewGuid();

                    var pId = new OracleParameter
                    {
                        ParameterName = "pId",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Raw,
                        Size = 64,
                        Value = guidBatch
                    };

                    command.Parameters.Add(pId);
                    command.ExecuteNonQuery();

                    var res =
                        session.Query<IoQueueOut>()
                            .Where(o => o.GroupCode == guidBatch)
                            .OrderBy(o => o.DateIns)
                            .ToArray();

                    transaction.Commit();
                    return res;
                }
            }
        }

        private static void FillError(ISessionFactory factory, Guid messageId, Exception ex)
        {
            using (var errSession = factory.OpenSession())
            using (var errTransaction = errSession.BeginTransaction())
            {
                // перевычитываем сообщение
                var message = errSession.Query<IoQueueOut>().Single(i => i.ID == messageId);
                // пишем ошибку
                message.QueueMessageState = QueueMessageStates.Error;
                message.Message = ex.Message;
                errTransaction.Commit();
            }
        }

        private static IoQueueMessageType ValidateMessageType(List<IoQueueMessageType> typeList, string messageType)
        {
            var result = typeList.FirstOrDefault(t => t.Code == messageType);
            if (result == null)
                throw new InvalidOperationException(string.Format("Unknown message type '{0}.'", messageType));
            return result;
        }

        public string DoWork(string id)
        {
            Log.Debug("Called method 'IQueueTstService.DoWork'.");
            return string.Format("id = '{0}'", id);
        }
    }
}