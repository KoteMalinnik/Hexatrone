using UnityEngine;

[RequireComponent(typeof(FlashingAnimation))]
/// <summary>
/// Collision processing.
/// </summary>
public class CollisionProcessing : MonoBehaviour
{
	FlashingAnimation flashingAnimation = null;
	void Awake()
	{
		flashingAnimation = GetComponent<FlashingAnimation>();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Debug.Log($"Столкновение {name} с объектом {coll.name}.");

		flashingAnimation.animate();

		////отправляем событие столкновения на обработку
		//if (coll.gameObject.tag != "part")
		//{
		//	Form_Processing_Orbs.instance.DoubleTouch
		//	(
		//	     get_SpriteRenderer(coll.gameObject).color, //получаем цвет сферы
		//	     get_SpriteRenderer(gameObject).color, //получаем цвет части
		//		 coll.gameObject, //получаем объект сферы
		//	     get_OrbObject(coll.gameObject).type, //получаем тип сферы
		//	     get_SpriteRenderer(gameObject) //получаем компонент SpriteRenderer части
		//        );

		//	GameManager.instance._orbSpawner.pulledOrb = null;
		//}
	}
}