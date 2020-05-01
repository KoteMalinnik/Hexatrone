using UnityEngine;

/// <summary>
/// Управление уровнем формы.
/// </summary>
public static class FormLevel
{
	/// <summary>
	/// Уровень. Минимальный уровень 0, максимальный уровень 5.
	/// </summary>
	public static int level { get; private set; } = 0;

	/// <summary>
	/// Установить уровень.
	/// </summary>
	/// <param name="newLevel">Новый уровень.</param>
	public static void setLevel(int newLevel)
	{
		if (newLevel > 5) return; //Если уровень максимальный, то ничего делать не надо

		if (newLevel < 0)
		{
			Debug.Log("[FormLevel] <color=red>Конец игры!</color>");

			GameOverGUI.gameOver();

			return;
		}

		Debug.Log($"[FormLevel] Установка уровня формы: {level}");
		level = newLevel;

		newLevelEvent();
	}

	/// <summary>
	/// Событие нового уровня (повышения или понижения).
	/// </summary>
	static void newLevelEvent()
	{
		if(FormController.instance != null) FormDestroyer.destroyObject(FormController.form);

		CounterCriticalOrbs.setValue(5);
		CounterOrbsAtFormLevel.setValueToLevelUp(level);

		GameInfoViewer.updateLevelGUI(level);
	}

	/// <summary>
	/// Событие повышения уровня.
	/// </summary>
	public static void levelUpEvent()
	{
		if(level < 5) Debug.Log("[FormLevel] Уровень повышен!");
		SoundManager.playSound(3);
		setLevel(level + 1);
	}

	/// <summary>
	/// Событие понижения уровня.
	/// </summary>
	public static void levelDownEvent()
	{
		if (level > 0) Debug.Log("[FormLevel] Уровень понижен!");
		SoundManager.playSound(4);
		setLevel(level - 1);
	}
}
