using UnityEngine;

/// <summary>
/// Basic orb.
/// </summary>
public class BasicOrb : MonoBehaviour
{
	/// <summary>
	/// Gets or sets the score delta.
	/// </summary>
	/// <value>The score delta.</value>
	public int scoreDelta { get; protected set; } = 0;

	/// <summary>
	/// Sets the score delta.
	/// </summary>
	/// <param name="scoreDelta">Score delta.</param>
	public void setScoreDelta(int scoreDelta) { this.scoreDelta = scoreDelta; }

	/// <summary>
	/// Gets the color of the orb.
	/// </summary>
	/// <value>The color of the orb.</value>
	public Color orbColor { get; private set; } = Color.white;

	/// <summary>
	/// Sets the color of the orb.
	/// </summary>
	/// <param name="orbColor">Orb color.</param>
	public void setOrbColor(Color orbColor) { this.orbColor = orbColor; }

	Transform cachedTransform = null;

	void Awake()
	{
		cachedTransform = transform;
	}

	[SerializeField, Range(0.01f, 10f)]
	/// <summary>
	/// The movement speed of gameObject.
	/// </summary>
	float movementSpeed = 1f;

	/// <summary>
	/// The target position.
	/// </summary>
	readonly Vector3 targetPosition = new Vector3(0, -3, 0);

	void Update()
	{
		if(!Statements.pause)
		{
			var currentPosition = cachedTransform.localPosition;
			currentPosition = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
			cachedTransform.localPosition = currentPosition;
		}
	}
}
