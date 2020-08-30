using System.Collections;
using UnityEngine;

namespace Part
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class Flashing : MonoBehaviour
	{
		#region Fields
		[Range(0.01f, 10f)]
		[SerializeField] float animationSpeed = 1f;

		[SerializeField] Color c_incorrectColorCollected = Color.black;
		[SerializeField] Color c_correctColorCollected = Color.white;

		CommonCoroutine flashingOneShotRoutine = null;
		CommonCoroutine flashingDoubleShotRoutine = null;
        #endregion

        void Flash(bool correctColorCollected)
		{
            Log.Message("Запуск анимации мигания объекта: " + name);

            Color flashColor = correctColorCollected ? c_correctColorCollected : c_incorrectColorCollected;
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

			flashingDoubleShotRoutine = new CommonCoroutine(this, () => FlashDoubleShot(spriteRenderer, flashColor));
			flashingDoubleShotRoutine.OnFinish += () => flashingDoubleShotRoutine = null;
			flashingDoubleShotRoutine.Start();
		}

		IEnumerator FlashDoubleShot(SpriteRenderer spriteRenderer, Color targetColor)
		{
			Log.Message("Начало двойной анимации мигания.");

			var startColor = spriteRenderer.color;

			flashingOneShotRoutine = new CommonCoroutine(this, () => FlashOneShot(spriteRenderer, targetColor));
			flashingOneShotRoutine.Start();

			yield return new WaitWhile(() => flashingOneShotRoutine.IsRunning);

			flashingOneShotRoutine = new CommonCoroutine(this, () => FlashOneShot(spriteRenderer, startColor));
			flashingOneShotRoutine.Start();

			yield return new WaitWhile(() => flashingOneShotRoutine.IsRunning);

			flashingOneShotRoutine = null;
			Log.Message("Конец двойной анимации мигания.");
		}

		IEnumerator FlashOneShot(SpriteRenderer spriteRenderer, Color targetColor)
		{
			Log.Message("Начало одиночной анимации мигания.");

			var startColor = spriteRenderer.color;
			for (float T = 0.00f; !spriteRenderer.color.Equals(targetColor); T += animationSpeed * Time.deltaTime)
			{
				spriteRenderer.color = Color.Lerp(startColor, targetColor, T);
				yield return new WaitForEndOfFrame();
			}

			Log.Message("Конец одиночной анимации мигания.");
		}
	}
}