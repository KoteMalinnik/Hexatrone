using UnityEngine;

public class OrbCollisionProcessing : MonoBehaviour
{
	GameObject orb = null;
	void Awake()
	{
		orb = gameObject;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log("[OrbCollisionProcessing] Обработка столкновения");

		OrbController.setupObject(ref orb);
	}
}