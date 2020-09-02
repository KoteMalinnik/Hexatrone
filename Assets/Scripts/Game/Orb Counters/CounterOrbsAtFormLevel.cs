using UnityEngine;

public static class CounterOrbsAtFormLevel
{
	public static int value { get; private set; } = 0;

	public static void setValue(int newValue)
	{
		if (newValue < 0) return;

		if(newValue >= valueToLevelUp)
		{
			//FormLevelController.levelUpEvent();

			setValue(newValue - valueToLevelUp);
			//setValueToLevelUp(FormLevelController.level);
			return;
		}

		value = newValue;
		Debug.Log("[CounterOrbsAtFormLevel] Сфер на уровне формы: " + value);
	}

	public static void incrementValue(int delta = 1)
	{
		setValue(value + delta);
		CounterTotalOrbs.incrementValue(delta);
	}

	public static void decrementValue(int delta = 1) { setValue(value - delta); }

	public static int valueToLevelUp { get; private set; } = 10;

	public static void setValueToLevelUp(int formLevel)
	{
		valueToLevelUp = 10 * (formLevel * 2 + 1); // рассчет количества сфер до следующего уровня
		Debug.Log("[CounterOrbsAtFormLevel] Количество сфер до новго уровня: " + valueToLevelUp);
		setValue(0);
	}
}