using MLC.Wms.Integration.Common.Message;

namespace MLC.Wms.Integration.Common.Exceptions
{
    public static class IntegrationErrorInfoProvider
    {
        private const string ErrorInfoLogical = "ErrorInfoLogical";
        private const string ErrorInfoTechnical = "ErrorInfoTechnical";

        public static ErrorInfo GetErrorInfo(BaseIntegrationException source)
        {
            var errorType = source is LogicalIntegrationException ? ErrorInfoLogical : ErrorInfoTechnical;

            return new ErrorInfo()
            {
                Message = source.Message,
                Uri = source.Uri,
                QueueMessageTypeName = source.QueueMessageTypeName,
                CallStack = source.InnerException == null ? string.Empty : source.InnerException.StackTrace,
                ErrorType = errorType
            };
        }
    }
}