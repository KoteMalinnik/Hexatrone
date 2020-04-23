using System.Collections;
using UnityEngine;

/// <summary>
/// ОТВЕЧАЕТ ЗА УПРАВЛЕНИЕ ФОРМОЙ
/// ИНИЦИАЛИЗИРУЕТ ФОРМУ СООТВЕТСТВЕННО ЕЕ УРОВНЮ
/// ОПРЕДЕЛЯЕТ НАЧАЛЬНЫЕ ЗНАЧЕНИЯ ПРИ НОВОМ УРОВНЕ
/// </summary>

public class Form_Controller : MonoBehaviour
{
	//void Start()
	//{
	//	//зануление массива цветных счетчиков
	//	//for (int i = 0; i < gm._formParametrs.colorCounters.Length; i++)
	//	//	gm._formParametrs.colorCounters[i] = 0;

	//	StartCoroutine(InstansiateForm()); //Инициализация формы
	//}

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

	////Инициализация новой формы с уничтожением старой
	//public IEnumerator InstansiateForm()
	//{
	//	yield return new WaitUntil(() => !PauseMenuManager.isPause); //ожидание,  если стоит на паузе

	//		gm._formParametrs.OrbsToNextLvlCount = 10 * (gm._formParametrs.formLVL * 2 + 1); //устанавливаем значение сфер до следующего _formParametrsовня
	//		gm._formParametrs.CurrentOrbCounter = 0; //устанавливаем нулевое количество сфер

	//		// устанавливаем критическое количеств_formParametrsсфер
	//		gm._formParametrs.CriticalOrbsCounter = gm.gamemode == GameManager.GameMode.Hardcore ? 0 : gm._formParametrs.CriticalOrbsCount;

	//		gm._canvasManager.LVLupdate();

	//		//если работет анимация на поворот при PART_SELECT_formParametrs
	//		if (gm._formParametrs.rotate_SelectedPart != null)
	//		{
	//			StopCoroutine(gm._formParametrs.rotate_SelectedPart);
	//			gm._formParametrs.rotate_SelectedPart = null;
	//		}

	//		//поворот формы с 0 на 90 градусов по_formParametrsси Y
	//		gm._formParametrs.Coroutine_Rotate = StartCoroutine(gm._formAnimations.c_Rotate(90f, 0, 30f));
	//		//!!!!!!
	//		yield return new WaitUntil(() => gm._formParametrs.Coroutine_Rotate == null); //ожидание, пока не завершится анимация_formParametrs
	//		if (gm._formParametrs.form != null) //если не первая инициализация формы и объект формы существует
	//		{
	//			Destroy(gm._formParametrs.form); //уничтожаем старую _formParametrsрму
	//			gm._formParametrs.form = null;
	//		}

	//		//создаем новую форму, делая ее родителем объект Form_Cont_formParametrsller
	//		gm._formParametrs.form = Instantiate(gm._formParametrs.Forms[gm._formParametrs.formLVL], Vector3.zero, Quaternion.Euler(0, 90, 0));
	//		gm._formParametrs.form.transform.position = new Vector3(0, -3f, 0);
	//		gm._formParametrs.form.transform.parent = transform;
	//		if (gm._formParametrs.formLVL > gm._stats.maxLvl) gm._stats.maxLvl = gm._formParametrs.formLVL;

	//		//Получаем массив SpriteRenderer дочерних объектов формы (т.е. Part-ов)
	//		SpriteRenderer[] sr;

	//		sr = transform.childCount > 1 ? transform.GetChild(1).GetComponentsInChildren<SpriteRenderer>() : GetComponentsInChildren<SpriteRenderer>();

	//		//Окрашиваем Part-ы в цвета
	//		int i = 0;
	//		foreach (SpriteRenderer s in sr)
	//		{
	//			s.color = gm._formParametrs.partColors[i];
	//			i++;
	//		}
	//		if (gm._formParametrs.Coroutine_Rotate == null) //если анимация смены формы не работает, то можно ее вкл_formParametrsить
	//			gm._formParametrs.Coroutine_Rotate = StartCoroutine(gm._formAnimations.c_Rotate(0, 0, 30.0f)); //поворот формы с 90 на 0 градусов
	//		yield return new WaitUntil(() => gm._formParametrs.Coroutine_Rotate == null); //ожидание, пока не завершится анимация

	//		if (!gm._orbSpawner.enabled)
	//		{
	//			PauseMenuManager.isPause = true; //ставим на паузу
	//			gm._orbSpawner.enabled = true;
	//			gm._orbSpawner.firstEnable();
	//		}

	//		yield return null;
		
	//}

}