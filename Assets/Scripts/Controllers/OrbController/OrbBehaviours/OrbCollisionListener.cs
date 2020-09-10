using UnityEngine;
using System;
using OrbCollision;
using Part;

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

			Color partColor = Color.black;
			Color orbColor = GetComponent<SpriteRenderer>().color;
			
			PartFlashing partFlashing = null;

			if (!collision.TryGetComponent(out partFlashing))
			{
				Log.Error("Не удалось получить компонент PartFlashing части формы: " + collision.name);
			}
			else
            {
				partColor = partFlashing.PartColor;
            }

			try
            {
				CollisionData collisionData = new CollisionData(partColor, orbColor, partFlashing);
				OnCollision?.Invoke(collisionData);
			}
            catch
            {
				Log.Warning("Обработка ошибки генерации данных о колизии.");
				Debug.Break();
            }

			Log.Message("Уничтожение сферы.");
			Destroy(gameObject);
		}
	}
}