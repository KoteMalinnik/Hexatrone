using UnityEngine;

/// <summary>
/// Счетчик количества критических сфер. Пока количество критических сфер неотрицательно, уровень не будет понижен.
/// </summary>
public static class CounterCriticalOrbs
{
	/// <summary>
	/// Значение.
	/// </summary>
	public static int value { get; private set; } = 5;

	/// <summary>
	/// Установить значение.
	/// </summary>
	/// <param name="newValue">Новое значение.</param>
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
}