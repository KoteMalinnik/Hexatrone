using System;
using Counters;
using UnityEngine;

namespace OrbCounters
{
	public class CollectedOrbsAtFormLevelCounter : BaseOrbCounter<AscendingCounter>
	{
        #region Events
        public static event Action OnAllOrbsToNextFormLevelCollected = null;
        #endregion

        #region Fields
        [SerializeField] ushort orbsCountAtFirstLevelNeedToCollectToLevelUp = 10;
        [SerializeField] ushort orbsCountPerLevelMultipler = 2;
        #endregion

        #region MonoBehaviour Callbacks
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
        #endregion

        private void ResetCounter(int formLevel)
        {
            Initialize((ushort)(orbsCountAtFirstLevelNeedToCollectToLevelUp * orbsCountPerLevelMultipler * formLevel));
        }

        protected override void Initialize(ushort orbsCountToNextFormLevel)
		{
			Counter = new AscendingCounter(0, "OrbsAtFormLevelCollected", orbsCountToNextFormLevel);
			Counter.OnMaxValueReach += OnAllOrbsToNextFormLevelCollected.Invoke;
		}

		private void Add() => Counter.Add(1);
	}
}