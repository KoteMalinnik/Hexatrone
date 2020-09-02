using System;
using Counters;

namespace OrbCounters
{
	public class CollectedOrbsAtFormLevelCounter : BaseOrbCounter<AscendingCounter>
	{
		public CollectedOrbsAtFormLevelCounter(ushort orbsCountToNextFormLevel, Action OnOrbsCountToNextFormLevelCollected)
		{
			Counter = new AscendingCounter(0, "OrbsAtFormLevelCollected", orbsCountToNextFormLevel);
			Counter.OnMaxValueReach += OnOrbsCountToNextFormLevelCollected;
		}

		public void Add(ushort delta = 1)
		{
			Counter.Add(delta);
		}
	}
}