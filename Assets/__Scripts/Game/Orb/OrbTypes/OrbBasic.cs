using UnityEngine;

/*
 * РЕФАКТОРИТЬ 
 */

[RequireComponent(typeof(OrbMovement))]
[RequireComponent(typeof(OrbCollision))]
[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// Базовая сфера.
/// </summary>
public class OrbBasic : MonoBehaviour
{
	/// <summary>
	/// Кешированый SpriteRenerer.
	/// </summary>
	SpriteRenderer spriteRenerer = null;

	void Awake()
	{
		spriteRenerer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Тип сферы.
	/// </summary>
	public OrbTypeDefiner.orbType type { get; private set; }

	/// <summary>
	/// Установить тип сферы.
	/// </summary>
	/// <param name="newType">Тип сферы.</param>
	public void setType(OrbTypeDefiner.orbType newType) { type = newType; }

	/// <summary>
	/// Значение дельты. Дельта - это количество очков, которое прибавится или отнимется от счетчиков сфер при столкновении с формой.
	/// </summary>
	public int delta { get; protected set; } = 1;

	/// <summary>
	/// Установить дельту.
	/// </summary>
	/// <param name="delta">Дельта.</param>
	public void setDelta(int delta) { this.delta = delta; }

	/// <summary>
	/// Установить цвет.
	/// </summary>
	/// <param name="color">Цвет.</param>
	public void setColor(Color color)
	{
		if(spriteRenerer == null) Awake();

		spriteRenerer.color = color;
	}

	/// <summary>
	/// Получить цвет.
	/// </summary>
	public Color getColor()
	{
		return spriteRenerer.color;
	}

	/// <summary>
	/// Установить спрайт.
	/// </summary>
	/// <param name="sprite">Спрайт.</param>
	public void setSprite(Sprite sprite)
	{ 
		if (spriteRenerer == null) Awake();

		spriteRenerer.sprite = sprite;
	}
}
