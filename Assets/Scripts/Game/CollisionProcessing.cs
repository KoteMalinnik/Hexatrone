using UnityEngine;
using System.Collections;

/// <summary>
/// Обработчик коллизии объектов Part и Orb
/// </summary>
public static class CollisionProcessing
{
	/// <summary>
	/// Коллизии
	/// </summary>
	static Collider2D[] collisions = new Collider2D[2];

	/// <summary>
	/// Добавить коллизию объекта Part
	/// </summary>
	/// <param name="newCollision">Новая коллизия объекта Part.</param>
	public static void addCollision(Collider2D newCollision)
	{
		//if (coroutine == null) coroutine = FormController.instance.StartCoroutine(waitForEndOfFrame());

		if (collisions[0] == null) collisions[0] = newCollision;
		else collisions[1] = newCollision;
	}

	/// <summary>
	/// Корутина, хранящая в себе корутину ожидания. Если она занята, то нет необходимости запускать еще одну корутину
	/// </summary>
	static Coroutine coroutine = null;

	/// <summary>
	/// Корутин ожидания конца кадра и последующей обработки коллизий
	/// </summary>
	static IEnumerator waitForEndOfFrame()
	{
		yield return new WaitForEndOfFrame();

		Debug.Log("[CollisionProcessing] Обработка столкновения");

		checkCollisions();
		removeCollisions();

		OrbController.setupObject();

		coroutine = null;
	}

	/// <summary>
	/// Обработка коллизий
	/// </summary>
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
				Debug.Log("[CollisionProcessing] Наилучший вариант найден.");
				OnColorMatch();
				return;
			}
		}

		Debug.Log("[CollisionProcessing] Отсутствие совпадений.");
		OnColorMismatch();
		//collisions[0].GetComponent<PartFlashingAnimation>().animate(false);
	}

	/// <summary>
	/// Проверить совпадения цветов объектов Part и Orb
	/// </summary>
	/// <param name="collision">Коллизия объекта Part.</param>
	static bool checkColor(Collider2D collision)
	{
		//var orbColor = OrbController.orbColorSetuper.GetColor();
		//var collisionColor = collision.GetComponent<ColorController>().GetColor();

		//if(orbColor == collisionColor)
		//{
		//	collision.GetComponent<PartFlashingAnimation>().animate(true);
		//	return true;
		//}
		return false;
	}

	/// <summary>
	/// Очистить коллизии
	/// </summary>
	static void removeCollisions()
	{
		collisions[0] = null;
		collisions[1] = null;
	}

	/// <summary>
	/// Запустить событие обработки при наличии совпадений цветов
	/// </summary>
	static void OnColorMatch()
	{
		Debug.Log("[CollisionProcessing] Совпадение цветов!");
		CountersProcessing.OnColorMatch(OrbController.orbObject);
	}

	/// <summary>
	/// Запустить событие обработки при отсутствии совпадений цветов
	/// </summary>
	static void OnColorMismatch()
	{
		Debug.Log("[CollisionProcessing] Несовпадение цветов!");
		CountersProcessing.OnColorMismatch(OrbController.orbObject);
	}
}