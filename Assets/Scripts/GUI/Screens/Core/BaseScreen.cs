using System;
using UnityEngine;

namespace CustomScreen.Core
{
    public class BaseScreen : MonoBehaviour
    {
        #region Fields
        [SerializeField] ScreenType screenType;
        #endregion

        #region Properties
        public ScreenType ScreenType => screenType;
        #endregion

        public void Open(Action onOpen = null)
        {
            Log.Message("Показ экрана " + ScreenType);
            gameObject.SetActive(true);
            onOpen?.Invoke();
        }

        public void Close(Action onHide = null)
        {
            Log.Message("Сокрытие экрана " + ScreenType);
            Destroy(gameObject);
            onHide?.Invoke();
        }
    }
}