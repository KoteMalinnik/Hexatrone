using System.Collections;
using UnityEngine;

/*

	ОТВЕЧАЕТ ЗА ДВИЖЕНИЕ СФЕРЫ
	ХРАНИТ ТИП СФЕРЫ И ДОПОЛНИТЕЛЬНУЮ ИНФОРМАЦИЮ ОБ УСТАНОВЛЕННОМ ТИПЕ
	ПЕРЕМЕННАЯ IS_PULLED ИМЕЕТ ЗНАЧЕНИЕ TRUE, ЕСЛИ СФЕРА ЛЕТИТ К ФОРМЕ

 */

public class Orb_object : MonoBehaviour
{
	////Тип сферы
	//public enum OrbType
	//{
	//	/// <summary>
	//	/// Баф количества (+2, вместо одного, либо -2 соответственно) от 2 до 5. 
	//	/// Обязательно изменяет количество currentOrbCount вне зависимости от цвета
	//	/// </summary>
	//	Count_Baf,
	//	LVL_Baf, // бафы уровня (в сфере будет спрайт формы, которая будет) изменяет уровень только если словить нужным цветом
	//	Usual, //обычная сфера. Дает +1 или -1. Обязательно изменяет currentOrbCount
	//	Critical //Добавляет очки в критическую шкалу
	//}
	//public OrbType type { get; set; }

	//// количество сфер при бафе количества Count_Baf
	//public int Count_Baf_value { get; set; }
	////уровень, который будет, если словить сферу LVL_Baf
	//public int LVL_Baf_value { get; set; }

	////корутина движения сферы к фигуре
	//IEnumerator Moving(float Speed, Vector3 Target) //speed - скорость движения, target - целевая позиция
	//{
	//	while (Vector3.Distance(transform.position, Target) > float.Epsilon)
 //       {
 //           if(!PauseMenuManager.isPause) transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime);
 //           yield return null;
 //       }
	//}

	////функция запуска корутины движения
	//public void pull_Orb(float OrbSpeed, Vector3 target)
	//{
	//	gameObject.SetActive(true);
	//	StartCoroutine(Moving(OrbSpeed, target));
	//}
}
