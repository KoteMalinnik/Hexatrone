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
		Debug.Log("[OnGameLevelLoad] <color=yellow>Установка стартовых значений.</color>");

		CounterTotalOrbs.setValue(0);
	}

	void Start()
	{
		FormLevel.setLevel(0);
		Destroy(gameObject);
	}
}