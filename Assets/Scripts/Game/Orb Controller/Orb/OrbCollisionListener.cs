using UnityEngine;
using System;
using OrbCollision;

namespace Orb
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class OrbCollisionListener : MonoBehaviour
	{
		#region Events
		public static event Action<CollisionData> OnCollision = null;
		#endregion

		void OnTriggerEnter2D(Collider2D collision)
		{
			Log.Message("Столкновение с " + collision.name);

			Color partColor = collision.GetComponent<SpriteRenderer>().color;
			Color orbColor = GetComponent<SpriteRenderer>().color;
			Part.PartFlashing partFlashing = collision.GetComponent<Part.PartFlashing>();

			OnCollision?.Invoke(new CollisionData(partColor, orbColor, partFlashing));

			Log.Message("Уничтожение сферы.");
			Destroy(gameObject);
		}
	}
}