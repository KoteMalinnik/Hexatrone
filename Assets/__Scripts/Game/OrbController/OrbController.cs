using UnityEngine;

/// <summary>
/// Orb controller.
/// </summary>
public sealed class OrbController : MonoBehaviour
{
	public static OrbTypeDefiner.orbType orbType { get; private set; } = OrbTypeDefiner.orbType.Basic;
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
		orbType = OrbTypeDefiner.getNewOrbType(orb);

		OrbSpriteController.setupSprite(orb, orbType);
		OrbSpawnPositionController.setupPosition(orb.transform);
		OrbColorSetuper.setupColor(orb);
	}
}
