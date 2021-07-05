using System;

namespace Core
{
    public interface ICommonCoroutine
    {
        event Action OnFinish;

        bool IsRunning { get; }

        void Start();
        void Stop();
    }
}

