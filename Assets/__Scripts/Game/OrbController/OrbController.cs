using UnityEngine;

/// <summary>
/// Контроллер сферы. 
/// </summary>
public sealed class OrbController : MonoBehaviour
{
	/// <summary>
	/// Объект сферы.
	/// </summary>
	public static OrbObject orbObject { get; private set; } = null;

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
	/// <param name="orbInstance">Сфера.</param>
	public static void setOrb(GameObject orbInstance)
	{
		orbObject = orbInstance.GetComponent<OrbObject>();

		orbSpriteRenderer = orbObject.GetComponent<SpriteRenderer>();
		orbColorSetuper = orbObject.GetComponent<ColorSetuper>();
		orbTransform = orbObject.transform;

		setupObject();
	}

	/// <summary>
	/// Настроить сферу: тип, спрайт, позиция и цвет.
	/// </summary>
	public static void setupObject()
	{
		OrbSpawnPositionController.setupPosition(orbTransform);
		OrbColorSetuper.setupColor(orbColorSetuper);

		orbObject.setType(OrbTypeDefiner.getNewOrbType());
		OrbSpriteController.setupSprite(orbSpriteRenderer, orbObject.type);
	}
}
