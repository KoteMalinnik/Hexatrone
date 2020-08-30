using System;
using UnityEngine;

namespace Orb
{
	public class CollisionListener : MonoBehaviour
	{
		public static event Action<Color> OnOrbCollisionWithPart = null;

		void OnTriggerEnter2D(Collider2D collision)
		{
			Log.Message("Столкновение с " + collision.name);

			Color collisedPartColor = collision.GetComponent<ColorController>().Color;
			OnOrbCollisionWithPart?.Invoke(collisedPartColor);
		}
	}
}