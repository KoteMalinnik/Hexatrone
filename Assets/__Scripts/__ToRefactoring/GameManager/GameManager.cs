using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.SimpleLocalization;

/// <summary>
/// Содержит ссылки на менеджеры и основные переменные
/// </summary>
public class GameManager : MonoBehaviour//helpBehaviour
{
	public static GameManager instance { get; private set;}
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

		DontDestroyOnLoad(this);
	}

	//перечисление управления
	public enum Controll
	{
		Left_Right,
		Part_Selection,
		Swipe
	}
	public Controll controller;
	//инверсия управления LEFT-RIGHT и SWIPE. true, ЕСЛИ ИНВЕРСИЯ. false, Если нет инверсии
	public bool inverse { get; set; }

	//перечисление языков
	public enum Language 
	{
		Russian,
		English
	}
	public Language language { get; set; }

	//Режимы игры
	public enum GameMode
	{
		Infinite, // бесконечный
		Hardcore, // хардкор
		Levels // уровнями
	}
	public GameMode gamemode { get; set;}

	public bool QuitMessageToggle { get; set; } //галочка для скрытия сообщения о выходе
	public bool isMusicOn { get; set; } //Включена ли музыка
	public bool isSoundOn { get; set; } //Включен ли звук

	public string lastUpdateDate;

	public int level { get; set; }

	//public Serialization _serialization;// { get; private set; }

	//МЕНЕДЖЕРЫ
	public LevelsGenerator _levelsGenerator { get; set; } = null;
	public Form_Controller _formController { get; set; }
	public Form_Parametrs _formParametrs { get; set; }
	public Form_AudioManager _formAudioManager { get; set; }
	public Form_Animatons _formAnimations { get; set; }
	public Form_Processing_Orbs _formProcessingOrbs { get; set; }
	public MainMenuManager _mainMenuManager { get; set; }
	public CanvasManager _canvasManager { get; set; }
	public Orb_Spawner _orbSpawner { get; set; }
	public Stats _stats { get; set; }


	void Start()
	{
		//_serialization = GetComponent<Serialization>();

		//Загрузка настроек из реестра
		//_serialization.LoadSettings();

		//ЛОКАЛИЗАЦИЯ
		//инициализация словаря
		LocalizationManager.Read();
		//перевод в соответствии с установленным языком
		LocalizationManager.Language = language.ToString();

		if (lastUpdateDate.Length < 1) Debug.LogError(this);

		//Устанавливаем стандартный режим
		gamemode = GameMode.Infinite;

		//если GameManager находится только в PRELOAD МЫ ЗАГРУЖАЕМ ГЛАВНОЕ МЕНЮ
		if (SceneManager.GetActiveScene().buildIndex == 0) SceneManager.LoadSceneAsync(1);
	}
}
