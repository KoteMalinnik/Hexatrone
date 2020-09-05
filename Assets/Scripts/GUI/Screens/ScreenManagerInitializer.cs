using UnityEngine;
using System.Collections.Generic;

namespace CustomScreen.Core
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
        [SerializeField] ScreenType openOnAwake;
        #endregion

        private void Awake()
        {
            if (screenPrefabs == null || screenTransform == null)
            {
                Log.Error("Список префабов или трансформ окон пуст.");
                return;
            }

            ScreenManager.Initialize(screenPrefabs, screenTransform);
            ScreenManager.OpenScreen(openOnAwake);

            Destroy(gameObject);
        }
    }
}