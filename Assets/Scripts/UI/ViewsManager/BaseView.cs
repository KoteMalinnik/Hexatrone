using UnityEngine;

namespace UI.ViewManager
{
    public interface IBaseView
    {
        ViewType ViewType { get; }
        bool IsActive { get; }

        void Show();
        void Hide();
    }



    public abstract class BaseView : MonoBehaviour, IBaseView
    {
        // === Fields ===

        [SerializeField]
        private ViewType _viewType = ViewType.NOT_DEFIEND;


        // === Properties ===

        public ViewType ViewType => _viewType;
        public bool IsActive => gameObject.activeInHierarchy;


        // === Public Methods ===

        public void Show()
        {
            if (IsActive) return;

            Log.Message($"Показ окна: {ViewType}");

            SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            if (IsActive is false) return;

            Log.Message($"Сокрытие окна: {ViewType}");

            SetActive(false);
            OnHide();
        }


        // === Virtual Methods ===

        protected virtual void OnShow() { }
        protected virtual void OnHide() { }


        // === Private Methods ===

        private void SetActive(bool state) => gameObject.SetActive(state);
    }
}