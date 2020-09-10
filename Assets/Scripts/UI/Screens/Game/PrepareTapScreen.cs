using CustomScreen.Core;
using System;

namespace CustomScreen.Game
{
    public class PrepareTapScreen : BaseScreen
    {
        #region Screens Open Methods
        public void CloseThisScreen()
		{
			Log.Message("Нажатие на кнопку <PrepareTap>.");
			ScreenManager.CloseScreen(ScreenType);
			Statements.Pause = false;
		}
		#endregion
	}
}