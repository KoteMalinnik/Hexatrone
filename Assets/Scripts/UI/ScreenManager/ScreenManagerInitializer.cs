using UnityEngine;
using System.Collections.Generic;

namespace UI.CustomScreen.Core
{
    /// <summary>
    /// Инициализатор ScreenManager.
    /// Передает в ScreenManager необходимые параметры.
    /// </summary>
    public class ScreenManagerInitializer : MonoBehaviour
    {
        #region Fields
        [SerializeField] List<BaseScreen> screenPrefabs = null;
        [SerializeField] Transform screenTransform = null;

        [Space]
        [SerializeField] List<ScreenType> openOnAwake = new List<ScreenType>();
        #endregion

        private void Awake()
        {
            if (screenPrefabs == null || screenTransform == null)
            {
                Log.Error("Список префабов или трансформ окон пуст.");
                return;
            }

            ScreenManager.Initialize(screenPrefabs, screenTransform);

            for (int i = 0; i < openOnAwake.Count; i++)
            {
                ScreenManager.OpenScreen(openOnAwake[i], false);
            }

            Destroy(this);
        }
    }
}