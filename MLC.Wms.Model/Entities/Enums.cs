using System.ComponentModel;

namespace MLC.Wms.Model.Entities
{
    public enum OutputStatuses
    {
        // ReSharper disable InconsistentNaming
        OS_NEW,
        OS_ON_TRANSFER,
        OS_COMPLETED,
        OS_ERROR
    }

    /// <summary>
    /// Типы параметров задачи сервиса печати и экспорта.
    /// </summary>
    public enum EpsTaskParams
    {
        None,
        // ReSharper disable InconsistentNaming
        Variable, Zip, SupportTargetFolder, FileRecordProtect, FTPServerName,
        SupportFileName, ResultReportFile, PhysicalPrinter, FTPFolder,
        FTPEncodingFile, Copies, FTPServerLogin, FileMask,
        FTPServerPassword, MoveFile, ChangeODBC, Email,
        FTPTransmissionMode, SourceFolder, TargetFolder, CopyFile,
        ReserveCopy, AsAttachment, FileFormat,
        FileExtension,
        SendBlankMail,
        EpsReport,
        Conversion,
        Spacelife,
        BatchPrint,
        WorkflowIdentify,
        MailSubject,
        MailBody,
        MailSignature
    }

    public enum QueueMessageStates
    {
        [Description("Новый")]
        None,
        [Description("Создан")]
        Created,
        [Description("Ошибка")]
        Error,
        [Description("Готов к обработке")]
        Ready,
        [Description("Обрабатывается")]
        Processing,
        [Description("Завершен")]
        Completed
    }

    public static class EpsReportParameterTypes
    {
        // ReSharper disable InconsistentNaming
        public static string None = "None";
        public static string UserCode = "UserCode";
        // ReSharper restore InconsistentNaming
    }

    public enum EpsParamTypes
    {
        /// <summary>
        /// Задача.
        /// </summary>
        TSK,

        /// <summary>
        /// Команда.
        /// </summary>
        EPS,

        /// <summary>
        /// Параметр отчета.
        /// </summary>
        REP
    }

    /// <summary>
    /// Типы задач службы печати и экспорта
    /// </summary>
    public enum EpsTaskTypes
    {
        None,
        ARCH,
        DCL,
        FTP,
        MAIL,
        PRINT,
        SHARE,
        WF
    }

    /// <summary>
    /// Типы задач службы печати и экспорта
    /// </summary>
    public enum EpsOutputTaskCodes
    {
        None,
        OTC_ARCH,
        OTC_DCL,
        OTC_FTP,
        OTC_MAIL,
        OTC_PRINT,
        OTC_SHARE,
        OTC_WF
    }

    /// <summary>
    /// Статусы заявки на пропуск
    /// </summary>
    public enum PassRequestStates
    {
        [Description("Запланирована")]
        PASSREQUEST_PLAN,
        [Description("Оформлена")]
        PASSREQUEST_ARRIVED,
        [Description("Закрыта")]
        PASSREQUEST_DEPARTED
    }

    /// <summary>
    /// Источники времени выбора даты маршрута
    /// </summary>
    public static class MgRouteDateSelectDateSources
    {
        /// <summary>
        /// Планируемая дата отгрузки
        /// </summary>
        public const string OwbOutDatePlan = "OWBOUTDATEPLAN";

        /// <summary>
        /// Дата создания накладной
        /// </summary>
        public const string OwbDateIns = "OWBDATEINS";

        /// <summary>
        /// Клиенсткая дата создания накладной
        /// </summary>
        public const string OwbHostRefDate = "OWBHOSTREFDATE";
    }

    // ReSharper restore InconsistentNaming
}