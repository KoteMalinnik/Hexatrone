using UnityEngine;

/// <summary>
/// Orb movement.
/// </summary>
public class OrbMovement : MonoBehaviour
{
	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = transform;
	}

	[SerializeField, Range(0.01f, 10f)]
	/// <summary>
	/// The movement speed of gameObject.
	/// </summary>
	float movementSpeed = 2f;

	/// <summary>
	/// The target position.
	/// </summary>
	readonly Vector3 targetPosition = new Vector3(0, -9, 0);

	void Update()
	{
		if (!Statements.pause)
		{
			var currentPosition = cachedTransform.localPosition;
			currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
			cachedTransform.localPosition = currentPosition;
		}
	}
}