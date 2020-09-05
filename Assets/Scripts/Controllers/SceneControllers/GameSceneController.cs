using Form;
using UnityEngine;

/// <summary>
/// Настройка классов при загрузке сцены GameLevel
/// </summary>
public class GameSceneController : MonoBehaviour
{
    #region Fields
	[Range(1, 6)]
    [SerializeField] int startingLevel = 0;
	[SerializeField] bool createFormOnStart = true;
	[Space]
	[SerializeField] bool pauseOnStart = true;
	[Space]
	[SerializeField] GameObject orbCountersPrefab = null;
	[SerializeField] Transform orbCountersParent = null;
	[SerializeField] bool createOrbCounters = true;
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

		if (createOrbCounters)
        {
			Instantiate(orbCountersPrefab, orbCountersParent).name = "OrbCounters";
        }

		Statements.Pause = pauseOnStart;
		Statements.GameOver = false;

		Log.Message("Настройка сцены завершена.");

		Destroy(gameObject);
	}
}