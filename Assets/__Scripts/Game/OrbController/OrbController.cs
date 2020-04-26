using UnityEngine;

[RequireComponent(typeof(OrbSpriteController))]
[RequireComponent(typeof(OrbTypeDefiner))]
/// <summary>
/// Orb controller.
/// </summary>
public sealed class OrbController : MonoBehaviour
{
	public static GameObject orb { get; private set; } = null;
	public static Transform orbTransform { get; private set; } = null;
	public static void setOrb(GameObject newOrb)
	{
		orb = newOrb;
		orbTransform = orb.transform;
		setupObject();
	}

	public static void setupObject()
	{
		OrbTypeDefiner.orbType orbType = OrbTypeDefiner.getNewOrbType(orb);

		OrbSpriteController.setupSprite(orb, orbType);
		OrbSpawnPositionController.setupPosition(orb.transform);
	}
}
