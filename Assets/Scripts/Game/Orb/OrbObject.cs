using UnityEngine;

[RequireComponent(typeof(OrbMovement))]
[RequireComponent(typeof(OrbCollision))]
[RequireComponent(typeof(ColorSetuper))]
/// <summary>
/// Объект сферы.
/// </summary>
public class OrbObject : MonoBehaviour
{
	public OrbObject(int delta, OrbTypeDefiner.orbType type)
	{
		setDelta(delta);
		setType(type);
	}

	/// <summary>
	/// Тип сферы.
	/// </summary>
	public OrbTypeDefiner.orbType type { get; private set; }

	/// <summary>
	/// Установить тип сферы.
	/// </summary>
	/// <param name="type">Тип сферы.</param>
	public void setType(OrbTypeDefiner.orbType type)
	{
		Debug.Log($"[OrbObject] Установка типа сферы: {type}.");
		this.type = type;

		if (type != OrbTypeDefiner.orbType.DeltaBonus) setDelta(1);
		else setDelta(Random.Range(2, 5));
	}

	/// <summary>
	/// Значение дельты. Дельта - это количество очков, которое прибавится или отнимется от счетчиков сфер при столкновении с формой.
	/// </summary>
	public int delta { get; private set; } = 1;

	/// <summary>
	/// Установить дельту.
	/// </summary>
	/// <param name="newDelta">Дельта.</param>
	void setDelta(int newDelta)
	{
		Debug.Log($"[OrbObject] Установка дельты сферы: {newDelta}.");
		delta = newDelta;
	}
}
