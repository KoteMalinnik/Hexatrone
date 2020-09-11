using UI.CustomScreen.Core;

namespace UI.CustomScreen
{
    public class CreditsScreen : BaseScreen, IOpenMainMenuScreen
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