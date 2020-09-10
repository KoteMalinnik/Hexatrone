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

		public void Continue()
        {
			Log.Message("Нажатие на кнопку <Continue>.");

			ScreenManager.OpenScreen(ScreenType.InGameInteractiveScreen, false);
			ScreenManager.OpenScreen(ScreenType.GameInfoScreen, false);

			ScreenManager.CloseScreen(ScreenType);

			Statements.Pause = false;
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
		}
		#endregion
	}
}