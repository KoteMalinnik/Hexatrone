using System;
using Counters;

namespace OrbCounters
{
	public class MissedOrbsAtFormLevelCounter : BaseOrbCounter<DescendingCounter>
	{
		public MissedOrbsAtFormLevelCounter(ushort orbsAllowedToMissAtFormLevelCount, Action OnAllAllowedOrbsMissed)
		{
			Counter = new DescendingCounter(orbsAllowedToMissAtFormLevelCount, "MissedOrbsAtFormLevel", 0);
			Counter.OnMinValueReach += OnAllAllowedOrbsMissed;
		}

		public void Subtract(ushort delta = 1)
		{
			Counter.Subtract(delta);
		}
	}
}