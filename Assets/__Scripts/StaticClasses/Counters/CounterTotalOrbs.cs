using UnityEngine;

public static class CounterTotalOrbs
{
	public static int value { get; private set; } = 0;
	public static void setValue(int newValue)
	{
		value = newValue;
		Debug.Log("[CounterTotalOrbs] Установка значения " + value);
	}

	public static void incrementValue(int delta = 1) { value += delta; }
	public static void decrementValue(int delta = 1) { value -= delta; }
}