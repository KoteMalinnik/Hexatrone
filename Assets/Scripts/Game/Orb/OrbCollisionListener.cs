using System;
using UnityEngine;

namespace Orb
{
	public class OrbCollisionListener : MonoBehaviour
	{
		public static event Action<Color> OnOrbCollisionWithPart = null;

		void OnTriggerEnter2D(Collider2D collision)
		{
			Log.Message("Столкновение с " + collision.name);

			Color partColor = collision.GetComponent<SpriteRenderer>().color;
			OnOrbCollisionWithPart?.Invoke(partColor);
		}
	}
}