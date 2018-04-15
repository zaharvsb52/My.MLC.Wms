namespace MLC.Eps.Config
{
    public interface IEpsMailConfig
    {
        string Host { get; }
        int Port { get; }
        string From { get; }
        string Subject { get; }
        string Password { get; }
        string UserName { get; }
        string Body { get; }
        string MailSignature { get; }
        bool IsBodyHtml { get; }
    }
}