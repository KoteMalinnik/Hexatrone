using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Assets.SimpleLocalization;

/*
 * РЕФАКТОРИТЬ 
 */


public class GoalsGenerator : MonoBehaviour
{
	public static int goalLevel { get; private set; } = 0;

	//public Text lvl;
	//[Space]
	//public GameObject ObjectivesPanel;
	//public GameObject LevelCompletePanel;
	//[Space]
	//public string LocalizationKey;

	//public void OnDestroy()
	//{
	//	LocalizationManager.LocalizationChanged -= Localize;
	//}

	//void Localize()
	//{
	//	GetComponent<Text>().text = LocalizationManager.Localize(LocalizationKey);
	//}

	////void Awake()
	////{
	////	Deactivate(LevelCompletePanel);
	////	Deactivate(ObjectivesPanel);

	////	if (gm.gamemode != GameManager.GameMode.Levels) gameObject.SetActive(false);
	////}

	///// <summary>
	///// Содержит значение int value и string objective.
	///// value отвечает за количественное значение цели
	///// objective отвечает за текстовое описание цели
	///// </summary>
	//public struct goal
	//{
	//	public int ID;
	//	public int value;
	//	public string objective;
	//}

	//public List<goal> goals = new List<goal>();

	//void Start()
	//{
	//	Localize();
	//	LocalizationManager.LocalizationChanged += Localize;
	//	string[] localizedObjectives = GetComponent<Text>().text.Split('*');

	//	ShowObjectivesPanel();

	//	//собрать всего сфер
	//	goals.Add(new goal()
	//	{
	//		ID = 0,
	//		//value = 15 + 2 * gm.level,
	//		objective = localizedObjectives[0]
	//	});

	//	//достичь уровня
	//	goals.Add(new goal()
	//	{
	//		ID = 1,
	//		value = Random.Range(1,5),
	//		objective = localizedObjectives[1]
	//	});

	//	//собрать бонусов
	//	goals.Add(new goal()
	//	{
	//		ID = 2,
	//		//value = gm.level>2 ? gm.level/2 : gm.level,
	//		objective = localizedObjectives[2]
	//	});

	//	//сыграть времени
	//	goals.Add(new goal()
	//	{
	//		ID = 3,
	//		//value = 45 + 3 * gm.level,
	//		objective = localizedObjectives[3]
	//	});

	//	//goals.Add(new goal()
	//	//{
	//	//	ID = 4,
	//	//	value = 2 + 3 * gm.level,
	//	//	objective = "Собрать цветных сфер: "
	//	//});


	//	generateLevelGoals();
	//}

	//[Space]
	//public GameObject content;
	//public GameObject itemPrefab;
	//public List<goal> levelGoals = new List<goal>();
	//public int goalsCount { get; set;}
	//void generateLevelGoals()
	//{
	//	var state = Random.state;
	//	Random.InitState(gm.level);

	//	lvl.text = $"{gm.level+1}";

	//	for (int i = 0; i < Random.Range(1, 4); i++)
	//	{
	//		goal g = goals[Random.Range(0, 4)];
	//		if(!levelGoals.Contains(g))
	//		{
	//			levelGoals.Add(g);

	//			GameObject go = Instantiate(itemPrefab);
	//			go.transform.parent = content.transform;
	//			go.transform.localScale = Vector3.one;
	//			go.GetComponentInChildren<Text>().text = $"{g.objective}: {g.value}";
	//		}
	//	}

	//	goalsCount = levelGoals.Count;

	//	Random.state = state;
	//}

	//public void ShowLevelCompletePanel()
	//{
	//	if(!PauseMenuManager.isPause) PauseMenuManager.isPause = true;

	//	gm._formAudioManager.playSound(gm._formAudioManager.levelCompliteSound);
	//	Activate(LevelCompletePanel);
	//	LevelCompletePanel.GetComponent<Animator>().SetBool("isHidden", false);
	//}

	//public void ShowObjectivesPanel()
	//{
	//	Activate(ObjectivesPanel);
	//	ObjectivesPanel.GetComponent<Animator>().SetBool("isHidden", false);
	//}

	//public void button_objectivesOK()
	//{
	//	StartCoroutine(deactivatePanel(ObjectivesPanel));
	//}
}