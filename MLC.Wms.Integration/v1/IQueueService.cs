using System.ServiceModel;
using System.ServiceModel.Web;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.v1.Messages;

namespace MLC.Wms.Integration.v1
{
    [ServiceContract(Namespace = NamespaceHelper.V1Namespace, Name = "QueueService")]
    public interface IQueueService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        DequeueResponse DequeueOut(DequeueRequest request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        EnqueueListResponse EnqueueListIn(EnqueueListRequest request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        DequeueListResponse DequeueListOut(DequeueListRequest requestList);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        ConfirmMessageListResponse ConfirmOutMessageList(ConfirmMessageListRequest requestList);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        string DoWork(string id);
    }
}