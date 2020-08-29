using UnityEngine;

/// <summary>
/// Счетчик общего количества сфер на сцене GameLevel.
/// </summary>
public static class CounterTotalOrbs
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

		value = newValue;
		Debug.Log("[CounterTotalOrbs] Общее количество сфер: " + value);
	}

	/// <summary>
	/// Инкрементировать значение.
	/// </summary>
	/// <param name="delta">Сколько прибавить.</param>
	public static void incrementValue(int delta = 1) { setValue(value + delta); }

	/// <summary>
	/// Декрементировать значение.
	/// </summary>
	/// <param name="delta">Сколько отнять.</param>
	public static void decrementValue(int delta = 1) { setValue(value - delta); }
}