using Counters;

namespace OrbCounters
{
	public class CollectedOrbsInTotalCounter : BaseOrbCounter<AscendingCounter>
    {
        #region MonoBehaviour Callbacks
        private void Awake()
        {
            Initialize(0);
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

        private void Add() => Counter.Add(1);
    }
}