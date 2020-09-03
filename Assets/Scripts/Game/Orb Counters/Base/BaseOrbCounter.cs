﻿using Counters;
using System;

namespace OrbCounters
{
	public abstract class BaseOrbCounter<T> : UnityEngine.MonoBehaviour where T : BaseCounter
	{
        #region Properties
        protected T Counter { get; set; } = null;
        public ushort Value => Counter.Value;
        #endregion

        protected abstract void Initialize(ushort initialValue);

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