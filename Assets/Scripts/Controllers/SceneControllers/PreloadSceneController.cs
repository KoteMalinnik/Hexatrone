using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PreloadSceneController : MonoBehaviour
{
    [SerializeField] bool loadNextScene = true;
    [SerializeField] SceneAsset mainMenuScene = null;

    void Start()
	{
        if (loadNextScene)
        {
            Deserialize();

            Log.Message("Загрузка следующей сцены: " + mainMenuScene.name);
            SceneManager.LoadSceneAsync(mainMenuScene.name);
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
