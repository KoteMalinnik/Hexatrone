﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// Flashing animation.
/// </summary>
public class PartFlashingAnimation : MonoBehaviour
{
	[SerializeField, Range(0.01f, 10f)]
	float animationSpeed = 1f;

	[SerializeField]
	Color wrongColor = Color.black;

	[SerializeField]
	Color correctColor = Color.white;

	SpriteRenderer spriteRenderer = null;
	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void animate(bool collectCorrectOrb)
	{
		//Debug.Log($"[PartFlashingAnimation] Анимация части {name}");

		Color flashColor = collectCorrectOrb ? correctColor : wrongColor;
		StartCoroutine(doubleFlashing(flashColor));
	}

	Coroutine coroutine = null;
	IEnumerator doubleFlashing(Color flashColor)
	{
		var sourceColor = spriteRenderer.color;

		coroutine = StartCoroutine(flashing(spriteRenderer.color, flashColor));
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
