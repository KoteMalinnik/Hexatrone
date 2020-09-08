using UnityEngine;
using System;
using Counters;

namespace OrbCounters
{
	public class MissedOrbsAtFormLevelCounter : BaseOrbCounter<DescendingCounter>
	{
        #region Events
        public static event Action<int> OnAllAllowedOrbsMissed = null;
        public static event Action<int> OnCounterReset = null;
        #endregion

        #region Fields
        [SerializeField] ushort orbsCountAllowedToMissAtFormLevel = 5;
        #endregion

        #region MonoBehaviour Callbacks
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
        #endregion

        private void ResetCounter(int e = 0)
        {
            Initialize(orbsCountAllowedToMissAtFormLevel);
            OnCounterReset?.Invoke(orbsCountAllowedToMissAtFormLevel);
        }

        protected override void Initialize(ushort orbsCountAllowedToMissAtFormLevel)
		{
			Counter = new DescendingCounter(orbsCountAllowedToMissAtFormLevel, "MissedOrbsAtFormLevel", 0);
			Counter.OnMinValueReach += InvokeEvent_OnAllAllowedOrbsMissed;
		}

        private void Subtract() => Counter.Subtract(1);

        private void InvokeEvent_OnAllAllowedOrbsMissed()
        {
            OnAllAllowedOrbsMissed?.Invoke(orbsCountAllowedToMissAtFormLevel);
        }
	}
}