using UnityEngine;
using System;
using Counters;

namespace OrbCounters
{
	public class MissedOrbsAtFormLevelCounter : BaseOrbCounter<DescendingCounter>
	{
        public static event Action OnAllAllowedOrbsMissed = null;
        public static event Action<int> OnCounterReset = null;
        public static event Action<int> OnValueChanged = null;

        [SerializeField] ushort orbsCountAllowedToMissAtFormLevel = 5;

        private void OnEnable()
        {
            Form.FormLevelController.OnFormLevelChange += ResetCounter;
            OrbCollision.OrbCollisionHandler.OnMismatch += Subtract;
        }

        private void OnDisable()
        {
            Form.FormLevelController.OnFormLevelChange -= ResetCounter;
            OrbCollision.OrbCollisionHandler.OnMismatch -= Subtract;
        }

        private void ResetCounter(int e = 0)
        {
            Initialize(orbsCountAllowedToMissAtFormLevel);
            OnCounterReset?.Invoke(orbsCountAllowedToMissAtFormLevel);
        }

        protected override void Initialize(ushort orbsCountAllowedToMissAtFormLevel)
		{
			Counter = new DescendingCounter(orbsCountAllowedToMissAtFormLevel, typeof(MissedOrbsAtFormLevelCounter).ToString(), 0);
			Counter.OnMinValueReach += OnAllAllowedOrbsMissed;
		}

        private void Subtract()
        {
            int delta = 1;
            Counter.Subtract((ushort)delta);
            OnValueChanged?.Invoke(delta);
        }
	}
}