using UnityEngine;

[RequireComponent(typeof(OrbMovement))]
[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// Basic orb.
/// </summary>
public class BasicOrb : MonoBehaviour
{
	SpriteRenderer spriteRenerer = null;

	void Awake()
	{
		spriteRenerer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Gets or sets the delta. Delta is a value which define deifference of the score on collecting orb
	/// </summary>
	public int delta { get; protected set; } = 1;

	/// <summary>
	/// Sets the delta.
	/// </summary>
	/// <param name="delta"> delta.</param>
	public void setDelta(int delta) { this.delta = delta; }

	/// <summary>
	/// Sets the orb color.
	/// </summary>
	/// <param name="color">Orb color.</param>
	public void setColor(Color color)
	{
		if(spriteRenerer == null) Awake();

		spriteRenerer.color = color;
	}

	/// <summary>
	/// Gets the orb color.
	/// </summary>
	/// <returns>Orb color.</returns>
	public Color getColor()
	{
		return spriteRenerer.color;
	}

	/// <summary>
	/// Sets the sprite.
	/// </summary>
	/// <param name="sprite">Sprite.</param>
	public void setSprite(Sprite sprite)
	{ 
		if (spriteRenerer == null) Awake();

		spriteRenerer.sprite = sprite;
	}
}
