using UnityEngine;

/// <summary>
/// Счетчик сфер на конкретном уровне формы. Обновляется при новом уровне.
/// </summary>
public static class CounterOrbsAtFormLevel
{
	/// <summary>
	/// Значение.
	/// </summary>
	public static int value { get; private set; } = 0;

	/// <summary>
	/// Установить значение.
	/// </summary>
	/// <param name="newValue">Новое значение.</param>
	public static void setValue(int newValue)
	{
		if (newValue < 0) return;

		if(newValue >= valueToLevelUp)
		{
			FormLevel.levelUpEvent();

			setValue(newValue - valueToLevelUp);
			setValueToLevelUp(FormLevel.level);
			return;
		}

		value = newValue;
		Debug.Log("[CounterOrbsAtFormLevel] Сфер на уровне формы: " + value);
	}

	/// <summary>
	/// Инкрементировать значение.
	/// </summary>
	/// <param name="delta">Сколько прибавить.</param>
	public static void incrementValue(int delta = 1)
	{
		setValue(value + delta);
		CounterTotalOrbs.incrementValue(delta);
	}

	/// <summary>
	/// Декрементировать значение.
	/// </summary>
	/// <param name="delta">Сколько отнять.</param>
	public static void decrementValue(int delta = 1) { setValue(value - delta); }

	/// <summary>
	/// Количество сфер до следующего повышения уровня.
	/// </summary>
	public static int valueToLevelUp { get; private set; } = 10;

	/// <summary>
	/// Установить количество сфер до следующего повышения уровня.
	/// </summary>
	/// <param name="formLevel">Form level.</param>
	public static void setValueToLevelUp(int formLevel)
	{
		valueToLevelUp = 10 * (formLevel * 2 + 1); // рассчет количества сфер до следующего уровня
		Debug.Log("[CounterOrbsAtFormLevel] Количество сфер до новго уровня: " + valueToLevelUp);
		setValue(0);
	}
}