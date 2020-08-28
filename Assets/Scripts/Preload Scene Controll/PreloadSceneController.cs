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
            Deserialize();

            Log.Message("Загрузка следующей сцены: " + nextSceneName);
            SceneManager.LoadSceneAsync(nextSceneName);
        }
	}

    void Deserialize()
    {
        Log.Message("Загрузка параметров.");
        
        bool soundState = Serialization.Load(SerializationKeys.SoundState, true);
        if (soundState) FindObjectOfType<SoundManager>().AllowAudio();
        else FindObjectOfType<SoundManager>().DisallowAudio();

        bool musicState = Serialization.Load(SerializationKeys.MusicState, true);
        if (musicState) FindObjectOfType<MusicManager>().Play();
        else FindObjectOfType<MusicManager>().Stop();

        Log.Message("Загрузка параметров завершена.");
    }
}
