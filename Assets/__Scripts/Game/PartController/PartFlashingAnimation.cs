using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// Анимация мигания объекта Part.
/// </summary>
public class PartFlashingAnimation : MonoBehaviour
{
	[SerializeField, Range(0.01f, 10f)]
	/// <summary>
	/// Скорость анимации.
	/// </summary>
	float animationSpeed = 1f;

	[SerializeField]
	/// <summary>
	/// Цвет анимации при несовпадении цветов.
	/// </summary>
	Color wrongColor = Color.black;

	[SerializeField]
	/// <summary>
	/// Цвет анимации при совпадении цветов.
	/// </summary>
	Color correctColor = Color.white;

	/// <summary>
	/// Кешированный SpriteRenderer
	/// </summary>
	SpriteRenderer spriteRenderer = null;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Анимировать объект
	/// </summary>
	/// <param name="collectCorrectOrb">Если установить <c>true</c>, то будет воспроизведена анимация при совпадении цветов.</param>
	public void animate(bool collectCorrectOrb)
	{
		//Debug.Log($"[PartFlashingAnimation] Анимация части {name}");

		Color flashColor = collectCorrectOrb ? correctColor : wrongColor;
		StartCoroutine(doubleFlashing(flashColor));
	}

	Coroutine coroutine = null;

	/// <summary>
	/// Корутина анимации мигания объекта.
	/// </summary>
	/// <param name="flashColor">Цвет анимации.</param>
	IEnumerator doubleFlashing(Color flashColor)
	{
		var sourceColor = spriteRenderer.color;

		coroutine = StartCoroutine(flashing(spriteRenderer.color, flashColor));
		yield return new WaitWhile(() => coroutine != null);
		coroutine = StartCoroutine(flashing(spriteRenderer.color, sourceColor));
	}

	/// <summary>
	/// Корутина анимации изменения цвета объекта.
	/// </summary>
	/// <param name="startColor">Начальный цвет. Обычно это SpriteRendere.color.</param>
	/// <param name="endColor">Целевой цвет.</param>
	IEnumerator flashing(Color startColor, Color endColor)
	{
		for (float T = 0.00f; spriteRenderer.color != endColor; T += animationSpeed * Time.deltaTime)
		{
			spriteRenderer.color = Color.Lerp(startColor, endColor, T);
			yield return new WaitForEndOfFrame();
		}
		coroutine = null;
	}
}
