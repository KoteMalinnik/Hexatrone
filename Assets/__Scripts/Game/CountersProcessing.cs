using UnityEngine;

/*
 * РЕФАКТОРИТЬ
 */

public static class CountersProcessing
{
	public static void OnColorMatch()
	{
		Debug.Log("[CountersProcessing] Обработка счетчиков при совпадении цветов!");

		var orbType = OrbController.orbType;

		switch (orbType)
		{
			case OrbTypeDefiner.orbType.Basic:
				Debug.Log("[CountersProcessing] Базовая");
				break;
			case OrbTypeDefiner.orbType.CriticalBonus:
				Debug.Log("[CountersProcessing] Критический бонус");
				break;
			case OrbTypeDefiner.orbType.DeltaBonus:
				Debug.Log("[CountersProcessing] Дельта бонус");
				break;
			case OrbTypeDefiner.orbType.LevelUpBonus:
				Debug.Log("[CountersProcessing] ЛевелАп бонус");
				break;
		}
	}

	public static void OnColorMismatch()
	{
		Debug.Log("[CountersProcessing] Обработка счетчиков при несовпадении цветов!");
	}
}