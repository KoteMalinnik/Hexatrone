using UnityEngine;
using UnityEngine.UI;

/*

	ОТВЕЧАЕТ ЗА ОТОБРАЖЕНИЕ СЧЕТЧИКОВ И ШКАЛ В ИГРЕ

 */

public class CanvasManager : MonoBehaviour
{
	//[Header("PROGRESS SLIDERS")]
	//public Slider progressBar;
	//public Text progressBarText;
	//[Space]
	//public Slider criticalBar;
	//public Text criticalBarText;

	//[Header("INFO GUI")]
	//public Text level_num;
	//public Text TotalOrbsCount_num;
	//public Text BafsCount_num;

	//void Start()
	//{
	//	//отключаем критическую шкалу, если HARDCORE
	//	if(gm.gamemode == GameManager.GameMode.Hardcore)
	//	{
	//		Deactivate(criticalBar.gameObject);
	//	}
	//	else
	//	{
	//		Activate(criticalBar.gameObject);
	//	}
	//}

	//public void updateCounters()
	//{
	//	//обновление значений слайдеров
	//	progressBar.value = gm._formParametrs.CurrentOrbCounter;
	//	criticalBar.value = gm._formParametrs.CriticalOrbsCounter;
	//	//обновление значений счетчиков для слайдеров
	//	progressBarText.text = (gm._formParametrs.OrbsToNextLvlCount - gm._formParametrs.CurrentOrbCounter).ToString();
	//	criticalBarText.text = criticalBar.value.ToString();

	//	TotalOrbsCount_num.text = gm._formParametrs.TotalOrbsCounter.ToString();
	//	BafsCount_num.text = Stats.instance.collectedBafsCount.ToString();
	//}

	//public void LVLupdate()
	//{
	//	if (gm._formParametrs.formLVL < 5 && !progressBar.gameObject.activeInHierarchy) progressBar.gameObject.SetActive(true);

	//	//обновляем максимальные значения слайдеров, чтобы не рассчитывать лишний раз какую часть добавить
	//	progressBar.maxValue = gm._formParametrs.OrbsToNextLvlCount;
	//	criticalBar.maxValue = gm._formParametrs.CriticalOrbsCounter;

	//	//изменяем цвет слайдеров
	//	// progressBar - цвет следующего нового элемента
	//	if (gm._formParametrs.formLVL < 5)
	//	{
	//		get_Image(progressBar.fillRect.gameObject).color = gm._formParametrs.partColors[gm._formParametrs.formLVL + 3];
	//	}
	//	else
	//	{
	//		Deactivate(progressBar.gameObject); //выключаем, если это последний уровень
	//	}

	//	// criticalBar - цвет текущего последнего элемента
	//	if (gm._formParametrs.formLVL > 0)
	//	{
	//		get_Image(criticalBar.fillRect.gameObject).color = gm._formParametrs.partColors[gm._formParametrs.formLVL + 2];
	//	}
	//	else
	//	{
	//		get_Image(criticalBar.fillRect.gameObject).color = Color.gray; //черный, если нулевой уровень
	//	}

	//	level_num.text = gm._formParametrs.formLVL.ToString();

	//	//Обновление счетчиков
	//	updateCounters();
	//}
}
