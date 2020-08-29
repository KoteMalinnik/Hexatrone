using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// Установщик цвета объекта
/// </summary>
public class ColorSetuper : MonoBehaviour
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
	/// <param name="newColor">Новый цвет.</param>
	public void setColor(Color newColor)
	{
		if (spriteRenderer == null) Awake();
		spriteRenderer.color = newColor;
	}

	/// <summary>
	/// Получить цвет.
	/// </summary>
	public Color getColor() { return spriteRenderer.color; }
}