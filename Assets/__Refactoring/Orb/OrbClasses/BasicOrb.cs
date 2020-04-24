using UnityEngine;

[RequireComponent(typeof(OrbMovement))]
[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// Basic orb.
/// </summary>
public class BasicOrb : MonoBehaviour
{
	/// <summary>
	/// Gets or sets the delta. Delta is a value which define deifference of the score on collecting orb
	/// </summary>
	public int delta { get; protected set; } = 1;

	/// <summary>
	/// Gets the color of the orb.
	/// </summary>
	public Color orbColor { get; private set; } = Color.white;


	/// <summary>
	/// Sets the delta.
	/// </summary>
	/// <param name="delta"> delta.</param>
	public void setDelta(int delta) { this.delta = delta; }

	/// <summary>
	/// Sets the color of the orb.
	/// </summary>
	/// <param name="orbColor">Orb color.</param>
	public void setOrbColor(Color orbColor) { this.orbColor = orbColor; }

	/// <summary>
	/// Sets the sprite.
	/// </summary>
	/// <param name="sprite">Sprite.</param>
	public void setSprite(Sprite sprite) { spriteRenerer.sprite = sprite; }


	SpriteRenderer spriteRenerer = null;

	void Awake()
	{
		spriteRenerer = GetComponent<SpriteRenderer>();
	}
}
