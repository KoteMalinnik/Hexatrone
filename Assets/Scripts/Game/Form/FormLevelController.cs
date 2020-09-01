using System;
using UnityEngine;

namespace Form
{
    public class FormLevelController : MonoBehaviour
    {
        #region Events
        public static event Action<int> OnFormLevelChange = null;

        public static event Action OnFormZeroLevel = null;
        public static event Action OnFormMaxLevel = null;
        #endregion

        #region Fields
        [Header("Ограничения уровня")]
        [SerializeField] int minLevel = 1;
        [SerializeField] int maxLevel = 6;

        int level = 0;
        #endregion

        void SetupLevel(int level)
        {
            Log.Message("Установка уровня формы: " + level);
            
            this.level = level;

            if (this.level == maxLevel)
            {
                Log.Message("Достигнут максимальный уровень формы.");
                OnFormMaxLevel?.Invoke();
            }

            OnFormLevelChange?.Invoke(level);
        }

        void LevelUp()
        {
            if (level == maxLevel)
            {
                Log.Message("Достигнут максимальный уровень формы.");
                return;
            }

            Log.Message($"Уровень формы повышен.");
            SetupLevel(level + 1);
        }

        void LevelDown()
        {
            Log.Message($"Уровень формы понижен.");

            if (level - 1 < minLevel)
            {
                Log.Message("Уровень формы ниже минимального.");
                OnFormZeroLevel?.Invoke();
                return;
            }

            SetupLevel(level - 1);
        }
    }
}