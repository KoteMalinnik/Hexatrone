using CustomScreen.Core;
using System;

namespace CustomScreen.Game
{
    public class PrepareTapScreen : BaseScreen
    {
		#region Events
		public static event Action OnPrepareTapButtonDown = null;
        #endregion

        #region Screens Open Methods
        public void CloseThisScreen()
		{
			Log.Message("Нажатие на кнопку <PrepareTap>.");
			ScreenManager.CloseScreen(ScreenType);
			Statements.Pause = false;
			OnPrepareTapButtonDown?.Invoke();
		}
		#endregion
	}
}