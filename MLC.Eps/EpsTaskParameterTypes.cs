using System.Linq;

namespace MLC.Eps
{
    public static class EpsTaskParameterTypes
    {
        private static readonly string[] KnownParameters;

        static EpsTaskParameterTypes()
        {
            KnownParameters = typeof (EpsTaskParameterTypes).GetFields()
                .Select(i => i.GetValue(null))
                .Cast<string>()
                .ToArray();
        }

        // ReSharper disable InconsistentNaming
        // job params
        public static string Zip = "Zip";
        public static string ReserveCopy = "ReserveCopy";
        // file & report
        public static string ResultReportFile = "ResultReportFile";
        public static string TargetFolder = "TargetFolder";
        public static string EpsReport = "EpsReport";
        public static string ChangeODBC = "ChangeODBC";
        public static string FileFormat = "FileFormat";
        public static string FileExtension = "FileExtension";
        public static string Conversion = "Conversion";
        public static string Spacelife = "Spacelife";
        // ftp
        public static string FTPServerName = "FTPServerName";
        public static string FTPFolder = "FTPFolder";
        public static string FTPServerLogin = "FTPServerLogin";
        public static string FTPTransmissionMode = "FTPTransmissionMode";
        public static string FTPServerPassword = "FTPServerPassword";
        // print
        public static string Copies = "Copies";
        public static string PhysicalPrinter = "PhysicalPrinter";
        // mail
        public static string Email = "Email";
        public static string AsAttachment = "AsAttachment";
        public static string SendBlankMail = "SendBlankMail";
        public static string MailSubject = "MailSubject";
        public static string MailBody = "MailBody";
        public static string MailSignature = "MailSignature";
        // unsupported
        public static string CopyFile = "CopyFile";
        public static string SourceFolder = "SourceFolder";
        public static string SupportTargetFolder = "SupportTargetFolder";
        public static string FileRecordProtect = "FileRecordProtect";
        public static string SupportFileName = "SupportFileName";
        public static string FTPEncodingFile = "FTPEncodingFile";
        public static string Variable = "Variable";
        public static string FileMask = "FileMask";
        public static string MoveFile = "MoveFile";

        // unknown
        public static string BatchPrint = "BatchPrint";
        public static string WorkflowIdentify = "WorkflowIdentify";
        // ReSharper restore InconsistentNaming

        public static bool IsKnownParameter(string outputParamCode)
        {
            return KnownParameters.Contains(outputParamCode);
        }
    }
}