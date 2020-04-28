using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Часто исползуемые функции
/// </summary>
public class RegularMethods : MonoBehaviour
{
	/// <summary>
	/// Загрузить сцену.
	/// </summary>
	/// <param name="sceneID">Идентификатор сцены.</param>
	public static void LoadScene(int sceneID)
	{
		if (sceneID < 0) return;
		SceneManager.LoadSceneAsync(sceneID);
	}

	/// <summary>
	/// Загрузить сцену.
	/// </summary>
	/// <param name="sceneName">Имя сцены.</param>
	public static void LoadScene(string sceneName)
	{
		SceneManager.LoadSceneAsync(sceneName);
	}
}
