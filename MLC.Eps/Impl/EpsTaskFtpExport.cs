using System.IO;
using System.Net;
using System.Net.FtpClient;
using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    public class EpsTaskFtpExport : EpsTask
    {
        public EpsTaskFtpExport(IEpsTaskConfig config, IEpsConfiguration epsConfiguration, Archiver archiver)
            : base(config, epsConfiguration, archiver)
        {
        }

        protected override void ProcessFiles(FileContainer[] files)
        {
            var targetFolder = GetRequiredParameterValue<string>(EpsTaskParameterTypes.TargetFolder);

            //var deleteSrcFile = FindByName(EpsTaskParams.MoveFile) != null && FindByName(EpsTaskParams.CopyFile) == null;
            //var fileRecordProtect = GetParamValue<EpsTaskProtect>(EpsTaskParams.FileRecordProtect);
            //var supportTargetFolder = GetParamValue<string>(EpsTaskParams.SupportTargetFolder);
            //var supportFileName = GetParamValue<string>(EpsTaskParams.SupportFileName);
            var serverName = GetRequiredParameterValue<string>(EpsTaskParameterTypes.FTPServerName);
            var serverLogin = GetRequiredParameterValue<string>(EpsTaskParameterTypes.FTPServerLogin);
            var serverPassword = GetRequiredParameterValue<string>(EpsTaskParameterTypes.FTPServerPassword);
            var usePassive = GetNotRequiredParameterValue<int>(EpsTaskParameterTypes.FTPTransmissionMode, 0) == 0;

            // подключаемся
            using (var ftpClient = new FtpClient())
            {
                ftpClient.Host = serverName;
                ftpClient.Credentials = new NetworkCredential(serverLogin, serverPassword);
                ftpClient.DataConnectionType = usePassive
                    ? FtpDataConnectionType.AutoPassive
                    : FtpDataConnectionType.AutoActive;

                // пишем файлы
                foreach (var file in files)
                {
                    var fullTargetFileName = Path.Combine(targetFolder, file.FileName);
                    using (var fileStream = ftpClient.OpenWrite(fullTargetFileName))
                    {
                        fileStream.Write(file.Data, 0, file.Data.Length);
                    }
                }
            }
        }
    }
}