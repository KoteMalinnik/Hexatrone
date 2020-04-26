using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */


public static class CounterCriticalOrbs
{
	public static int value { get; private set; } = 5;
	public static void setValue(int newValue)
	{
		if (newValue > 5) return;
		if (newValue < 0)
		{
			Debug.Log("[CounterCriticalOrbs] <color=red>Достигнут минимальный порог!</color>");
			FormLevel.levelDownEvent();
			return;
		}

		value = newValue;
		Debug.Log("[CounterCriticalOrbs] Критическое количество сфер: " + value);
	}

	public static void incrementValue(int delta = 1) { setValue(value + delta); }
	public static void decrementValue(int delta = 1) { setValue(value - delta); }
}