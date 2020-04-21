using UnityEngine;

/*

	ОТВЕЧАЕТ ЗА ПОВЕДЕНИЕ ЧАСТИ PART
	ЛОВИТ СТОЛКНОВЕНИЕ СО СФЕРОЙ ORB
	ОТПРАВЛЯЕТ ДАННЫЕ О КОЛИЗЗИИ В FORM_PROCESSING_ORBS

 */

public class Part_Script : helpBehaviour
{
	void OnTriggerEnter2D(Collider2D coll) //coll - коллайдер сферы
		{
			//отправляем событие столкновения на обработку
			if (coll.gameObject.tag != "part")
			{
			Form_Processing_Orbs.instance.DoubleTouch
				(
				     get_SpriteRenderer(coll.gameObject).color, //получаем цвет сферы
				     get_SpriteRenderer(gameObject).color, //получаем цвет части
					 coll.gameObject, //получаем объект сферы
				     get_OrbObject(coll.gameObject).type, //получаем тип сферы
				     get_SpriteRenderer(gameObject) //получаем компонент SpriteRenderer части
			        );

			GameManager.instance._orbSpawner.pulledOrb = null;
			}
		}

	void OnMouseDown()
	{
		//если анимация поворота PART_SELECTION формы не работает и не пауза, то можно ее включить
		if (GameManager.instance.controller == GameManager.Controll.Part_Selection
			&& Form_Parametrs.instance.rotate_SelectedPart == null
			&& !PauseMenuManager.isPause)
			StartCoroutine(Form_Controller.instance.rotate_SelectedPart(transform.rotation.eulerAngles.z)); //поворот формы
	}
}
