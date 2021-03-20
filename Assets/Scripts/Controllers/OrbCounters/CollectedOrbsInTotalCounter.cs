using Counters;
using System;

namespace OrbCounters
{
	public class CollectedOrbsInTotalCounter : BaseOrbCounter<AscendingCounter>
    {
        public static event Action<int> OnNewOrbCollected = null;

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