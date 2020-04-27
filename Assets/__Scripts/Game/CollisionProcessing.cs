using UnityEngine;
using System.Collections;

public static class CollisionProcessing
{
	static GameObject orb = null;

	static Collider2D[] collisions = new Collider2D[2];
	public static void addCollision(Collider2D newCollision, GameObject collisedOrb)
	{
		if (coroutine == null)
		{
			orb = collisedOrb;
			coroutine = FormController.instance.StartCoroutine(waitForEndOfFrame());
		}

		if (collisions[0] == null) collisions[0] = newCollision;
		else collisions[1] = newCollision;
	}

	static Coroutine coroutine = null;
	static IEnumerator waitForEndOfFrame()
	{
		yield return new WaitForEndOfFrame();

		Debug.Log("[CollisionProcessing] Обработка столкновения");

		checkCollisions();
		removeCollisions();

		OrbController.setupObject();

		coroutine = null;
	}

	static void checkCollisions()
	{
		if (collisions[0] == null) return;

		if (collisions[1] == null)
		{
			Debug.Log("[CollisionProcessing] Единственное столкновение");

			if (checkColor(collisions[0]))
			{
				OnColorMatch();
				return;
			}
		}
		else
		{
			Debug.Log("[CollisionProcessing] Двойное столкновение.");

			if (checkColor(collisions[0]) || checkColor(collisions[1]))
			{
				OnColorMatch();
				Debug.Log("[CollisionProcessing] Наилучший вариант найден.");
				return;
			}
		}

		OnColorMismatch();
		Debug.Log("[CollisionProcessing] Отсутствие совпадений.");
		collisions[0].GetComponent<PartFlashingAnimation>().animate(false);
	}

	static bool checkColor(Collider2D collision)
	{
		var orbColor = orb.GetComponent<OrbBasic>().getColor();
		var collisionColor = collision.GetComponent<PartController>().getColor();

		if(orbColor == collisionColor)
		{
			collision.GetComponent<PartFlashingAnimation>().animate(true);
			return true;
		}
		return false;
	}

	static void removeCollisions()
	{
		collisions[0] = null;
		collisions[1] = null;
	}

	static void OnColorMatch()
	{
		Debug.Log("Совпадение цветов!");
		CountersProcessing.OnColorMatch();
	}

	static void OnColorMismatch()
	{
		Debug.Log("Несовпадение цветов!");
		CountersProcessing.OnColorMismatch();
	}
}