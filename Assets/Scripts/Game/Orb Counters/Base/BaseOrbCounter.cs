using Counters;
using System;

namespace OrbCounters
{
	public abstract class BaseOrbCounter<T> where T : BaseCounter
	{
        #region Properties
        protected T Counter { get; set; } = null;
        public ushort Value => Counter.Value;
        #endregion

        public void AddListenerOnValueChanged(Action<int> action)
        {
            Counter.OnValueChanged += action;
        }

        public void RemoveListenerOnValueChanged(Action<int> action)
        {
            Counter.OnValueChanged -= action;
        }
    }

}