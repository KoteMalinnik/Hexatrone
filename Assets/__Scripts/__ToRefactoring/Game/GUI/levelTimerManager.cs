using UnityEngine.UI;
using UnityEngine;
using System.Xml.Schema;

/// <summary>
/// Отвечает за счетчик времени в игре
/// </summary>
public class levelTimerManager : MonoBehaviour
{
	////время игры на уровне
	//public static short sec { get; private set; }
	//public static short min { get; private set; }

	//public static Text timer { get; private set; }

	//public void updateTimer()
	//{
	//	string time = "";

	//	if (min == 0) time = "00:";
	//	else if (min < 10) time = "0" + min + ":";
	//	else time = min + ":";

	//	if (sec == 0) time += "00";
	//	else if (sec < 10)
	//	{
	//		time += "0";
	//		time += sec;
	//	}
	//	else time += sec;

	//	timer.text = time;
	//}

	//void Start()
	//{
	//	sec = 0;
	//	min = 0;

	//	timer = GetComponent<Text>();

	//	InvokeRepeating("Timer", 1, 1);
	//}

	//void Timer()
	//{
	//	if(!PauseMenuManager.isPause)
	//	{
	//		sec++;
	//		if (sec >= 60)
	//		{
	//			min++;
	//			sec = 0;
	//		}
	//		updateTimer();
	//		if (gm.gamemode == GameManager.GameMode.Levels) checkObjectives();
	//	}
	//}

	//void checkObjectives()
	//{
	//	LevelsGenerator.goal rGoal = new LevelsGenerator.goal();

	//	foreach (LevelsGenerator.goal g in gm._levelsGenerator.levelGoals)
	//	{
	//		if(g.ID==0 && gm._formParametrs.TotalOrbsCounter >= g.value)
	//		{
	//			rGoal = g;
	//			break;
	//		}

	//		if (g.ID == 1 && gm._formParametrs.formLVL >= g.value)
	//		{
	//			rGoal = g;
	//			break;
	//		}
		
	//		if (g.ID == 2 && gm._stats.collectedBafsCount >= g.value)
	//		{
	//			rGoal = g;
	//			break;
	//		}

	//		if (g.ID == 3 && min * 60 + sec >= g.value)
	//		{
	//			rGoal = g;
	//			break;
	//		}
	//	}

	//	if(gm._levelsGenerator.levelGoals.Contains(rGoal)) gm._levelsGenerator.levelGoals.Remove(rGoal);

	//	if (gm._levelsGenerator.levelGoals.Count == 0)
	//	{
	//		gm.level++;
	//		gm._levelsGenerator.ShowLevelCompletePanel();
	//	}
	//}
}
