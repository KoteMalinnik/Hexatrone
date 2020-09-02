using UnityEngine;

public static class CounterCriticalOrbs
{
	public static int value { get; private set; } = 5;

	public static void setValue(int newValue)
	{
		if (newValue > 5) return;
		if (newValue < 0)
		{
			Debug.Log("[CounterCriticalOrbs] <color=red>Достигнут минимальный порог!</color>");
			//FormLevelController.levelDownEvent();
			return;
		}

		value = newValue;
		Debug.Log("[CounterCriticalOrbs] Критическое количество сфер: " + value);
	}

	public static void incrementValue(int delta = 1)
	{
		setValue(value + delta);
		CounterTotalOrbs.incrementValue(delta);
	}

	public static void decrementValue(int delta = 1) { setValue(value - delta); }
}