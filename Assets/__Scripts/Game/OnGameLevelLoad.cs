using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */

/// <summary>
/// Настройка классов при загрузке сцены GameLevel
/// </summary>
public class OnGameLevelLoad : MonoBehaviour
{
	[SerializeField, Range(1, 50)]
	int criticalOrbsCount = 5;

	void Awake()
	{
		Debug.Log("[OnGameLevelLoad] Установка значений счетчиков");

		CounterCriticalOrbs.setValue(criticalOrbsCount);
		CounterOrbsAtFormLevel.setValue(0);
		CounterTotalOrbs.setValue(0);
	}
}