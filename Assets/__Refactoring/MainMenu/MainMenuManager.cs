using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.IO;

/*
 * РЕФАКТОРИТЬ 
 */

/// <summary>
/// ОТВЕЧАЕТ ЗА ВСЕ ЭЛЕМЕНТЫ ГЛАВНОГО МЕНЮ
/// </summary>
public class MainMenuManager : MonoBehaviour
{
	//public Text text_VERSION;

	//[Header("MAIN MENU GUI")]
	//public Button[] MainMenuButtons; //основыне кнопки главного меню

	//[Header("GAMEMODE")]
	//public Button Button_Gamemode_Infinity;
	//public Button Button_Gamemode_Hardcore;
	//public Button Button_Gamemode_Levels;

	//[Header("QUIT GUI")]
	//public Toggle QuitMessageToggle; // Выключатель сообщения о выходе
	//public Button quit_Yes; // Кнопка согласия на выход
	//public Button quit_No; // Кнопка несогласия на выход
	//public GameObject QuitPanel; // Панель сообщения о выходе

	//[Header("SETTINGS GUI")]
	//public GameObject SettingsPanel; // Панель настроек
	//public GameObject GraditudesPanel; //Панель благодарностей
	//public Button Settings_Back; // Кнопка выхода в главное меню
	//public Button Settings_Graditudes; // Кнопка благодарностей
	//public Button Settings_Graditudes_Back; // Кнопка закрытия панели благодарности
	//public Toggle Settings_Music; //галочка музыки
	//public Toggle Settings_Sound; //галочка звука
	//[Space]
	//public Toggle Settings_Language_RU; //галочка русского языка
	//public Toggle Settings_Language_EN; //галочка английского языка
	//[Space]
	//public Toggle Settings_ControlType_PARTSELECT; //галочка управления PART SELECT
	//public Toggle Settings_ControlType_SWIPE; //галочка управления SWIPE
	//public Toggle Settings_ControlType_LEFTRIGHT; //галочка управления LEFT-RIGHT
	//public Toggle Settings_ControlType_INVERSE; //галочка управления LEFT-RIGHT

	//[Header("TUTORIAL GUI")]
	//public GameObject TutorialPanel; // Панель туториала
	//public Button TutorialBack; //кнопка выхода в главное меню

	//void Start()
	//{
	//	audioSource = get_AudioSource(); //получаем источник звука Canvas

	//	//Если аудиодорожка не установленна, то "ошибка"
	//	if (audioSource.clip == null) Debug.Log("AudioSource Click Error");

	//	// УСТАНОВКА НАЧАЛЬНЫХ ЗНАЧЕНИЙ

	//	//Подгружаем значения из GameManager
	//	QuitMessageToggle.isOn = gm.QuitMessageToggle; //галочка на выходе

	//	change_gamemode("*");

	//	Deactivate(QuitPanel);//отключаем панель сообщения о выходе
	//	Deactivate(SettingsPanel);//отключаем панель настроек
	//	Deactivate(TutorialPanel);

	//	//установка версии
	//	text_VERSION.text = $"VERSION: {Application.version}: {gm.lastUpdateDate}";
	//}

	//// ________________________________________________________________________________________________________________

	////НАЖАТИЕ НА КНОПКУ ИГРАТЬ
	//public void button_PLAY()
	//{
	//	//Загружаем игровую сцену
	//	//LoadScene(2);
	//}

	////НАЖАТИЕ НА Кнопку типа ИГРЫ
	//public void change_gamemode(string gamemode)
	//{
	//	playClick();

	//	Interacte(Button_Gamemode_Levels);
	//	Interacte(Button_Gamemode_Infinity);
	//	Interacte(Button_Gamemode_Hardcore);

	//	if (gamemode == "*") gamemode = gm.gamemode.ToString();

	//	gm.gamemode = GameMode(gamemode);

	//	switch (gm.gamemode)
	//	{
	//		case GameManager.GameMode.Infinite:
	//			{
	//				DeInteracte(Button_Gamemode_Infinity);
	//				break;
	//			}
	//		case GameManager.GameMode.Hardcore:
	//			{
	//				DeInteracte(Button_Gamemode_Hardcore);
	//				break;
	//			}
	//		case GameManager.GameMode.Levels:
	//			{
	//				DeInteracte(Button_Gamemode_Levels);
	//				break;
	//			}
	//	}
	//}

	////ФУНКЦИИ ДЛЯ НАСТРОЕК
	////НАЖАТИЕ НА КНОПКУ НАСТРОЕК
	//public void button_SETTINGS()
	//{
	//	playClick();

	//	//устанавливаем визуально настройки
	//	Settings_StartParametrs();

	//	//показываем панель настроек
	//	Activate(SettingsPanel);
	//	SettingsPanel.GetComponent<Animator>().SetBool("isHidden", false);

	//	//Слушатели на галочки звука, музыки и инверсии
	//	Other_AddListeners(Settings_Sound, Settings_Music, Settings_ControlType_INVERSE);
		
	//	//Слушатели на галочки языка
	//	Language_AddListener(Settings_Language_RU, GameManager.Language.Russian);
	//	Language_AddListener(Settings_Language_EN, GameManager.Language.English);

	//	//Слушатели на галочки управления
	//	Controll_AddListener(Settings_ControlType_PARTSELECT, Settings_ControlType_INVERSE, GameManager.Controll.Part_Selection);
	//	Controll_AddListener(Settings_ControlType_SWIPE, Settings_ControlType_INVERSE, GameManager.Controll.Swipe);
	//	Controll_AddListener(Settings_ControlType_LEFTRIGHT, Settings_ControlType_INVERSE, GameManager.Controll.Left_Right);
	//}

