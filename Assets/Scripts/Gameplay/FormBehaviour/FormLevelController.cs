//using OrbCounters;
//using System;
//using UnityEngine;

//namespace Form
//{
//    public class FormLevelController : MonoBehaviour
//    {
//        public static event Action<int> OnFormLevelChange = null;

//        public static event Action OnFormMaxLevel = null;

//        [Header("Ограничения уровня")]
//        [SerializeField] int minLevel = 1;
//        [SerializeField] int maxLevel = 6;

//        int level = 0;

//        private void OnEnable()
//        {
//            CollectedOrbsAtFormLevelCounter.OnAllOrbsToNextFormLevelCollected += LevelUp;
//            MissedOrbsAtFormLevelCounter.OnAllAllowedOrbsMissed += LevelDown;
//        }

//        private void OnDisable()
//        {
//            CollectedOrbsAtFormLevelCounter.OnAllOrbsToNextFormLevelCollected -= LevelUp;
//            MissedOrbsAtFormLevelCounter.OnAllAllowedOrbsMissed -= LevelDown;
//        }

//        public void SetupLevel(int level)
//        {
//            Log.Message("Установка уровня формы: " + level);
            
//            this.level = level;

//            if (this.level == maxLevel)
//            {
//                Log.Message("Достигнут максимальный уровень формы.");
//                OnFormMaxLevel?.Invoke();
//            }

//            OnFormLevelChange?.Invoke(level);
//        }

//        public void LevelUp()
//        {
//            if (level == maxLevel)
//            {
//                Log.Message("Достигнут максимальный уровень формы.");
//                return;
//            }

//            Log.Message($"Уровень формы повышен.");
//            SetupLevel(level + 1);
//        }

//        public void LevelDown()
//        {
//            Log.Message($"Уровень формы понижен.");

//            if (level - 1 < minLevel)
//            {
//                Log.Message("Уровень формы ниже минимального.");
//                Statements.GameOver = true;
//                return;
//            }

//            SetupLevel(level - 1);
//        }
//    }
//}