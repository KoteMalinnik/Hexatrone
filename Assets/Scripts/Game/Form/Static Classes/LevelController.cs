using System;

namespace Form
{
    public static class LevelController
    {
        #region Events
        public static event Action<int> OnFormLevelChange = null;

        public static event Action OnFormZeroLevel = null;
        public static event Action OnFormMaxLevel = null;
        #endregion

        #region Fields
        static int minLevel = 1;
        static int maxLevel = 6;
        #endregion

        #region Properties
        public static int Level { get; private set; } = 0;
        #endregion

        public static void SetupLevelThresholds(int min, int max)
        {
            Log.Message($"Установка ограничений уровня. Min: {min}, Max: {max}.");
            minLevel = min;
            maxLevel = max;
        }

        public static void SetupLevel(int level)
        {
            Log.Message("Установка уровня формы: " + level);
            
            Level = level;

            if (Level == maxLevel)
            {
                Log.Message("Достигнут максимальный уровень формы.");
                OnFormMaxLevel?.Invoke();
            }

            OnFormLevelChange?.Invoke(level);
        }

        public static void LevelUp()
        {
            if (Level == maxLevel)
            {
                Log.Message("Достигнут максимальный уровень формы.");
                return;
            }

            Log.Message($"Уровень формы повышен.");
            SetupLevel(Level + 1);
        }

        public static void LevelDown()
        {
            Log.Message($"Уровень формы понижен.");

            if (Level - 1 < minLevel)
            {
                Log.Message("Уровень формы ниже минимального.");
                OnFormZeroLevel?.Invoke();
                return;
            }

            SetupLevel(Level - 1);
        }
    }
}