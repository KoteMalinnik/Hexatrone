using System.Collections;
using UnityEngine;

public class FlashingAnimation : MonoBehaviour
{
	[SerializeField, Range(0.01f, 10f)]
	float animationSpeed = 1f;

	SpriteRenderer spriteRenderer = null;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void animate()
	{
		Debug.Log($"[FlashingAnimation] Анимация части {name}");

		StartCoroutine(doubleFlashing());
	}

	Coroutine coroutine = null;
	IEnumerator doubleFlashing()
	{
		var sourceColor = spriteRenderer.color;

		coroutine = StartCoroutine(flashing(spriteRenderer.color, Color.white));
		yield return new WaitWhile(() => coroutine != null);
		coroutine = StartCoroutine(flashing(spriteRenderer.color, sourceColor));
	}

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
