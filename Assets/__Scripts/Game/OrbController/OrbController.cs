using UnityEngine;

/// <summary>
/// Контроллер сферы. 
/// </summary>
public sealed class OrbController : MonoBehaviour
{
	/// <summary>
	/// Тип сферы.
	/// </summary>
	public static OrbTypeDefiner.orbType orbType { get; private set; } = OrbTypeDefiner.orbType.Basic;

	/// <summary>
	/// Объект сферы.
	/// </summary>
	public static GameObject orb { get; private set; } = null;

	/// <summary>
	/// SpriteRenerer объекта сферы.
	/// </summary>
	public static SpriteRenderer orbSpriteRenderer { get; private set; } = null;

	/// <summary>
	/// ColorSetuper объекта сферы.
	/// </summary>
	public static ColorSetuper orbColorSetuper { get; private set; } = null;

	/// <summary>
	/// Transform объекта сферы.
	/// </summary>
	/// <value>The orb transform.</value>
	public static Transform orbTransform { get; private set; } = null;

	/// <summary>
	/// Установить сферу.
	/// </summary>
	/// <param name="newOrb">Сфера.</param>
	public static void setOrb(GameObject newOrb)
	{
		orb = newOrb;

		orbTransform = orb.transform;
		orbSpriteRenderer = orb.GetComponent<SpriteRenderer>();
		orbColorSetuper = orb.GetComponent<ColorSetuper>();

		setupObject();
	}

	/// <summary>
	/// Настроить сферу: тип, спрайт, позиция и цвет.
	/// </summary>
	public static void setupObject()
	{
		OrbSpawnPositionController.setupPosition(orbTransform);

		orbType = OrbTypeDefiner.getNewOrbType(orb);
		OrbSpriteController.setupSprite(orbSpriteRenderer, orbType);
		OrbColorSetuper.setupColor(orbColorSetuper);
	}
}
