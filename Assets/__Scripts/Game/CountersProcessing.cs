using UnityEngine;

/*
 * РЕФАКТОРИТЬ
 */

public static class CountersProcessing
{
	public static void OnColorMatch()
	{
		Debug.Log("[CountersProcessing] Обработка счетчиков при совпадении цветов!");
	}

	public static void OnColorMismatch()
	{
		Debug.Log("[CountersProcessing] Обработка счетчиков при несовпадении цветов!");
	}
}