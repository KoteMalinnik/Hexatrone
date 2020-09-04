using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomScreen.Core
{
    public class ScreenManager : MonoBehaviour
    {
        #region Static Fields
        static List<BaseScreen> screenPrefabs;
        static Transform screenTransform;

        static List<BaseScreen> activeScreens = null;
        #endregion

        public static void Initialize(List<BaseScreen> screenPrefabs, Transform screenTransform)
        {
            ScreenManager.screenPrefabs = screenPrefabs;
            ScreenManager.screenTransform = screenTransform;
        }

        public static void OpenScreen(ScreenType screenType, Action onOpen = null)
        {
            Log.Message($"Попытка открытия окна {screenType}");

            BaseScreen screenPrefab = screenPrefabs.Find((value) => value.ScreenType == screenType);
            if (screenPrefab == null)
            {
                Log.Warning($"Префаба окна {screenType} не обнаружено.");
                return;
            }

            if (activeScreens.Contains(screenPrefab))
            {
                Log.Message($"Окно {screenType} уже активно.");
                return;
            }

            BaseScreen screenToOpen = MonoBehaviour.Instantiate(screenPrefab, screenTransform);

            if (activeScreens == null) activeScreens = new List<BaseScreen>();
            activeScreens.Add(screenToOpen);

            screenToOpen.Open(onOpen);
        }

        public static void CloseScreen(ScreenType screenType, Action onClose = null)
        {
            Log.Message($"Попытка закрытия окна {screenType}");

            if (activeScreens == null)
            {
                Log.Warning("Список активных окон отсутствует.");
                return;
            }

            BaseScreen screenToClose = activeScreens.Find((value) => value.ScreenType == screenType);

            if (screenToClose == null)
            {
                Log.Warning($"Окно {screenType} отсутствует в списке активных.");
                return;
            }

            screenToClose.Close(onClose);

            activeScreens.Remove(screenToClose);
        }
    }
}