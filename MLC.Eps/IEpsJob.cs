using System;

namespace MLC.Eps
{
    public interface IEpsJob : IDisposable
    {
        void Execute();
    }
}