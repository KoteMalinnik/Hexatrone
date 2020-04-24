using System.Collections;
using UnityEngine;

/// <summary>
/// ОТВЕЧАЕТ ЗА УПРАВЛЕНИЕ ФОРМОЙ
/// ИНИЦИАЛИЗИРУЕТ ФОРМУ СООТВЕТСТВЕННО ЕЕ УРОВНЮ
/// ОПРЕДЕЛЯЕТ НАЧАЛЬНЫЕ ЗНАЧЕНИЯ ПРИ НОВОМ УРОВНЕ
/// </summary>

public class InputController : MonoBehaviour
{
	//void Update()
	//{
	//	//управление формой, если не запущена анимация смены формы и не пау_formParametrs
	//	//if (gm._formParametrs.Coroutine_Rotate == null && !PauseMenuManager.isPause)
	//	{
	//		//УПРАВЛЕНИЯ С ТАЧСКРИНА
	//		if (Input.touchCount > 0)
	//		{
	//			Touch firstTouch = Input.GetTouch(0);

	//			if (firstTouch.position.y < Screen.height - 100 /* ВСТАВИТЬ СЮДА УСЛОВИЕ НА ВЫСОТУ ЭКРАНА*/)
	//			{
	//				switch (gm.controller)
	//				{
	//					case GameManager.Controll.Left_Right:
	//						{
	//							//if (firstTouch.position.y < Screen.height - Screen.height/15)
	//							LEFT_RIGHT(firstTouch); //управление "левая-правая половина экрана" LEFT_RIGHT
	//							break;
	//						}
	//					case GameManager.Controll.Swipe:
	//						{
	//							SWIPE(firstTouch); //управление свайпом SWIPE
	//							break;
	//						}
	//					/*default:
	//						{
	//							Debug.Log("CONTROLLER ERROR", this);
	//							Debug.Break();
	//							break;
	//						}*/
	//				}
	//			}
	//		}
	//	}
	//}

	////Преобразование bool в int для переменной Inverse
	//int get_INVERSE(bool b)
	//{
	//	if (b) return 1;
	//	return -1;
	//}

	////управление LEFT_RIGHT
	//void LEFT_RIGHT(Touch firstTouch)
	//{
	//	Vector3 firstToushPosition = Camera.main.ScreenToWorldPoint(firstTouch.position);
	//	if (firstToushPosition.x < -0.5/*Screen.width / 2 - 10*/)
	//		transform.Rotate(new Vector3(0, 0, -gm._formParametrs.RotationSpeed * get_INVERSE(gm.inverse) * 2 / 3), Space.Self);
	//	else if (firstToushPosition.x > 0.5/*Screen.width / 2 + 10*/)
	//		transform.Rotate(new Vector3(0, 0, gm._formParametrs.RotationSpeed * get_INVERSE(gm.inverse) * 2 / 3), Space.Self);
	//}

	////управление свайпом SWIPE
	//void SWIPE(Touch firstTouch)
	//{
	//	float moveDirection = 0;

	//	if (firstTouch.phase == TouchPhase.Moved && (firstTouch.deltaPosition.x > 2f || firstTouch.deltaPosition.x < -2f))
	//		moveDirection = firstTouch.deltaPosition.x;
	//	transform.Rotate(new Vector3(0, 0, get_INVERSE(gm.inverse) * moveDirection * 2 / 3), Space.Self);
	//}

	////управление PART_SELECTED
	////поворот влево - подавать в c_Rotate положительный угол
	//public IEnumerator rotate_SelectedPart(float currentAngle)
	//{
	//	//если анимация смены формы не работает и анимация вращения тоже выключна
	//	if (gm._formParametrs.Coroutine_Rotate == null && gm._formParametrs.rotate_SelectedPart == null) 
	//	{
	//		float angle = 0;

	//		//направление в сторону isPulled (выпущенной сферы)
	//		// направление = цель.позиция - текущийОбъект.позиция
	//		Vector2 direction = Vector2.up;
	//		if(gm._orbSpawner.pulledOrb != null) direction = gm._orbSpawner.pulledOrb.transform.position - transform.position;
	//		angle = Vector2.SignedAngle(Vector2.down, direction); //угол между нижним вектором и вектором направления

	//		if (angle < 0) angle += 360; //угол вектора в сторону сферы от 0 до 360

	//		angle = angle - currentAngle + transform.rotation.eulerAngles.z; //задаем угол поворота формы

	//		//поворот формы с текущего угла Part-а до угла в сторону isPulled _formParametrsеры
	//		gm._formParametrs.rotate_SelectedPart = StartCoroutine(gm._formAnimations.c_Rotate(0, angle, 15f)); 
	//	}

	//	yield return new WaitUntil(() => gm._formParametrs.rotate_SelectedPart == null); //ожидание, пока не завершится анимация
	//}
}