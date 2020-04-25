using UnityEngine;
using System.Collections;

public class CollisionProcessing : MonoBehaviour
{
	static CollisionProcessing instance = null;
	static GameObject orb = null;
	void Awake()
	{
		instance = this;
		removeCollisions();
	}

	static Collider2D[] collisions = new Collider2D[2];
	public static void addCollision(Collider2D newCollision, GameObject collisedOrb)
	{
		if (coroutine == null)
		{
			orb = collisedOrb;
			coroutine = instance.StartCoroutine(waitForEndOfFrame());
		}

		if (collisions[0] == null) collisions[0] = newCollision;
		else collisions[1] = newCollision;
	}

	static Coroutine coroutine = null;
	static IEnumerator waitForEndOfFrame()
	{
		yield return new WaitForEndOfFrame();

		Debug.Log("[OrbCollisionProcessing] Обработка столкновения");

		checkCollisions();
		removeCollisions();

		OrbController.setupObject(ref orb);

		coroutine = null;
	}

	static void checkCollisions()
	{
		if (collisions[0] == null) return;

		if (collisions[1] == null)
		{
			Debug.Log("[OrbCollisionProcessing] Единственное столкновение");

			if (checkColor(collisions[0]))
			{
				//совпадение цвета
				return;
			}
		}
		else
		{
			Debug.Log("[OrbCollisionProcessing] Двойное столкновение.");

			if (checkColor(collisions[0]))
			{
				//совпадение цвета первой коллизии
				Debug.Log("[OrbCollisionProcessing] Наилучший вариант - ПЕРВОЕ столкновение.");
				return;
			}

			if (checkColor(collisions[1]))
			{
				// совпадение цвета второй коллизии
				Debug.Log("[OrbCollisionProcessing] Наилучший вариант - ВТОРОЕ столкновение.");
				return;
			}
		}

		//отсутствие совпадений
		Debug.Log("[OrbCollisionProcessing] Отсутствие совпадений.");
		collisions[0].GetComponent<PartFlashingAnimation>().animate(Color.black);
	}

	static bool checkColor(Collider2D collision)
	{
		var orbColor = orb.GetComponent<OrbBasic>().getColor();
		var collisionColor = collision.GetComponent<PartController>().getColor();

		if(orbColor == collisionColor)
		{
			Debug.Log($"[OrbCollisionProcessing] Совпадение цветов c ({collision.name}).");
			collision.GetComponent<PartFlashingAnimation>().animate(Color.white);
			return true;
		}

		Debug.Log($"[OrbCollisionProcessing] Цвета не совпали c ({collision.name}).");
		return false;
	}

	static void removeCollisions()
	{
		collisions[0] = null;
		collisions[1] = null;
	}
}