using Counters;

namespace OrbCounters
{
	public class CollectedOrbsInTotalCounter : BaseOrbCounter<AscendingCounter>
    {
        public CollectedOrbsInTotalCounter(ushort initialValue)
        {
            Counter = new AscendingCounter(initialValue, "TotalOrbsCollected");
        }

        public void Add(ushort delta = 1)
        {
            Counter.Add(delta);
        }
    }
}