using System;

namespace Counters
{
    public abstract class BaseCounter
    {
		public event Action<int> OnValueChanged = null;

		ushort value = 0;

		protected string ID { get; }  = "Counter";

		public ushort Value
		{
			get
            {
				return value;
            }
			protected set
            {
				this.value = value;
				OnValueChanged?.Invoke(value);
            }
		}

		public BaseCounter(ushort initialValue, string ID)
		{
			if (string.IsNullOrEmpty(ID)) throw new ArgumentNullException();
			if (initialValue < 0) throw new ArgumentOutOfRangeException();

			Value = initialValue;
			this.ID = ID;

			Log.Message($"Инициализация счетчика {ID} с начальным значением: {Value}.");
		}

		public void Reset(bool needOnValueChangedEventInvokation = false)
        {
			if (needOnValueChangedEventInvokation) Value = 0;
			else value = 0;
        }
	}
}