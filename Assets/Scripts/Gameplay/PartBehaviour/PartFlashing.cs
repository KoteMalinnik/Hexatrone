//using System.Collections;
//using UnityEngine;

//namespace PartBehaviour
//{
//	[RequireComponent(typeof(SpriteRenderer))]
//	public class PartFlashingAnimation : MonoBehaviour
//	{
//		// --- Fields ---

//		[Range(0.01f, 10f)]
//		[SerializeField] private float animationSpeed = 1f;

//		[SerializeField] private Color matchedColor = Color.white;
//		[SerializeField] private Color mismatchedColor = Color.black;

//		private CommonCoroutine flashingOneShotRoutine = null;
//		private CommonCoroutine flashingDoubleShotRoutine = null;

//		private Color partColor;

//		// --- Properties ---

//		public Color PartColor => partColor;

//		// --- Methods ---

//		public void SetColor(Color color)
//        {
//			partColor = color;
//			Log.Message($"Цвет части {name}: " + partColor.ToString());
//        }

//        public void Flash(bool match)
//		{
//			Log.Message("Запуск анимации мигания объекта: " + name);

//			if (flashingDoubleShotRoutine != null)
//            {
//				Log.Message("Произведена попытка запуска двойной анимации мигания. Прошлая еще не завершила свое действие.");
//				return;
//            }

//            Color flashColor = match ? matchedColor : mismatchedColor;
//			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

//			flashingDoubleShotRoutine = new CommonCoroutine(this, () => FlashDoubleShot(spriteRenderer, flashColor));
//			flashingDoubleShotRoutine.OnFinish += () => flashingDoubleShotRoutine = null;
//			flashingDoubleShotRoutine.Start();
//		}

//		// --- Coroutines ---

//		private IEnumerator FlashDoubleShot(SpriteRenderer spriteRenderer, Color targetColor)
//		{
//			Log.Message("Начало двойной анимации мигания.");

//			var startColor = spriteRenderer.color;

//			flashingOneShotRoutine = new CommonCoroutine(this, () => FlashOneShot(spriteRenderer, targetColor));
//			flashingOneShotRoutine.Start();

//			yield return new WaitWhile(() => flashingOneShotRoutine.IsRunning);

//			flashingOneShotRoutine = new CommonCoroutine(this, () => FlashOneShot(spriteRenderer, startColor));
//			flashingOneShotRoutine.Start();

//			yield return new WaitWhile(() => flashingOneShotRoutine.IsRunning);

//			flashingOneShotRoutine = null;
//			Log.Message("Конец двойной анимации мигания.");
//		}

//		private IEnumerator FlashOneShot(SpriteRenderer spriteRenderer, Color targetColor)
//		{
//			Log.Message("Начало одиночной анимации мигания.");

//			var startColor = spriteRenderer.color;
//			for (float T = 0.00f; !spriteRenderer.color.Equals(targetColor); T += animationSpeed * Time.deltaTime)
//			{
//				spriteRenderer.color = Color.Lerp(startColor, targetColor, T);
//				yield return new WaitForEndOfFrame();
//			}

//			Log.Message("Конец одиночной анимации мигания.");
//		}
//	}
//}