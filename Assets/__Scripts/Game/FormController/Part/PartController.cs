using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PartMousePressProcessing))]
[RequireComponent(typeof(PartFlashingAnimation))]
/// <summary>
/// Form part controller.
/// </summary>
public class PartController : MonoBehaviour
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