using UnityEngine;

/// <summary>
/// Настройка классов при загрузке сцены GameLevel
/// </summary>
public class OnGameLevelLoad : MonoBehaviour
{
	[SerializeField, Tooltip("Начальный уровень формы при старте игры.")]
	int startLevel = 0;

	void Awake()
	{
		Debug.Log("[OnGameLevelLoad] <color=yellow>Установка стартовых значений.</color>");

		Statements.setGameOver(false);
		Statements.setPause(true);

		CounterTotalOrbs.setValue(0);
	}

	void Start()
	{
		FormLevelController.setLevel(startLevel);
		Destroy(gameObject);
	}
}