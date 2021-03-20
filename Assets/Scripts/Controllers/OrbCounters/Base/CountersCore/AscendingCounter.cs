using System;

namespace Counters
{
    /// <summary>
    /// Восходящий счетчик.
    /// Считает от установленного начального значения только в положительную сторону.
    /// При достижении максимального значения будет вызвано событие.
    /// По умолчанию максимальное значение составляет 65535.
    /// </summary>
    public class AscendingCounter : BaseCounter
    {
		public event Action OnMaxValueReach = null;

        ushort maxValue = 0;

        public AscendingCounter(ushort initialValue, string counterID, ushort maxValue = ushort.MaxValue) : base(initialValue, counterID)
        {
            this.maxValue = maxValue;
            Log.Message($"Установка максимального значения счетчика {ID}: " + maxValue);
        }

        public void Add(ushort delta = 1)
        {
            if (Value >= maxValue)
            {
                Log.Message($"Счетчик {ID} переполнен. Невозможно добавить.");
                return;
            }
            
            Value += delta;
            Log.Message($"Добавление к счетчику {ID}: {Value - delta} + {delta} -> {Value}.");

            if (Value >= maxValue)
            {
                Log.Message($"Счетчик {ID} достиг максимального значения.");
                OnMaxValueReach?.Invoke();
            }
        }
    }
}