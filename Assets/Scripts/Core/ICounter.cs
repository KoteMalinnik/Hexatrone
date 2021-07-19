using System;

namespace Core
{
    interface ICounter
    {
        event Action OnEndValueReached;

        int StartValue { get; }
        int EndValue { get; }

        void ChangeValue();
        void Reset();
    }
}
