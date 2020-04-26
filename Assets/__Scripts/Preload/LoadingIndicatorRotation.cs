using UnityEngine;

/// <summary>
/// Loading indicator rotation.
/// </summary>
public class LoadingIndicatorRotation : MonoBehaviour
{
	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = GetComponent<Transform>();
	}

	/// <summary>
	/// The delta angle of rotation Z axies.
	/// </summary>
	const float deltaAngle = 150;

	Vector3 rotation = Vector3.zero;

	void Update()
	{
		rotation = cachedTransform.localRotation.eulerAngles;
		rotation.z += deltaAngle * Time.deltaTime;

		cachedTransform.localRotation = Quaternion.Euler(rotation);
	}
}
