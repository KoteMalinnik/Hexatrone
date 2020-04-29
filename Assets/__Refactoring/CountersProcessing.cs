using UnityEngine;

/// <summary>
/// Обработка счетчиков при совпадении и несовпадении цветов Orb и Part.
/// </summary>
public static class CountersProcessing
{
	/// <summary>
	/// Обработать счетчики при несовпадении цветов.
	/// </summary>
	public static void OnColorMismatch()
	{
		Debug.Log("[CountersProcessing] Обработка счетчиков при несовпадении цветов!");

		var delta = OrbController.orbObject.delta;
		CounterCriticalOrbs.decrementValue(delta);

		SoundManager.playSound(1); //collect wrong orb sound
	}

	/// <summary>
	/// Обработать счетчики при совпадении цветов
	/// </summary>
	public static void OnColorMatch()
	{
		Debug.Log("[CountersProcessing] Обработка счетчиков при совпадении цветов!");
		var delta = OrbController.orbObject.delta;

		switch (OrbController.orbObject.type)
		{
			case OrbTypeDefiner.orbType.Basic:
				onBasicOrb(delta);
				break;
			case OrbTypeDefiner.orbType.CriticalBonus:
				onCriticalBonus(delta);
				break;
			case OrbTypeDefiner.orbType.DeltaBonus:
				onDeltaBonus(delta);
				break;
			case OrbTypeDefiner.orbType.LevelUpBonus:
				onLevelUpBonus();
				break;
		}

		SoundManager.playSound(0); //collect correct orb sound
	}

	/// <summary>
	/// Действия при базовой сфере.
	/// </summary>
	/// <param name="delta">Дельта.</param>
	static void onBasicOrb(int delta)
	{
		Debug.Log("[CountersProcessing] Базовая");

		CounterOrbsAtFormLevel.incrementValue(delta);
	}

	/// <summary>
	/// Действия при критическом бонусе.
	/// </summary>
	/// <param name="delta">Дельта.</param>
	static void onCriticalBonus(int delta)
	{
		Debug.Log("[CountersProcessing] Критический бонус");

		CounterCriticalOrbs.incrementValue(delta);
	}

	/// <summary>
	/// Действия при бонусе дельты.
	/// </summary>
	/// <param name="delta">Дельта.</param>
	static void onDeltaBonus(int delta)
	{
		Debug.Log("[CountersProcessing] Дельта бонус");

		CounterOrbsAtFormLevel.incrementValue(delta);
	}

	/// <summary>
	/// Действия при бонусе повышения уровня.
	/// </summary>
	static void onLevelUpBonus()
	{
		Debug.Log("[CountersProcessing] ЛевелАп бонус");

		FormLevel.levelUpEvent();
	}
}