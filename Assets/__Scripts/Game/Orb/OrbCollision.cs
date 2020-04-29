using UnityEngine;

/// <summary>
/// Обработчик коллизии сферы
/// </summary>
public class OrbCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
	{
		//Debug.Log($"[OrbCollision] Столкновение с {coll.name}");

		CollisionProcessing.addCollision(coll);
	}
}