	////НАЖАТИЕ НА КНОПКУ НАЗАД ПАНЕЛИ НАСТРОЕК
	//public void button_settings_BACK()
	//{
	//	playClick();

	//	//Убираем слушатели
	//	RemoveListeners(FindObjectsOfType<Toggle>());

	//	StartCoroutine(deactivatePanel(SettingsPanel));
	//}

	////НАЖАТИЕ НА КНОПКУ БЛАГОДАРНОСТЕЙ
	//public void button_settings_graditudes()
	//{
	//	playClick();

	//	Activate(GraditudesPanel);
	//	GraditudesPanel.GetComponent<Animator>().SetBool("isHidden", false);
	//}

	////НАЖАТИЕ НА КНОПКУ ЗАКРЫТИЯ БЛАГОДАРНОСТЕЙ
	//public void button_settings_graditudes_close()
	//{
	//	playClick();
	//	StartCoroutine(deactivatePanel(GraditudesPanel));
	//}

	////визуальные настройки параметров
	//void Settings_StartParametrs()
	//{
	//	if (gm.controller == GameManager.Controll.Part_Selection)
	//	{
	//		Settings_ControlType_INVERSE.interactable = false;
	//		INVERSE_changed(false);
	//		Settings_ControlType_INVERSE.isOn = false;
	//	}
	//	else
	//	{
	//		Settings_ControlType_INVERSE.interactable = true;
	//		Settings_ControlType_INVERSE.isOn = gm.inverse; //инверсия
	//	}

	//	Settings_Music.isOn = gm.isMusicOn; //музыка
	//	Settings_Sound.isOn = gm.isSoundOn; //звук


	//	Settings_Language_RU.isOn = false;
	//	Settings_Language_EN.isOn = false;

	//	switch (gm.language) //язык
	//	{
	//		case GameManager.Language.English:
	//			{
	//				Settings_Language_EN.isOn = true;
	//				break;
	//			}
	//		case GameManager.Language.Russian:
	//			{
	//				Settings_Language_RU.isOn = true;
	//				break;
	//			}
	//	}

	//	Settings_ControlType_PARTSELECT.isOn = false; 
	//	Settings_ControlType_SWIPE.isOn = false;
	//	Settings_ControlType_LEFTRIGHT.isOn = false;

	//	switch (gm.controller) //управление
	//	{
	//		case GameManager.Controll.Part_Selection:
	//			{
	//				Settings_ControlType_PARTSELECT.isOn = true;
	//				break;
	//			}
	//		case GameManager.Controll.Swipe:
	//			{
	//				Settings_ControlType_SWIPE.isOn = true;
	//				break;
	//			}
	//		case GameManager.Controll.Left_Right:
	//			{
	//				Settings_ControlType_LEFTRIGHT.isOn = true;
	//				break;
	//			}

	//	}
	//}

	//// \\ КОНЕЦ ФУНКЦИЙ ДЛЯ КНОПКИ НАСТРОЕК ___________________________________________________________________________


	////ФУНКЦИИ ДЛЯ ОБУЧЕНИЯ
	////НАЖАТИЕ НА КНОПКУ ОБУЧЕНИЕ
	//public void button_TUTORIAL()
	//{
	//	playClick();

	//	//показываем панель настроек
	//	Activate(TutorialPanel);
	//	TutorialPanel.GetComponent<Animator>().SetBool("isHidden", false);
	//}

	////НАЖАТИЕ НА КНОПКУ НАЗАД ПАНЕЛИ ОБУЧЕНИЯ
	//public void button_TutorialBack()
	//{
	//	playClick();
	//	StartCoroutine(deactivatePanel(TutorialPanel));
	//}

	//// \\ КОНЕЦ ФУНКЦИЙ ДЛЯ КНОПКИ ОБУЧЕНИЯ _____________________________________________________________________________


	////ФУНКЦИИ ДЛЯ ВЫХОДА
	////НАЖАТИЕ НА КНОПКУ ВЫХОДА
	//public void button_QUIT()
	//{
	//	playClick();

	//	//Если не ставили галку на выключение сообщения о выходе
	//	if (!QuitMessageToggle.isOn)
	//	{
	//		Activate(QuitPanel); //включаем панель сообщения
	//		QuitPanel.GetComponent<Animator>().SetBool("isHidden", false);
	//		//Подключаем слушатель на Галочку, чтобы словить изменение состояния
	//		QuitMessageToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(QuitMessageToggle); });
	//	}
	//	else Application.Quit(); //иначе выходим из игры
	//}

	////НАЖАТИЕ НА КНОПКУ "ДА" ПАНЕЛИ СООБЩЕНИЯ ВЫХОДА
	//public void button_quit_Yes()
	//{
	//	Application.Quit(); // выходим из игры
	//}

	////НАЖАТИЕ НА КНОПКУ "НЕТ" ПАНЕЛИ СООБЩЕНИЯ ВЫХОДА
	//public void button_quit_No()
	//{
	//	playClick();

	//	StartCoroutine(deactivatePanel(QuitPanel));

	//	//Убираем все Слушатели, потому что они не нужны
	//	QuitMessageToggle.onValueChanged.RemoveAllListeners();
	//}

	////Функция вызывается при изменении состояния галочки
	//void ToggleValueChanged(Toggle m_Toggle)
	//{
	//	playClick();

	//	gm.QuitMessageToggle = m_Toggle.isOn; //Сохраняем новое значение галочки в GameManager
	//	//gm.sn.SettingsSerialisation("ShowQuitMessage", gm.QuitMessageToggle);
	//}

	// \\ КОНЕЦ ФУНКЦИЙ ДЛЯ КНОПКИ ВЫХОДА _____________________________________________________________________________
}
