using UnityEngine;

[RequireComponent(typeof(OrbSpriteController))]
[RequireComponent(typeof(OrbTypeDefiner))]
/// <summary>
/// Orb controller.
/// </summary>
public sealed class OrbController : MonoBehaviour
{
	public static void setupObject(ref GameObject orb)
	{
		OrbTypeDefiner.orbType orbType = OrbTypeDefiner.getNewOrbType(ref orb);

		OrbSpriteController.setupSprite(ref orb, orbType);
		OrbSpawnController.setupPosition(orb.transform);
	}
}
