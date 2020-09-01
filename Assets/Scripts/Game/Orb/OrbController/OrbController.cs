using UnityEngine;

namespace Orb
{
	public class OrbController : MonoBehaviour
	{
		/// <summary>
		/// Объект сферы.
		/// </summary>
		public static OrbData orbObject { get; private set; } = null;

		/// <summary>
		/// SpriteRenerer объекта сферы.
		/// </summary>
		public static SpriteRenderer orbSpriteRenderer { get; private set; } = null;

		/// <summary>
		/// ColorSetuper объекта сферы.
		/// </summary>
		//public static ColorController orbColorSetuper { get; private set; } = null;

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
			//orbObject = orbInstance.AddComponent<Data>();

			//orbSpriteRenderer = orbObject.GetComponent<SpriteRenderer>();
			//orbColorSetuper = orbObject.GetComponent<ColorController>();
			//orbTransform = orbObject.transform;

			//setupObject();
		}

		/// <summary>
		/// Настроить сферу: тип, спрайт, позиция и цвет.
		/// </summary>
		public static void setupObject()
		{
			//OrbsGenerator.setupPosition(orbTransform);
			//OrbColorSetuper.setupColor(orbColorSetuper);

			//orbObject.setType(OrbTypeDefiner.getNewOrbType());
			//OrbSpriteController.setupSprite(orbSpriteRenderer, orbObject.type);
		}
	}
}