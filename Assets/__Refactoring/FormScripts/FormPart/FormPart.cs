using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CollisionProcessing))]
[RequireComponent(typeof(MouseButtonPressProcessing))]
/// <summary>
/// Form part controller.
/// </summary>
public class FormPart : MonoBehaviour
{
	SpriteRenderer spriteRenderer = null;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Sets the part color.
	/// </summary>
	/// <param name="partColor">Part color.</param>
	public void setPartColor(Color partColor)
	{
		if (spriteRenderer == null) Awake();
		spriteRenderer.color = partColor;
	}

	/// <summary>
	/// Gets the part color.
	/// </summary>
	/// <returns>The color.</returns>
	public Color getColor() { return spriteRenderer.color; }
}