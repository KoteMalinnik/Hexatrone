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
		if (newLevel > 5) return; //Если уровень максимальный, то ничего делать не надо

		if (newLevel < 0)
		{
			Debug.Log("[FormLevel] <color=red>Конец игры!</color>");
			return;
		}

		Debug.Log($"[FormLevel] Установка уровня формы: {level}");
		level = newLevel;

		newLevelEvent();
	}

	static void newLevelEvent()
	{
		if(FormController.instance != null) FormDestroyer.destroyObject(FormController.form);

		CounterCriticalOrbs.setValue(5);
		CounterOrbsAtFormLevel.setValueToLevelUp(level);
	}

	public static void levelUpEvent()
	{
		if(level < 5) Debug.Log("[FormLevel] Уровень повышен!");
		setLevel(level + 1);
	}

	public static void levelDownEvent()
	{
		if (level > 0) Debug.Log("[FormLevel] Уровень понижен!");
		setLevel(level - 1);
	}
}
