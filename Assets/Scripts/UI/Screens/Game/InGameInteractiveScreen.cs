﻿using CustomScreen.Core;

namespace CustomScreen.Game
{
    public class InGameInteractiveScreen : BaseScreen
    {
        #region Screen Open Methods
        public void OpenPauseScreen()
        {
            Log.Message("Нажатие на кнопку <Pause>.");
            Statements.Pause = true;
            ScreenManager.OpenScreen(ScreenType.PauseScreen);
        }
        #endregion
    }
}