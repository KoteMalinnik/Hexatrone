using System;
using Counters;

namespace OrbCounters
{
	public class MissedOrbsAtFormLevelCounter
	{
		#region Properties
		DescendingCounter counter { get; } = null;
		public ushort Value => counter.Value;
		#endregion

		public MissedOrbsAtFormLevelCounter(ushort orbsAllowedToMissAtFormLevelCount, Action OnAllAllowedOrbsMissed)
		{
			counter = new DescendingCounter(orbsAllowedToMissAtFormLevelCount, "MissedOrbsAtFormLevel", 0);
			counter.OnMinValueReach += OnAllAllowedOrbsMissed;
		}

		public void Subtract(ushort delta = 1)
		{
			counter.Subtract(delta);
		}

		public void AddListenerOnValueChanged(Action<int> action)
		{
			counter.OnValueChanged += action;
		}

		public void RemoveListenerOnValueChanged(Action<int> action)
		{
			counter.OnValueChanged -= action;
		}
	}
}