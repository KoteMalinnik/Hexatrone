using UnityEngine;


/// <summary>
/// ОТВЕЧАЕТ ЗА ВСЕ ЭЛЕМЕНТЫ ГЛАВНОГО МЕНЮ
/// </summary>
public class MainMenuGUI : baseGUI
{
	[Header("GUI Panels")]

	[SerializeField]
	/// <summary>
	/// Панель благодарностей.
	/// </summary>
	GameObject panelGraditudes = null;

	[SerializeField]
	/// <summary>
	/// Панель обучения.
	/// </summary>
	GameObject panelTutorial = null;


	void Start()
	{
		presetAudioButtons();

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
