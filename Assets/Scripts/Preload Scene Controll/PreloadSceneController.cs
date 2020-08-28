using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadSceneController : MonoBehaviour
{
    #region Fields
    [SerializeField] bool loadNextScene = true;
    [SerializeField] string nextSceneName = "1_MainMenu";
    #endregion

    void Start()
	{
        if (loadNextScene)
        {
            Log.Message("Загрузка параметров.");
            Serialization.loadAllParametrs();
            Log.Message("Загрузка параметров завершена.");

            Log.Message("Загрузка следующей сцены: " + nextSceneName);
            SceneManager.LoadSceneAsync(nextSceneName);
        }
	}
}
