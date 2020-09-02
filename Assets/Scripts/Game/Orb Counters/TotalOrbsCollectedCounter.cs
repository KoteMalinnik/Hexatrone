using Counters;
using System;

namespace OrbCounters
{
	public class TotalOrbsCollectedCounter
	{
        #region Properties
        AscendingCounter counter { get; } = null;
        public ushort Value => counter.Value;
        #endregion

        public TotalOrbsCollectedCounter(ushort initialValue)
        {
            counter = new AscendingCounter(initialValue, "TotalOrbsCollected");
        }

        public void Add(ushort delta = 1)
        {
            counter.Add(delta);
        }

        public void AddListener(Action<int> action)
        {
            counter.OnValueChanged += action;
        }

        public void RemoveListener(Action<int> action)
        {
            counter.OnValueChanged -= action;
        }
    }
}