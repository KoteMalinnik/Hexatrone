using System;

namespace Counters
{
    /// <summary>
    /// Нисходящий счетчик.
    /// Считает от установленного начального значения только в отрицательную сторону.
    /// При достижении минимального значения будет вызвано событие.
    /// По умолчанию минимального значение составляет 0.
    /// </summary>
    public class DescendingCounter : BaseCounter
    {
        public event Action OnMinValueReach = null;

        ushort minValue = 0;

        public DescendingCounter(ushort initialValue, string ID, ushort minValue = 0) : base(initialValue, ID)
        {
            this.minValue = minValue;
            Log.Message($"Установка минимального значения счетчика {ID}: " + minValue);
        }

        public void Subtract(ushort delta = 1)
        {
            if (Value <= minValue)
            {
                Log.Message($"Счетчик {ID} достиг минимального значения. Невозможно вычесть.");
                return;
            }

            Value -= delta;
            Log.Message($"Вычитание из счетчика {ID}: {Value + delta} - {delta} -> {Value}.");

            if (Value <= minValue)
            {
                Log.Message($"Счетчик {ID} достиг минимального значения.");
                OnMinValueReach?.Invoke();
            }
        }
    }
}