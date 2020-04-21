using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuManager : helpBehaviour
{
	public GameObject GameInformationCanvas; //канвас со счетчиками и слайдерами
	public GameObject PausePanel; //Панель паузы

	public Button pause;
	public Button prestart; //кнопка пре-старта

	public Button objectives;

	[Header("Параметры")]
	public Toggle toggle_Music; //галочка музыки
	public Toggle toggle_Sound; //галочка звука

	public static bool isPause { get; set;} = false;

	void Start()
	{
		isPause = false;
		gm = GameManager.instance;

		audioSource = get_AudioSource(); //получаем источник звука PauseCanvas

		pause.interactable = true; //включаем кнопку паузы
		Deactivate(PausePanel); //отключаем панель паузы
		Activate(GameInformationCanvas); //показываем канвас со счетчиками и слайдерами
		Activate(prestart.gameObject); //включаем кнопку пре-старта

		if (gm.gamemode == GameManager.GameMode.Levels) Activate(objectives.gameObject);
	}

	void Update()
	{
		//кнопка назад на Android
		if (Input.GetKeyDown(KeyCode.Escape) && !PausePanel.activeInHierarchy)
		{
			ShowPauseMenu();
		}

		//Debug.Log(isPause);
	}

	//показать меню паузы
	public void ShowPauseMenu()
	{
		playClick();

		isPause = true; //ставим на паузу

		//устанавливаем визуально настройки
		Settings_StartParametrs();

		Activate(PausePanel); //включаем панель паузы
		Deactivate(GameInformationCanvas); //скрываем канвас со счетчиками и слайдерами

		PausePanel.GetComponent<Animator>().SetBool("isHidden", false);

		//Слушатели на галочки звука, музыки и инверсии
		toggle_Sound.onValueChanged.AddListener(delegate { SOUND_changed(toggle_Sound.isOn); });
		toggle_Music.onValueChanged.AddListener(delegate { MUSIC_changed(toggle_Music.isOn); });
	}

	//визуальные настройки параметров
	void Settings_StartParametrs()
	{
		toggle_Music.isOn = gm.isMusicOn; //музыка
		toggle_Sound.isOn = gm.isSoundOn; //звук
	}

	//функция кнопки ПРЕСТАРТ
	public void b_prestart()
	{
		playClick();
		//убираем с паузы
		isPause = false;
		//отключаем кнопку престарта
		Deactivate(prestart.gameObject);
	}

	//Кнопка главного меню
	public void b_MainMenu()
	{
		RemoveListeners(FindObjectsOfType<Toggle>());

		LoadScene(1); //загружаем сцену с Меню
	}

	//кнопка продолжения
	public void b_Continue()
	{
		playClick();

		RemoveListeners(FindObjectsOfType<Toggle>());

		Activate(GameInformationCanvas); //показываем канвас со счетчиками и слайдерами
		Activate(prestart.gameObject); //включаем кнопку пре-старта

		StartCoroutine(deactivatePanel(PausePanel));
	}

	//Кнопка целей
	public void b_Objectives()
	{
		gm._levelsGenerator.ShowObjectivesPanel();
	}
}