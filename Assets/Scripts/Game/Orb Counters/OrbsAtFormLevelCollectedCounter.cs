using System;
using Counters;

namespace OrbCounters
{
	public class OrbsAtFormLevelCollectedCounter
	{
		#region Properties
		AscendingCounter counter { get; } = null;
		public ushort Value => counter.Value;
		#endregion

		public OrbsAtFormLevelCollectedCounter(ushort orbsCountToNextFormLevel, Action OnOrbsCountToNextFormLevelCollected)
		{
			counter = new AscendingCounter(0, "OrbsAtFormLevelCollected", orbsCountToNextFormLevel);
			counter.OnMaxValueReach += OnOrbsCountToNextFormLevelCollected;
		}

		public void Add(ushort delta = 1)
		{
			counter.Add(delta);
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