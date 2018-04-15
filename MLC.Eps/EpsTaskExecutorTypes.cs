using System;

namespace MLC.Eps
{
    /// <summary>
    /// Типы задач службы печати и экспорта
    /// </summary>
    public enum EpsTaskExecutorTypes
    {
        None,
        [Obsolete]
        ARCH,
        [Obsolete]
        DCL,
        FTP,
        MAIL,
        PRINT,
        SHARE,
        [Obsolete]
        WF
    }
}