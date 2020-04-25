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
		CounterTotalOrbs.incrementValue(newValue - value);

		value = newValue;
		Debug.Log("[CounterOrbsAtFormLevel] Установка значения " + value);

		if(value >= valueToLevelUp)
		{
			setValue(value-valueToLevelUp);
			FormController.levelUpEvent();
		}
	}

	public static void incrementValue(int delta = 1) { setValue(value + delta); }

	public static void setValueToLevelUp(int formLevel)
	{
		setValue(0);
		valueToLevelUp = 10 * (formLevel * 2 + 1); // рассчет количества сфер до следующего уровня
		Debug.Log("[CounterOrbsAtFormLevel] Количество сфер до новго уровня: " + valueToLevelUp);
	}
}