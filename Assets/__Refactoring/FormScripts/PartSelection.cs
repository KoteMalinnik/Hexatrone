using System.Collections;
using UnityEngine;


public class PartSelection : MonoBehaviour
{
	//управление PART_SELECTED
	public IEnumerator rotate_SelectedPart(float currentAngle)
	{
		/*
		 * Алгоритм наведения на сферу
		 * 
		 * Если корутины действий не заняты (уже поворачивает или еще чего), то:
		 * 1. Найти выпущенную сферу
		 * 2. Определить вектор направления к этой сфере
		 * 3. Считать свой localRotation
		 * 4. Рассчитать минимальный угол меджду:
		 * единичным вектором под углом localRotation
		 * вектором направления
		 * 5. Использовать метод FormRotation.rotate(0, <рассчитаный угол>)
		 */

		//если анимация смены формы не работает и анимация вращения тоже выключна
		if (gm._formParametrs.Coroutine_Rotate == null && gm._formParametrs.rotate_SelectedPart == null) 
		{
			float angle = 0;

			//направление в сторону isPulled (выпущенной сферы)
			// направление = цель.позиция - текущийОбъект.позиция
			Vector2 direction = Vector2.up;
			if(gm._orbSpawner.pulledOrb != null) direction = gm._orbSpawner.pulledOrb.transform.position - transform.position;
			angle = Vector2.SignedAngle(Vector2.down, direction); //угол между нижним вектором и вектором направления

			if (angle < 0) angle += 360; //угол вектора в сторону сферы от 0 до 360

			angle = angle - currentAngle + transform.rotation.eulerAngles.z; //задаем угол поворота формы

			//поворот формы с текущего угла Part-а до угла в сторону isPulled _formParametrsеры
			gm._formParametrs.rotate_SelectedPart = StartCoroutine(gm._formAnimations.c_Rotate(0, angle, 15f)); 
		}

		yield return new WaitUntil(() => gm._formParametrs.rotate_SelectedPart == null); //ожидание, пока не завершится анимация
	}
}