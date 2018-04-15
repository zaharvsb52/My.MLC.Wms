using System;

namespace MLC.Eps
{
    public interface IEpsTaskConfig
    {
        //map to OutputTaskOrder
        int TaskId { get; }
        int TaskOrder { get; }
        EpsTaskExecutorTypes TaskExecutorType { get; }

        EpsTaskParameter[] Parameters { get; }
        ExportType ExportType { get; }

        bool IsNeedZip { get; }
        bool IsNeedReserveCopy { get; }

        Action<int, Exception, TimeSpan> HandleTaskComplete { get; }
    }
}