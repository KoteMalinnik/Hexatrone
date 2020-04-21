using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Содержит в себе конечные результаты игры
/// </summary>
public class Stats : helpBehaviour
{
    public static Stats instance { get; private set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

		gm = GameManager.instance;
		gm._stats = instance;
	}

	public int maxLvl { get; set; }
	public int collectedBafsCount { get; set; }

	public GameObject statsPanel;

	[Space]

	public Text text_totalOrbsCount;
	public Text text_maxLvl;
	public Image image_maxLvl;
	public Text text_playedTime;
	public Text text_collectedBafsCount;


	[Header("COLOR COUNTERS PARAMETRS")]
	public Text[] text_colorCounter = new Text[8];
	public Image[] image_colorCounter = new Image[8];

	public Sprite[] formSprites = new Sprite[6];


	public void Restart()
	{
		//Загружаем сцену заново
		LoadScene(2);
	}

	public void toMainMenu()
	{
		LoadScene(1); //загружаем сцену с Меню
	}

	void Start()
	{
		Deactivate(statsPanel);

		maxLvl = 0;
		collectedBafsCount = 0;

		for (int i = 0; i < 8; i++) image_colorCounter[i].color = gm._formParametrs.partColors[i];
	}

	//Сбор необходимой информации
	public void ShowStatsPanel()
	{
		Activate(statsPanel);
		statsPanel.GetComponent<Animator>().SetBool("isHidden", false);
		PauseMenuManager.isPause = true;

		text_maxLvl.text = maxLvl.ToString();
		image_maxLvl.sprite = formSprites[maxLvl];
		text_totalOrbsCount.text = gm._formParametrs.TotalOrbsCounter.ToString();
		text_playedTime.text = levelTimerManager.timer.text;
		text_collectedBafsCount.text = collectedBafsCount.ToString();

		for (int i = 0; i < 8; i++) text_colorCounter[i].text = gm._formParametrs.colorCounters[i].ToString();
	}
}
