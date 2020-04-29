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
public class MainMenuGUI : MonoBehaviour
{
	[Header("GUI Panels")]

	[SerializeField]
	GameObject panelGraditudes = null;

	[SerializeField]
	GameObject panelTutorial = null;


	[Header("GUI Toggles")]

	[SerializeField]
	Toggle toggleMusic = null;
	[SerializeField]
	Toggle toggleSound = null;


	void Start()
	{
		if (MusicManager.instance != null) toggleMusic.isOn = MusicManager.instance.allowAudio;
		if (SoundManager.instance != null) toggleSound.isOn = SoundManager.instance.allowAudio;

		__HidePanel(panelTutorial);
		__HidePanel(panelGraditudes);
	}


	/// <summary>
	/// Загрузить сцену с основной игрой.
	/// </summary>
	public void __Play()
	{
		Debug.Log("[MainMenuGUI] Загрузка сцены GameLevel.");
		RegularMethods.LoadScene("2_GameLevel");
	}

	/// <summary>
	/// Выйти из игры.
	/// </summary>
	public void __Quit()
	{
		Debug.Log("[MainMenuGUI] Выход из игры.");
		Application.Quit();
	}

	/// <summary>
	/// Переключить звук в соответствии с Toggle.
	/// </summary>
	public void __SoundToggle()
	{
		if (SoundManager.instance == null) return;
			
		Debug.Log("[MainMenuGUI] Переключение звука.");
		SoundManager.instance.setAudioState(toggleSound.isOn);
	}

	/// <summary>
	/// Переключить музыку в соответствии с Toggle.
	/// </summary>
	public void __MusicToggle()
	{
		if (MusicManager.instance == null) return;

		Debug.Log("[MainMenuGUI] Переключение музыки.");
		MusicManager.instance.setAudioState(toggleMusic.isOn);
	}


	/// <summary>
	/// Открыть панель.
	/// </summary>
	public void __ShowPanel(GameObject panel)
	{
		Debug.Log("[MainMenuGUI] Показать панель " + panel.name);
		panel.SetActive(true);
	}

	/// <summary>
	/// Скрыть панель.
	/// </summary>
	public void __HidePanel(GameObject panel)
	{
		Debug.Log("[MainMenuGUI] Скрыть панель " + panel.name);
		panel.SetActive(false);
	}
}
