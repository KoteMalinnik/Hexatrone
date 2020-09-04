using UnityEngine;
using System.Collections.Generic;

namespace CustomScreen.Core
{
    public class ScreenManagerInitializer : MonoBehaviour
    {
        #region Fields
        [SerializeField] List<BaseScreen> screenPrefabs = null;
        [SerializeField] Transform screenTransform = null;
        #endregion

        private void Awake()
        {
            if (screenPrefabs == null || screenTransform == null)
            {
                Log.Error("Список префабов или трансформ окон пуст.");
                return;
            }

            ScreenManager.Initialize(screenPrefabs, screenTransform);
        }
    }
}