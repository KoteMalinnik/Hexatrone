using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Regular methods
/// </summary>
public class RegularMethods : MonoBehaviour
{
	/// <summary>
	/// Checks the object existence. Otherwise, search for the object on the scene.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <typeparam name="T">MonoBehaviour class.</typeparam>
	public static void checkObjectExistence<T>(ref T obj) where T : MonoBehaviour
	{
		if(obj == null)
		{
			obj = FindObjectOfType<T>();

			if(obj == null)
			{
				Debug.LogError($"<color=yellow>Объект класса {typeof(T)} отсутствует на сцене</color>");
				return;
			}

			Debug.Log($"<color=yellow>Объект класса {typeof(T)} назначен</color>");
		}
	}

	/// <summary>
	/// Loads the scene.
	/// </summary>
	/// <param name="sceneID">Scene identifier.</param>
	public static void LoadScene(int sceneID)
	{
		if (sceneID < 0) return;
		SceneManager.LoadScene(sceneID);
	}

	/// <summary>
	/// Loads the scene.
	/// </summary>
	/// <param name="sceneName">Scene name.</param>
	public static void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
