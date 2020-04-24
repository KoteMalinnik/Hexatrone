using UnityEngine;

[RequireComponent(typeof(FormRotation))]
[RequireComponent(typeof(PartSelection))]
public class Controller : MonoBehaviour
{
    //void Start()
	//{
	//	//зануление массива цветных счетчиков
	//	//for (int i = 0; i < gm._formParametrs.colorCounters.Length; i++)
	//	//	gm._formParametrs.colorCounters[i] = 0;

	//	StartCoroutine(InstansiateForm()); //Инициализация формы
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
