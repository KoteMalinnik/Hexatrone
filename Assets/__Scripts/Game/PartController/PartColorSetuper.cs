using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PartMousePressProcessing))]
[RequireComponent(typeof(PartFlashingAnimation))]
/// <summary>
/// Установщик цвета объекта Part
/// </summary>
public class PartColorSetuper : MonoBehaviour
{
	/// <summary>
	/// Кешированный SpriteRenerer.
	/// </summary>
	SpriteRenderer spriteRenderer = null;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Установить цвет.
	/// </summary>
	/// <param name="partColor">Новый цвет.</param>
	public void setPartColor(Color partColor)
	{
		if (spriteRenderer == null) Awake();
		spriteRenderer.color = partColor;
	}

	/// <summary>
	/// Получить цвет.
	/// </summary>
	public Color getColor() { return spriteRenderer.color; }
}