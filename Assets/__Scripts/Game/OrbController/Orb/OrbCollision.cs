using UnityEngine;

public class OrbCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log($"[OrbCollision] Столкновение с {coll.name}");

		CollisionProcessing.addCollision(coll, gameObject);
	}
}
