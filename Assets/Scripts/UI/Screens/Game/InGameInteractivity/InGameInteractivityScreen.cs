using UI.CustomScreen.Core;

namespace UI.CustomScreen
{
    public class InGameInteractivityScreen : BaseScreen
    {
        #region Screen Open Methods
        public void OpenPauseScreen()
        {
            Log.Message("Нажатие на кнопку <Pause>.");
            ScreenManager.OpenScreen(ScreenType.PauseScreen);
        }
        #endregion
    }
}