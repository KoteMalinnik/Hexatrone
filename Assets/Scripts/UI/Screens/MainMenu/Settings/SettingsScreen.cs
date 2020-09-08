using CustomScreen.Core;

namespace CustomScreen.MainMenu
{
    public class SettingsScreen : BaseScreen
    {
        #region Screens Open Methods
        public void OpenMainMenuScreen()
		{
			Log.Message("Нажатие на кнопку <Back>.");
			ScreenManager.OpenScreen(ScreenType.MainScreen);
		}
		#endregion
	}
}