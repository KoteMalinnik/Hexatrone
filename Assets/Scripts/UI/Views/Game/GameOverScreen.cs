using UnityEngine;
using UI.CustomScreen.Core;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UI.CustomScreen
{
	public class GameOverScreen : BaseScreen
	{
		#region Fields
		[SerializeField] SceneAsset mainMenuScene = null;
        #endregion

        public void Restart()
		{
			Log.Message("Нажатие на кнопку <Restart>.");
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		}

		public void LoadMainMenu()
		{
			Log.Message("Нажатие на кнопку <ToMainMenu>.");
			SceneManager.LoadSceneAsync(mainMenuScene.name);
		}
	}
}