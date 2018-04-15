using MLC.Eps.Config;

namespace MLC.Eps
{
    public interface IEpsOutputExecutor
    {
        IEpsConfiguration EpsConfig { get; }
        void Execute(object context);
    }
}
