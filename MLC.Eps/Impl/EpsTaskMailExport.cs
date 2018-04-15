using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    public class EpsTaskMailExport : EpsTask
    {
        private readonly IEpsMailConfig _mailConfig;

        public EpsTaskMailExport(IEpsTaskConfig config,
            IEpsConfiguration epsConfiguration,
            Archiver archiver,
            IEpsMailConfig mailConfig)
            : base(config, epsConfiguration, archiver)
        {
            Contract.Requires(mailConfig != null);
            _mailConfig = mailConfig;
        }

        protected override void ProcessFiles(FileContainer[] files)
        {
            // ������ ���������
            var asAttachment = GetNotRequiredParameterValue(EpsTaskParameterTypes.AsAttachment, true);
            var sendBlankMail = GetNotRequiredParameterValue(EpsTaskParameterTypes.SendBlankMail, true);

            // ���� ���������� ������, � ������ ������ �� ��� �� ���� - ������ �� ����������
            if (files.Length == 0 && !sendBlankMail)
            {
                Log.DebugFormat("Nothing to send and blank mail is disallow.");
                return;
            }

            // �������� ��������� �������-�����������
            var addressesParams = _config.Parameters.Where(i => i.Code == EpsTaskParameterTypes.Email).ToArray();
            if (addressesParams.Length == 0)
                throw new Exception("Can't find any email parameter.");

            // ����������
            using (var client = new SmtpClient(_mailConfig.Host, _mailConfig.Port))
            {
                // ������������
                client.Credentials = new NetworkCredential(_mailConfig.UserName, _mailConfig.Password);

                // ������� ���������
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_mailConfig.From);

                // ��������� ����
                mailMessage.Subject = GetNotRequiredParameterValue(EpsTaskParameterTypes.MailSubject, _mailConfig.Subject);
                //mail.SetSubject(mailSubject);
                //ProcessSqlMacro(GetParamValue(EpsTaskParams.MailSubject, defaultValue: Settings.Default.MailSubject))
                //mailMessage.Subject = _mailConfig.Subject;
                mailMessage.IsBodyHtml = _mailConfig.IsBodyHtml;
                mailMessage.Body = GetNotRequiredParameterValue(EpsTaskParameterTypes.MailBody, _mailConfig.Body ?? string.Empty);
                var mailSignature = GetNotRequiredParameterValue(EpsTaskParameterTypes.MailSignature, _mailConfig.MailSignature ?? string.Empty);

                // ��������� �����������
                foreach (var toAddress in addressesParams)
                {
                    var address = (string)toAddress.Value;
                    if (string.IsNullOrEmpty(address))
                        throw new Exception("One of parameters have empty email address.");

                    mailMessage.To.Add(new MailAddress(address));
                }

                var newLine = GetNewLine();

                // ��������� ��������
                foreach (var file in files)
                {
                    if (asAttachment)
                    {
                        var attachment = new Attachment(new MemoryStream(file.Data), file.FileName);
                        mailMessage.Attachments.Add(attachment);
                    }
                    else
                    {
                        // � ���, ���� ��� ������� ������? � ������ ����� �����
                        using (var memoryStream = new MemoryStream(file.Data))
                        using (var reader = new StreamReader(memoryStream))
                        {
                            var text = reader.ReadToEnd();
                            mailMessage.Body += newLine + text;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(mailSignature))
                    mailMessage.Body += newLine + mailSignature;

                client.Send(mailMessage);
            }
        }

        private string GetNewLine()
        {
            var res = Environment.NewLine;
            if (_mailConfig.IsBodyHtml)
                res = "<br>";
            return res;
        }
    }
}