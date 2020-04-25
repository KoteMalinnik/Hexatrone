using UnityEngine;

/*
 * РЕФАКТОРИТЬ 
 */

public static class FormLevel
{
	public static int level { get; private set; } = 0;
	public static void setLevel(int newLevel)
	{
		level = newLevel;
		Debug.Log($"[FormController] Установка уровеня формы: {level}");

		FormInitialiser.initialiseObject(level);

		CounterCriticalOrbs.setValue(5);
		CounterOrbsAtFormLevel.setValueToLevelUp(level);
	}

	public static void levelUpEvent()
	{
		Debug.Log("[FormController] Уровень повышен!");
		setLevel(level + 1);
	}

	public static void levelDownEvent()
	{
		Debug.Log("[FormController] Уровень понижен!");
		setLevel(level - 1);
	}
}
