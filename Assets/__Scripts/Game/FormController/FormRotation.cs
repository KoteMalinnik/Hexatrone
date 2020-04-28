using System.Collections;
using UnityEngine;

/// <summary>
/// Вращение формы.
/// </summary>
public static class FormRotation
{
	/// <summary>
	/// Показывает, вращается ли форма в данный момент. True, если корутина вращения запущена.
	/// </summary>
	public static bool rotating {get; private set; } = false;

	/// <summary>
	/// Скорость вращения.
	/// </summary>
	static float animationSpeed = 5;

	/// <summary>
	/// Запустить вращение к требуемому углу.
	/// </summary>
	/// <param name="angleY">Целевой угол по оси Y.</param>
	/// <param name="angleZ">Целевой угол по оси Z.</param>
	public static void rotate(float angleY, float angleZ = 0)
	{
		Debug.Log($"[RotationAnimaton] Вращение");
		FormController.instance.StartCoroutine(rotation(angleY, angleZ));
	}

	/// <summary>
	/// Корутина вращения формы.
	/// </summary>
	/// <param name="angleY">Целевой угол по оси Y.</param>
	/// <param name="angleZ">Целевой угол по оси Z.</param>
	static IEnumerator rotation(float angleY, float angleZ)
	{
		rotating = true;

		Transform objTransform = FormController.cachedTransform;
		var targetRotation = Quaternion.Euler(0.0f, angleY, angleZ);

		for (float T = 0.00f; Quaternion.Angle(objTransform.rotation, targetRotation) > 0.1f ; T += animationSpeed * Time.deltaTime)
		{
			objTransform.rotation = Quaternion.Lerp(objTransform.rotation, targetRotation, T);
			yield return new WaitForEndOfFrame();
		}

		objTransform.rotation = targetRotation;
		rotating = false;
		Debug.Log($"[RotationAnimaton] Вращение завершено");
	}
}
