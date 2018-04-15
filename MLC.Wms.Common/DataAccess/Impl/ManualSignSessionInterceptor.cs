namespace MLC.Wms.Common.DataAccess.Impl
{
    /// <summary>
    /// Подписывает сесиию пользователем, переданными локально.
    /// </summary>
    public class ManualSignSessionInterceptor : SignSessionInterceptor
    {
        private readonly string _userCode;
        private readonly int? _wmsSessionId;

        public ManualSignSessionInterceptor(string userCode, int? wmsSessionId)
        {
            _userCode = userCode;
            _wmsSessionId = wmsSessionId;
        }

        protected override string GetUserCode()
        {
            return _userCode;
        }

        protected override int? GetWmsSessionId()
        {
            return _wmsSessionId;
        }
    }
}