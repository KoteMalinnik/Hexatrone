using System.Collections;
using UnityEngine;

/// <summary>
/// Form rotation.
/// </summary>
public class FormRotation : MonoBehaviour
{
	[SerializeField, Range(0.01f, 10f)]
	float animationSpeed = 1f;

	Transform cachedTransform = null;
	void Awake()
	{
		cachedTransform = transform;
	}

	/// <summary>
	/// Rotates the form.
	/// </summary>
	/// <param name="angleY">Angle y.</param>
	/// <param name="angleZ">Angle z.</param>
	public void rotate(float angleY, float angleZ = 0)
	{
		Debug.Log($"[RotationAnimaton] Вращение {name}");
		StartCoroutine(rotation(angleY, angleZ));
	}

	IEnumerator rotation(float angleY, float angleZ)
	{
		var startRotation = cachedTransform.localRotation;
		var targetRotation = Quaternion.Euler(0.0f, angleY, angleZ);

		for (float T = 0.00f; cachedTransform.localRotation != targetRotation; T += animationSpeed * Time.deltaTime)
		{
			cachedTransform.localRotation = Quaternion.Lerp(startRotation, targetRotation, T);
			yield return new WaitForEndOfFrame();
		}
	}
}
