using UnityEngine;

namespace Orb
{
	[RequireComponent(typeof(OrbDataController))]
	public class OrbOnCollisionDestroyer : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D collision)
		{
			Log.Message("Столкновение с " + collision.name);
			Destroy(gameObject);
		}
	}
}