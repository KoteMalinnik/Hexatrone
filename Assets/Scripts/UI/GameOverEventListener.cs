using UnityEngine;
using UI.CustomScreen;
using UI.CustomScreen.Core;
using System.Collections.Generic;

namespace UI
{
    public class GameOverEventListener : MonoBehaviour
    {
        #region Fields
        [SerializeField] List<GameObject> objectsToDestroy = new List<GameObject>();
        #endregion

        #region MonoBehaviour Callbacks
        private void OnEnable()
        {
            Statements.OnGameOver += GameOverActions;
        }

        private void OnDisable()
        {
            Statements.OnGameOver -= GameOverActions;
        }
        #endregion

        private void GameOverActions()
        {
            Log.Message("Начало действий при проигрыше игрока.");

            OpenGameOverScreen();

            Log.Message("Уничтожение объектов.");
            for (int i = 0; i < objectsToDestroy.Count; i++)
            {
                if (objectsToDestroy[i] == null) continue;
                Log.Message("Уничтожение: " + objectsToDestroy[i].name);
                Destroy(objectsToDestroy[i]);
            }
            Log.Message("Уничтожение объектов завершено.");

            Destroy(this);
        }

        private void OpenGameOverScreen()
        {
            ScreenManager.OpenScreen(ScreenType.GameOverScreen);
        }
    }
}