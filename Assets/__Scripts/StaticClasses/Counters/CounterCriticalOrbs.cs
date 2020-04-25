using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */


public static class CounterCriticalOrbs
{
	public static int value { get; private set; } = 5;
	public static void setValue(int newValue)
	{
		value = newValue;
		Debug.Log("[CounterCriticalOrbs] Установка значения " + value);
	}

	public static void incrementValue(int delta = 1) { setValue(value + delta); }
}