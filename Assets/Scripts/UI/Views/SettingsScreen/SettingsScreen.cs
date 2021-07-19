using UI.CustomScreen.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.CustomScreen
{
    public class SettingsScreen : BaseScreen, IOpenMainMenuScreen
    {
		#region Fields
		[SerializeField] SceneAsset mainMenuScene = null;
		#endregion

		#region Screens Open Methods
		public void OpenMainMenuScreen()
		{
			Log.Message("Нажатие на кнопку <Back>.");

			string currentSceneName = SceneManager.GetActiveScene().name;

			//в зависимости от открытой сцены (из меню или игры) надо вернуться либо к главному меню, либо к меню паузы
			ScreenType screenToOpen = currentSceneName.Equals(mainMenuScene.name) ? ScreenType.MainScreen : ScreenType.PauseScreen;
			ScreenManager.OpenScreen(screenToOpen);
		}
		#endregion
	}
}