using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */


public static class CounterOrbsAtFormLevel
{
	public static int valueToLevelUp { get; private set; } = 0;

	public static int value { get; private set; } = 0;
	public static void setValue(int newValue)
	{
		value = newValue;
		Debug.Log("[CounterOrbsAtFormLevel] Установка значения " + value);
	}

	public static void incrementValue(int delta = 1) { value += delta; }
	public static void decrementValue(int delta = 1) { value -= delta; }

	public static void setValueToLevelUp(int formLevel)
	{
		// рассчет количества сфер до следующего уровня
	}
}