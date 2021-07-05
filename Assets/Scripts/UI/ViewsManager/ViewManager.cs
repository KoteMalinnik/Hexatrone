using System.Collections.Generic;
using Core;

namespace UI.ViewsManager
{
    interface IViewManager : IAddable<IBaseView>, IRemovable<ViewType>
    {
        bool Show(ViewType viewType);
        bool Hide(ViewType viewType);

        bool IsActive(ViewType viewType);
    }



    public class ViewManager : IViewManager
    {
        // === Fields ===

        private readonly Dictionary<ViewType, IBaseView> _views = new Dictionary<ViewType, IBaseView>();


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

            view.Hide();
            return true;
        }

        public bool IsActive(ViewType viewType)
        {
            var view = GetView(viewType);
            return view is null ? false : view.IsActive;
        }


        // === Private Methods ===

        private IBaseView GetView(ViewType viewType)
        {
            _views.TryGetValue(viewType, out var view);
            return view;
        }
    }
}
