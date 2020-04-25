using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Regular methods
/// </summary>
public class RegularMethods : MonoBehaviour
{
	public static void incrementValue(ref int Value, int delta = 1) { Value += delta; }
	public static void decrementValue(ref int Value, int delta = 1) { Value -= delta; }

	/// <summary>
	/// Loads the scene.
	/// </summary>
	/// <param name="sceneID">Scene identifier.</param>
	public static void LoadScene(int sceneID)
	{
		if (sceneID < 0) return;
		SceneManager.LoadSceneAsync(sceneID);
	}

	/// <summary>
	/// Loads the scene.
	/// </summary>
	/// <param name="sceneName">Scene name.</param>
	public static void LoadScene(string sceneName)
	{
		SceneManager.LoadSceneAsync(sceneName);
	}
}
