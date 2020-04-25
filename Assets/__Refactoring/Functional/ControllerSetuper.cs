using UnityEngine;

/// <summary>
/// Методы для установок объекта
/// </summary>
public abstract class ControllerSetuper: MonoBehaviour
{
	/// <summary>
	/// Установить позицию objTransform
	/// </summary>
	protected virtual void setupPosition(Transform objTransform) { }

	/// <summary>
	/// Установить размер objTransform
	/// </summary>
	protected virtual void setupScale(Transform objTransform) { }

	/// <summary>
	///  Переопределяемый метод для настройки объекта
	/// </summary>
	protected virtual void setupObject(PoolObject obj) { }
}