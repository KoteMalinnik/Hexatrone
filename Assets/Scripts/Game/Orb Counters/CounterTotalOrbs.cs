using UnityEngine;

namespace OrbCounters
{
	public static class CounterTotalOrbs
	{
		public static int value { get; private set; } = 0;

		public static void setValue(int newValue)
		{
			if (newValue < 0) return;

			value = newValue;
			Debug.Log("[CounterTotalOrbs] Общее количество сфер: " + value);
		}

		public static void incrementValue(int delta = 1) { setValue(value + delta); }

		public static void decrementValue(int delta = 1) { setValue(value - delta); }
	}
}