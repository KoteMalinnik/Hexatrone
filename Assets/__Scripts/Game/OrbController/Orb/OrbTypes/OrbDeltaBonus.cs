using UnityEngine;

/// <summary>
/// Delta Bonus Orb.
/// </summary>
public class OrbDeltaBonus : OrbBasic
{
	[SerializeField]
	/// <summary>
	/// The minimum delta bonus.
	/// </summary>
	int minDeltaBonus = 2;

	[SerializeField]
	/// <summary>
	/// The maximum delta bonus.
	/// </summary>
	int maxDeltaBonus = 6;

	void Start()
	{
		int newDelta = Random.Range(minDeltaBonus, maxDeltaBonus);
		setDelta(newDelta);
	}
}