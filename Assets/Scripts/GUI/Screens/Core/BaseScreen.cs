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

        public virtual void Show(Action onShow = null)
        {
            Log.Message("Показ экрана " + ScreenType);
            gameObject.SetActive(true);
            onShow?.Invoke();
        }

        public virtual void Hide(Action onHide = null)
        {
            Log.Message("Сокрытие экрана " + ScreenType);
            Destroy(gameObject);
            onHide?.Invoke();
        }
    }
}