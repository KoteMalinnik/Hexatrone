using System;

namespace StatementManagers
{
    interface IPauseManager
    {
        event Action OnPause;
        event Action OnUnpause;

        bool IsPause { get; }

        void Pause();
        void Unpause();
    }
}
