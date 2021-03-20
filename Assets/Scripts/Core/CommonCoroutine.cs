using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Класс корутины без параметров, который содержит:
/// -информацию о том, работает ли корутина в данный момент;
/// -действие по завершению, на которое надо подписываться;
/// -методы для запуска и остановки корутины.
/// </summary>
public sealed class CommonCoroutine
{
    /// <summary>
    /// Действие, которое необходимо совершить по завершению корутины.
    /// </summary>
    public event Action OnFinish;

    Coroutine coroutine = null;

    MonoBehaviour Owner { get; } = null;
    Func<IEnumerator> Routine { get; } = null;

    /// <summary>
    /// Вернет true, если корутина в данный момент выполняется.
    /// </summary>
    public bool IsRunning => coroutine != null;

    /// <summary>
    /// Создаст экземпляр корутины.
    /// </summary>
    /// <param name="owner">Владелец корутины, на котором будет произведен ее запуск.</param>
    /// <param name="routine">Корутина.</param>
    public CommonCoroutine(MonoBehaviour owner, Func<IEnumerator> routine)
    {
        if (owner == null || routine == null) throw new ArgumentNullException();

        Owner = owner;
        Routine = routine;
    }

    /// <summary>
    /// Запустить выполнение корутины.
    /// </summary>
    public void Start()
    {
        Stop();
        coroutine = Owner.StartCoroutine(Process());
    }

    /// <summary>
    /// Остановить выполнение корутины.
    /// </summary>
    public void Stop()
    {
        if (IsRunning)
        {
            Owner.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator Process()
    {
        yield return Routine.Invoke();
        coroutine = null;

        OnFinish?.Invoke();
    }
}
