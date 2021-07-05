using UnityEngine;
using System.Collections;
using System;

namespace Core
{
    /// <summary>
    /// Класс корутины без параметров, который содержит:
    /// -информацию о том, работает ли корутина в данный момент;
    /// -действие по завершению, на которое надо подписываться;
    /// -методы для запуска и остановки корутины.
    /// </summary>
    public sealed class CommonCoroutine : ICommonCoroutine
    {
        // === Events ===

        public event Action OnFinish;


        // === Fields ===

        private Coroutine _coroutine;

        private readonly MonoBehaviour _owner;
        private readonly Func<IEnumerator> _routine;
        private readonly string _info;


        // === Properties ===

        public bool IsRunning => _coroutine != null;


        // === Constructors ===

        public CommonCoroutine(MonoBehaviour owner, Func<IEnumerator> routine)
        {
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            if (routine == null) throw new ArgumentNullException(nameof(routine));

            _owner = owner;
            _routine = routine;

            _info = $"owner: {_owner.name}, routine: {_routine.Method.Name}";
        }


        // === Methods ===

        public void Start()
        {
            Stop();

            Log.Message($"Routine will be started ({_info})");

            _coroutine = _owner.StartCoroutine(Process());
        }

        public void Stop()
        {
            if (IsRunning is false)
            {
                Log.Message($"Trying to stop coroutine that already is not running ({_info})");
                return;
            }

            _owner.StopCoroutine(_coroutine);
            _coroutine = null;

            Log.Message($"Routine was stoped ({_info})");
        }

        private IEnumerator Process()
        {
            yield return _routine.Invoke();
            _coroutine = null;

            OnFinish?.Invoke();
        }
    }
}