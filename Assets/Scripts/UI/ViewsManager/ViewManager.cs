using System.Collections.Generic;
using Core;

namespace UI.ViewManager
{
    interface IViewManager : IAddable<IBaseView>, IRemovable<ViewType>
    {
        bool Show(ViewType viewType);
        bool Hide(ViewType viewType);
        void GoBack();

        bool IsActive(ViewType viewType);
    }



    public class ViewManager : IViewManager
    {
        // === Fields ===

        private readonly Dictionary<ViewType, IBaseView> _views = new Dictionary<ViewType, IBaseView>();
        private readonly Stack<IBaseView> _showedViews = new Stack<IBaseView>();

        // === Public Methods ===

        public bool Add(IBaseView view)
        {
            if (_views.ContainsKey(view.ViewType))
            {
                Log.Warning($"Невозможно добавить окно {view.ViewType}: уже содержится в словаре");
                return false;
            }

            _views.Add(view.ViewType, view);
            view.Hide();

            Log.Message($"Окно {view.ViewType} успешно добавлено");
            return true;
        }

        public bool Remove(ViewType viewType)
        {
            var view = GetView(viewType);
            if (view is null)
            {
                Log.Warning($"Невозможно удалить окно {viewType}: отсутствует в словаре");
                return false;
            }

            UnityEngine.Object.Destroy(view as BaseView);
            _views.Remove(viewType);

            Log.Message($"Окно {viewType} удалено и уничтожено");
            return true;
        }

        public bool Show(ViewType viewType)
        {
            var view = GetView(viewType);
            if (view is null)
            {
                Log.Warning($"Невозможно показать окно {viewType}: отсутствует в словаре");
                return false;
            }

            _showedViews.Push(view);
            view.Show();
            return true;
        }

        public bool Hide(ViewType viewType)
        {
            var view = GetView(viewType);
            if (view is null)
            {
                Log.Warning($"Невозможно скрыть окно {viewType}: отсутствует в словаре");
                return false;
            }

            _showedViews.Pop();
            view.Hide();
            return true;
        }

        public bool IsActive(ViewType viewType)
        {
            var view = GetView(viewType);

            return _showedViews.Contains(view);
        }

        public void GoBack()
        {
            var view = _showedViews.Peek();
            
            Hide(view.ViewType);
        }

        // === Private Methods ===

        private IBaseView GetView(ViewType viewType)
        {
            _views.TryGetValue(viewType, out var view);
            return view;
        }
    }
}
