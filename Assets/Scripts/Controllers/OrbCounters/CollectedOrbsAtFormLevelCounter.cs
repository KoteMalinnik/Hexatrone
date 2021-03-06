﻿using System;
using Counters;
using UnityEngine;

namespace OrbCounters
{
	public class CollectedOrbsAtFormLevelCounter : BaseOrbCounter<AscendingCounter>
	{
        public static event Action OnAllOrbsToNextFormLevelCollected = null;
        public static event Action<int> OnValueChanged = null;
        public static event Action<int> OnCounterReset = null;

        [SerializeField] ushort orbsCountAtFirstLevelNeedToCollectToLevelUp = 10;
        [SerializeField] ushort orbsCountPerLevelMultipler = 2;

        private void OnEnable()
        {
            Form.FormLevelController.OnFormLevelChange += ResetCounter;
            OrbCollision.OrbCollisionHandler.OnMatch += Add;
        }

        private void OnDisable()
        {
            Form.FormLevelController.OnFormLevelChange -= ResetCounter;
            OrbCollision.OrbCollisionHandler.OnMatch -= Add;
        }

        private void ResetCounter(int formLevel)
        {
            int orbsCountToNextFormLevel = orbsCountAtFirstLevelNeedToCollectToLevelUp * orbsCountPerLevelMultipler * formLevel;
            Initialize((ushort)orbsCountToNextFormLevel);

            OnCounterReset?.Invoke(orbsCountToNextFormLevel);
        }

        protected override void Initialize(ushort orbsCountToNextFormLevel)
		{
			Counter = new AscendingCounter(0, typeof(CollectedOrbsAtFormLevelCounter).ToString(), orbsCountToNextFormLevel);
			Counter.OnMaxValueReach += OnAllOrbsToNextFormLevelCollected;
		}

		private void Add()
        {
            Counter.Add(1);
            OnValueChanged?.Invoke(Counter.Value);
        }
	}
}