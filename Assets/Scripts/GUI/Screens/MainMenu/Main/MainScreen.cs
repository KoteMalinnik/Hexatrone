using UnityEngine;
using CustomScreen.Core;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CustomScreen.MainMenu
{
	public class MainScreen : BaseScreen
	{
		#region Fields
		[SerializeField] SceneAsset gameScene = null;
		#endregion

		public void LoadGame()
		{
			Log.Message("Нажатие на кнопку <Play>.");
			Log.Message("Запуск игры.");
			Log.Message("Загрузка сцены: " + gameScene.name);
			SceneManager.LoadSceneAsync(gameScene.name);
		}

		public void QuitApp()
		{
			Log.Message("Нажатие на кнопку <Quit>.");
			Log.Message("Выход из игры.");
			Application.Quit();
		}

        #region Screens Open Methods
        public void OpenCreditsScreen()
        {
			Log.Message("Нажатие на кнопку <Credits>.");
			ScreenManager.OpenScreen(ScreenType.CreditsScreen);
        }

		public void OpenSettingsScreen()
        {
			Log.Message("Нажатие на кнопку <Settings>.");
			ScreenManager.OpenScreen(ScreenType.SettingsScreen);
        }
        #endregion
    }
}