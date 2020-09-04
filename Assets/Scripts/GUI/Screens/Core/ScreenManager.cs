using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomScreen.Core
{
    /// <summary>
    /// Менеджер окон.
    /// Открывает и закрывает окна, являющиеся объектами класса BaseScreen или унаследованные от него.
    /// </summary>
    public class ScreenManager : MonoBehaviour
    {
        #region Static Fields
        static List<BaseScreen> screenPrefabs; //список префабов создаваемых окон.
        static Transform screenTransform; //трансофрм, в котором будет создаваться окно.

        static List<BaseScreen> activeScreens = null;
        #endregion

        /// <summary>
        /// Инициализация полей спика префабов окон и трансофрма окна.
        /// </summary>
        public static void Initialize(List<BaseScreen> screenPrefabs, Transform screenTransform)
        {
            ScreenManager.screenPrefabs = screenPrefabs;
            ScreenManager.screenTransform = screenTransform;

            activeScreens = new List<BaseScreen>();
        }

        /// <summary>
        /// Открыть окно определенного типа.
        /// Окно не будет открыто, если его префаб отсутствует или это окно уже открыто.
        /// </summary>
        public static void OpenScreen(ScreenType screenType, bool closeAllActiveScreens = true, Action onOpen = null)
        {
            Log.Message($"Попытка открытия окна {screenType}");

            BaseScreen screenPrefab = screenPrefabs.Find((value) => value.ScreenType == screenType);
            if (screenPrefab == null)
            {
                Log.Warning($"Префаба окна {screenType} не обнаружено.");
                return;
            }

            if (closeAllActiveScreens)
            {
                for (int i = 0; i < activeScreens.Count; i++)
                {
                    activeScreens[i].Close();
                }

                activeScreens = new List<BaseScreen>();
            }

            if (activeScreens.Contains(screenPrefab))
            {
                Log.Message($"Окно {screenType} уже активно.");
                return;
            }

            BaseScreen screenToOpen = MonoBehaviour.Instantiate(screenPrefab, screenTransform);
            activeScreens.Add(screenToOpen);

            screenToOpen.Open(onOpen);
        }

        /// <summary>
        /// Закрыть окно определенного типа.
        /// </summary>
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