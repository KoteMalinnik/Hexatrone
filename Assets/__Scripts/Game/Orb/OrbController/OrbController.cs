using UnityEngine;

[RequireComponent(typeof(SpriteController))]
/// <summary>
/// Orb controller.
/// </summary>
public sealed class OrbController : MonoBehaviour
{
	public static void setupObject(ref GameObject orb)
	{
		OrbTypeDefiner.orbType orbType = OrbTypeDefiner.getNewOrbType(ref orb);

		SpriteController.setupSprite(ref orb, orbType);
		SpawnController.setupPosition(orb.transform);
	}
}
