using System.Diagnostics.Contracts;

namespace MLC.Eps
{
    [ContractClass(typeof (IEpsTaskContract))]
    public interface IEpsTask
    {
        void Execute(IEpsReport[] reports);

        ExportType ExportType { get; }
        int TaskOrder { get; }

        bool IsNeedReserveCopy { get; }
    }

    [ContractClassFor(typeof (IEpsTask))]
    abstract class IEpsTaskContract : IEpsTask
    {
        void IEpsTask.Execute(IEpsReport[] reports)
        {
            Contract.Requires(reports != null);
            throw new System.NotImplementedException();
        }

        ExportType IEpsTask.ExportType
        {
            get { throw new System.NotImplementedException(); }
        }

        int IEpsTask.TaskOrder
        {
            get { throw new System.NotImplementedException(); }
        }

        bool IEpsTask.IsNeedReserveCopy
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}