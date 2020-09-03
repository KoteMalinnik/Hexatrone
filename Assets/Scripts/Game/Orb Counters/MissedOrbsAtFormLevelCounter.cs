using UnityEngine;
using System;
using Counters;

namespace OrbCounters
{
	public class MissedOrbsAtFormLevelCounter : BaseOrbCounter<DescendingCounter>
	{
        #region Events
        public static event Action OnAllAllowedOrbsMissed = null;
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

        private void ResetCounter(int e)
        {
            Initialize(orbsCountAllowedToMissAtFormLevel);
        }

        protected override void Initialize(ushort orbsCountAllowedToMissAtFormLevel)
		{
			Counter = new DescendingCounter(orbsCountAllowedToMissAtFormLevel, "MissedOrbsAtFormLevel", 0);
			Counter.OnMinValueReach += OnAllAllowedOrbsMissed.Invoke;
		}

        private void Subtract() => Counter.Subtract(1);
	}
}