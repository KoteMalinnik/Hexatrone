using System;

namespace Core
{
    interface IClickListener
    {
        event Action OnClicked;

        void AddListener(Action action);
        void RemoveListener(Action action);

        void RemoveAllListeners();
    }
}