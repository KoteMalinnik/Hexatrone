using UnityEngine;

/// <summary>
/// Вращение объекта с постоянной скоростью.
/// </summary>
public class ObjectRotation : MonoBehaviour
{
	/// <summary>
	/// Кешированный Transform.
	/// </summary>
	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = GetComponent<Transform>();
	}

	/// <summary>
	/// Коэффициент скорости вращения.
	/// </summary>
	const float deltaAngle = 150;

	/// <summary>
	/// Хранит вращение объекта.
	/// </summary>
	Vector3 rotation = Vector3.zero;

	void Update()
	{
		rotation = cachedTransform.localRotation.eulerAngles;
		rotation.z += deltaAngle * Time.deltaTime;

		cachedTransform.localRotation = Quaternion.Euler(rotation);
	}
}
