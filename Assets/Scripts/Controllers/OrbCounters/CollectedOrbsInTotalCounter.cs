using Counters;
using System;

namespace OrbCounters
{
	public class CollectedOrbsInTotalCounter : BaseOrbCounter<AscendingCounter>
    {
        #region Events
        public static event Action<int> OnNewOrbCollected = null;
        #endregion

        #region MonoBehaviour Callbacks
        private void Awake()
        {
            int initCount = 0;
            Initialize((ushort)initCount);
            OnNewOrbCollected?.Invoke(initCount);
        }

        private void OnEnable()
        {
            OrbCollision.OrbCollisionHandler.OnMatch += Add;
        }

        private void OnDisable()
        {
            OrbCollision.OrbCollisionHandler.OnMatch -= Add;
        }
        #endregion

        protected override void Initialize(ushort initialValue)
        {
            Counter = new AscendingCounter(initialValue, "TotalOrbsCollected");
        }

        private void Add()
        {
            Counter.Add(1);
            OnNewOrbCollected?.Invoke(Counter.Value);
        }
    }
}