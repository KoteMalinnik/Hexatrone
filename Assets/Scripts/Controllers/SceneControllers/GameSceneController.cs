using UnityEngine;

/// <summary>
/// Настройка классов при загрузке сцены GameLevel
/// </summary>
public class GameSceneController : MonoBehaviour
{
	[SerializeField] int startingLevel = 0;

	void Awake()
	{
		Log.Message("Установка значений.");

		Statements.setGameOver(false);
		Statements.setPause(true);

		//CounterTotalOrbs.setValue(0);

		//FormLevelController.SetupLevel(startingLevel);

		Log.Message("Установка значений завершена.");

		Destroy(gameObject);
	}
}