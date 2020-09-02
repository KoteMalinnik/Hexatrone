using System;

namespace Counters
{
    public abstract class BaseCounter
    {
		#region Properties
		protected string ID { get; }  = "Counter";
		public ushort Value { get; protected set; } = 0;
		#endregion

		public BaseCounter(ushort initialValue, string ID)
		{
			if (string.IsNullOrEmpty(ID)) throw new ArgumentNullException();
			if (initialValue < 0) throw new ArgumentOutOfRangeException();

			Value = initialValue;
			this.ID = ID;

			Log.Message($"Инициализация счетчика {ID} с начальным значением: {Value}.");
		}
	}
}