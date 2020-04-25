using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */

/// <summary>
/// Настройка классов при загрузке сцены GameLevel
/// </summary>
public class OnGameLevelLoad : MonoBehaviour
{
	void Awake()
	{
		Debug.Log("[OnGameLevelLoad] Установка значений счетчиков");

		FormLevel.setLevel(0);

		CounterCriticalOrbs.setValue(5);
		CounterOrbsAtFormLevel.setValue(0);
		CounterTotalOrbs.setValue(0);
	}
}