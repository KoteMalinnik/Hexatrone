using System.Collections;
using UnityEngine;

/// <summary>
/// Form rotation.
/// </summary>
public class FormRotation : MonoBehaviour
{
	/// <summary>
	/// Показывает, вращается ли форма в данный момент
	/// </summary>
	/// <value><c>true</c> if rotation state; otherwise, <c>false</c>.</value>
	public static bool rotating {get; private set; } = false;

	[SerializeField, Range(0.01f, 10f)]
	float _animationSpeed = 1f;
	static float animationSpeed = 1f;

	static FormRotation instance = null;
	static Transform cachedTransform = null;
	void Awake()
	{
		instance = this;
		cachedTransform = transform;
		animationSpeed = _animationSpeed;
	}

	/// <summary>
	/// Rotates the form.
	/// </summary>
	/// <param name="angleY">Angle y.</param>
	/// <param name="angleZ">Angle z.</param>
	public static void rotate(float angleY, float angleZ = 0)
	{
		Debug.Log($"[RotationAnimaton] Вращение");
		instance.StartCoroutine(rotation(angleY, angleZ));
	}

	static IEnumerator rotation(float angleY, float angleZ)
	{
		rotating = true;

		var targetRotation = Quaternion.Euler(0.0f, angleY, angleZ);

		for (float T = 0.00f; Quaternion.Angle(cachedTransform.rotation, targetRotation) > 0.1f ; T += animationSpeed * Time.deltaTime)
		{
			cachedTransform.rotation = Quaternion.Lerp(cachedTransform.rotation, targetRotation, T);
			yield return new WaitForEndOfFrame();
		}

		cachedTransform.rotation = targetRotation;
		rotating = false;
		Debug.Log($"[RotationAnimaton] Вращение завершено");
	}
}
