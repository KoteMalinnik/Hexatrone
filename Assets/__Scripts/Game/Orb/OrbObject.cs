using UnityEngine;

[RequireComponent(typeof(OrbMovement))]
[RequireComponent(typeof(OrbCollision))]
[RequireComponent(typeof(ColorSetuper))]
/// <summary>
/// Объект сферы.
/// </summary>
public class OrbObject : MonoBehaviour
{
	/// <summary>
	/// Тип сферы.
	/// </summary>
	public OrbTypeDefiner.orbType type { get; private set; }

	/// <summary>
	/// Установить тип сферы.
	/// </summary>
	/// <param name="newType">Тип сферы.</param>
	public void setType(OrbTypeDefiner.orbType newType)
	{
		type = newType;
		Debug.Log($"[OrbObject] Установка типа сферы: {type}.");
	}

	/// <summary>
	/// Значение дельты. Дельта - это количество очков, которое прибавится или отнимется от счетчиков сфер при столкновении с формой.
	/// </summary>
	public int delta { get; private set; } = 1;

	/// <summary>
	/// Установить дельту.
	/// </summary>
	/// <param name="delta">Дельта.</param>
	public void setDelta(int delta)
	{
		this.delta = delta;
		Debug.Log($"[OrbObject] Установка дельты сферы: {this.delta}.");
	}
}
