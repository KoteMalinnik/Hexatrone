using UnityEngine.UI;
using UnityEngine;
using System.Text;

/*
 * РЕФАКТОРИТЬ
 */

/// <summary>
/// Управление счетчиком времени.
/// </summary>
public class TimerControllerGUI : MonoBehaviour
{
	//время игры на уровне
	public static short sec { get; private set; }
	public static short min { get; private set; }

	[SerializeField]
	Text textTimer = null;

	void Start()
	{
		sec = 0;
		min = 0;

		InvokeRepeating("Timer", 0, 1);
	}

	readonly StringBuilder stringBuilder = new StringBuilder(5);
	void Timer()
	{
		if (Statements.pause) return;

		stringBuilder.Clear();
		stringBuilder.AppendFormat("{0:00}:{1:00}", min, sec);

		sec++;
		if (sec >= 60)
		{
			sec = 0;
			min++;
		}

		textTimer.text = stringBuilder.ToString();

		//checkObjectives();
	}

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
