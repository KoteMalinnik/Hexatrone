using UnityEngine;

/*
 * РЕФАКТОРИТЬ 
 */

public static class FormLevel
{
	/// <summary>
	/// Gets the level. Minimum level is 0, maximum level is 5
	/// </summary>
	/// <value>The level.</value>
	public static int level { get; private set; } = 0;
	public static void setLevel(int newLevel)
	{
		if (level > 5) return; //Если уровень максимальный, то ничего делать не надо

		if (level < 0)
		{
			Debug.Log("[FormLevel] <color=red>Конец игры!</color>");
			Debug.Break();
		}

		Debug.Log($"[FormLevel] Установка уровня формы: {level}");
		level = newLevel;

		newLevelEvent();
	}

	static void newLevelEvent()
	{
		FormDestroyer.destroyObject(FormController.form);

		CounterCriticalOrbs.setValue(5);
		CounterOrbsAtFormLevel.setValueToLevelUp(level);
	}

	public static void levelUpEvent()
	{
		Debug.Log("[FormLevel] Уровень повышен!");
		setLevel(level + 1);
	}

	public static void levelDownEvent()
	{
		Debug.Log("[FormLevel] Уровень понижен!");
		setLevel(level - 1);
	}
}
