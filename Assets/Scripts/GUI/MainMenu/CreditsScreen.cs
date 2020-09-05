using CustomScreen.Core;

namespace CustomScreen
{
    public class CreditsScreen : BaseScreen
    {
        #region Screens Open Methods
        public void OpenMainMenuScreen()
        {
            Log.Message("Нажатие на кнопку <Back>.");
            ScreenManager.OpenScreen(ScreenType.MainMenuScreen);
        }
        #endregion
    }
}