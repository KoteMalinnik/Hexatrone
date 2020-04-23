using UnityEngine;

/// <summary>
/// Form part controller.
/// </summary>
public class FormPartController : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D coll) //coll - коллайдер сферы
	{
		Debug.Log($"Столкновение {name} с объектом {coll.name}.");
	}

	//void OnTriggerEnter2D(Collider2D coll) //coll - коллайдер сферы
	//	{
	//		//отправляем событие столкновения на обработку
	//		if (coll.gameObject.tag != "part")
	//		{
	//		Form_Processing_Orbs.instance.DoubleTouch
	//			(
	//			     get_SpriteRenderer(coll.gameObject).color, //получаем цвет сферы
	//			     get_SpriteRenderer(gameObject).color, //получаем цвет части
	//				 coll.gameObject, //получаем объект сферы
	//			     get_OrbObject(coll.gameObject).type, //получаем тип сферы
	//			     get_SpriteRenderer(gameObject) //получаем компонент SpriteRenderer части
	//		        );

	//		GameManager.instance._orbSpawner.pulledOrb = null;
	//		}
	//	}

	void OnMouseDown()
	{
		Debug.Log($"Нажатие на часть формы {name}.");

		//если анимация поворота PART_SELECTION формы не работает и не пауза, то можно ее включить
		//if (GameManager.instance.controller == GameManager.Controll.Part_Selection
		//	&& Form_Parametrs.instance.rotate_SelectedPart == null
		//	&& !PauseMenuManager.isPause)
		//	StartCoroutine(Form_Controller.instance.rotate_SelectedPart(transform.rotation.eulerAngles.z)); //поворот формы
	}
}
