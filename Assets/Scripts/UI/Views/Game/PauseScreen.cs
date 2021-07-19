using UnityEngine;
using UI.CustomScreen.Core;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UI.CustomScreen
{
    public class PauseScreen : BaseScreen, IOpenSettingsScreen
    {
		#region Fields
		[SerializeField] SceneAsset mainMenuScene = null;
		Canvas canvas = null;
        #endregion

        private void Awake()
        {
			canvas = FindObjectOfType<Canvas>(true);
			if (canvas == null)
            {
				Log.Warning("Канвас отсутствует на сцене.");
            }

			SetCanvasSortingOrder(2);
			Statements.Pause = true;
        }

        public void Continue()
        {
			Log.Message("Нажатие на кнопку <Continue>.");

			ScreenManager.OpenScreen(ScreenType.InGameInteractivityScreen, false);
			ScreenManager.OpenScreen(ScreenType.GameInfoScreen, false);

			ScreenManager.CloseScreen(ScreenType);

			Statements.Pause = false;

			SetCanvasSortingOrder(0);
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

		void SetCanvasSortingOrder(int sortingOrder)
        {
			if (canvas != null)
			{
				Log.Message("Установка очереди канваса в слое: " + sortingOrder);
				canvas.sortingOrder = sortingOrder;
			}
			else
            {
				Log.Warning("Канвас не назначен.");
            }
		}
	}
}