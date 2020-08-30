using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorController : MonoBehaviour
{
	public Color Color { get; private set; } = Color.white;

	public void SetColor(Color color)
	{
		Log.Message($"Установка цвета {color} для объекта {gameObject.name}.");
		GetComponent<SpriteRenderer>().color = color;
		Color = color;
	}
}