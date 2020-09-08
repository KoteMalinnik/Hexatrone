using UnityEngine;
using CustomScreen.Core;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CustomScreen.Game
{
    public class PauseScreen : BaseScreen
    {
		#region Fields
		[SerializeField] SceneAsset mainMenuScene = null;
		#endregion

		public void RestartLevel()
        {
			Log.Message("Нажатие на кнопку <RestartLevel>.");
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		}

		public void LoadMainMenu()
        {
			Log.Message("Нажатие на кнопку <ToMainMenu>.");
			SceneManager.LoadSceneAsync(mainMenuScene.name);
		}

		#region Screens Open Methods
		public void OpenSettingsScreen()
		{
			Log.Message("Нажатие на кнопку <Settings>.");
			ScreenManager.OpenScreen(ScreenType.SettingsScreen);
			//TODO: SettingsScreen при нажатии на кнопку "НАЗАД" будет показывать MainScreen
		}
		#endregion
	}
}