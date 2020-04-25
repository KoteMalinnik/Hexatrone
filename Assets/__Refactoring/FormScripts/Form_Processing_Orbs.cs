using System.Collections;
using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */


/// <summary>
/// ОТСЫЛАЕТ НОВЫЕ В FORM_PARAMETRS
///	ВЫЗЫВАЕТ ОБНОВЛЕНИЕ СЧЕТЧИКОВ НА КАНВАСЕ
///	ВЫСЫЛАЕТ ЗАПРОС НА ИЗМЕНЕНИЕ УРОВЕНЯ, ЕСЛИ ТРЕБУЕТСЯ
/// </summary>
public class Form_Processing_Orbs : MonoBehaviour
{
	////Обработка цветных счетчиков
	////Они только накапливают и ничего не теряют 
	//void ColorCountersProcessing(Color counterColor, int delta) //counterColor - цвет нужного счетчика
	//{
	//	for (int i = 0; i < gm._formParametrs.partColors.Length; i++)
	//	{
	//		if (gm._formParametrs.partColors[i] == counterColor)
	//		{
	//			gm._formParametrs.colorCounters[i] +=delta;
	//			break;
	//		}
	//	}
	//	gm._formParametrs.TotalOrbsCounter += delta;
	//	gm._formParametrs.CurrentOrbCounter += delta;
	//}

	////обработка счетчика текущего уровня формы
	////использует CurrentCounter, CriticalOrbsCount и OrbsCountToNextLVL
	//void levelCounterProcessing()
	//{
	//	//проверка на изменение уровня
	//	if (gm._formParametrs.CurrentOrbCounter > gm._formParametrs.OrbsToNextLvlCount && gm._formParametrs.formLVL < 5) //повышение уровня, если не максимальный уровень
	//	{
	//		gm._formParametrs.formLVL++; //повышение уровня
	//		gm._formParametrs.OrbsToNextLvlCount = 10*(gm._formParametrs.formLVL*2+1) ; //увеличение количества сфер до следующего уровня
	//		gm._formAudioManager.playSound(gm._formAudioManager.lvlUpSound); //звук повышения уровня

	//		if (gm._formParametrs.formLVL == 3) gm._orbSpawner.orbsSpeed++;
	//		else if (gm._formParametrs.formLVL == 5) gm._orbSpawner.orbsSpeed++;
	//	}
	//	else if (gm._formParametrs.CriticalOrbsCounter < 0 && gm._formParametrs.formLVL > 0 && gm.gamemode != GameManager.GameMode.Hardcore)
	//		//понижение уровня, если не минималный уровень. ПРоигрышь, если это хардкор
	//	{
	//		gm._formParametrs.formLVL--; //понижение уровня
	//		gm._formParametrs.OrbsToNextLvlCount = 10 * (gm._formParametrs.formLVL * 2 + 1); //уменьшение количества сфер до следующего уровня
	//		gm._formAudioManager.playSound(gm._formAudioManager.lvlDownSound); //звук понижения уровня

	//		if (gm._formParametrs.formLVL == 2) gm._orbSpawner.orbsSpeed--;
	//		else if (gm._formParametrs.formLVL == 4) gm._orbSpawner.orbsSpeed--;
	//	}
	//	else
	//	{
	//		// if(gm.isSoundOn) Handheld.Vibrate();
	//		PauseMenuManager.isPause = false;
	//		gm._formAudioManager.playSound(gm._formAudioManager.gameOverSound);
	//		gm._stats.ShowStatsPanel();
	//	}
	//	StartCoroutine(gm._formController.InstansiateForm());
	//}
}
