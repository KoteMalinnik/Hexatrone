using UnityEngine;


/// <summary>
/// Управление GUI главного меню.
/// </summary>
public class MainMenuGUI : MonoBehaviour
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


	void Awake()
	{
		var panelsSwitcher = new PanelsActivitySwitcher();
		panelsSwitcher.__HidePanel(panelTutorial);
		panelsSwitcher.__HidePanel(panelGraditudes);
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
}
