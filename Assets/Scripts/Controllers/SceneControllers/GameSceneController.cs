using CustomScreen.Game;
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
#if UNITY_EDITOR
	[SerializeField] bool createFormOnStart = true;
#endif
	[Space]
	[SerializeField] bool pauseOnStart = true;
	[Space]
	[SerializeField] GameObject orbCountersPrefab = null;
	[SerializeField] Transform orbCountersParent = null;
	[SerializeField] bool createOrbCounters = true;
    #endregion

    #region MonoBehaviour Callbacks
    void Awake()
	{
		Log.Message("Настройка сцены..");

		if (createOrbCounters)
        {
			Instantiate(orbCountersPrefab, orbCountersParent).name = "OrbCounters";
        }

		Statements.Pause = pauseOnStart;
		Statements.GameOver = false;

#if UNITY_EDITOR
		if (createFormOnStart)
		{
			InitializeForm();
		}
#endif
	}

    private void OnEnable()
    {
		PrepareTapScreen.OnPrepareTapButtonDown += InitializeForm;
    }

    private void OnDisable()
    {
		PrepareTapScreen.OnPrepareTapButtonDown -= InitializeForm;
	}

    private void OnDestroy()
    {
		Log.Message("Настройка сцены завершена.");
	}
    #endregion

    private void InitializeForm()
    {
		var formLevelController = FindObjectOfType<FormLevelController>();
		if (formLevelController != null)
		{
			formLevelController.SetupLevel(startingLevel);
		}
        else
        {
			Log.Warning("Попытка инициализации формы, но FormLevelController отсутствует на сцене.");
        }

		Destroy(gameObject);
	}
}