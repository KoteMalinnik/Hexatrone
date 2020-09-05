using Form;
using UnityEngine;

/// <summary>
/// Настройка классов при загрузке сцены GameLevel
/// </summary>
public class GameSceneController : MonoBehaviour
{
    #region Fields
    [SerializeField] int startingLevel = 0;
	[SerializeField] bool createFormOnStart = true;

	[Space]

	[SerializeField] bool pauseOnStart = true;
	#endregion
	void Awake()
	{
		Log.Message("Настройка сцены..");

		if (createFormOnStart)
        {
			var formLevelController = FindObjectOfType<FormLevelController>();
			if (formLevelController != null)
			{
				formLevelController.SetupLevel(startingLevel);
			}
		}

		Statements.Pause = pauseOnStart;
		Statements.GameOver = false;

		Log.Message("Настройка сцены завершена.");

		Destroy(gameObject);
	}
}