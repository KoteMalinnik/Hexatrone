using UnityEngine;

[RequireComponent(typeof(PanelsActivitySwitcher))]
[RequireComponent(typeof(AudioButtonsControll))]
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


	void Awake()
	{
		var panelsSwitcher = GetComponent<PanelsActivitySwitcher>();
		panelsSwitcher.__HidePanel(panelGraditudes);
	}


	/// <summary>
	/// Загрузить сцену с основной игрой.
	/// </summary>
	public void __Play()
	{
		Debug.Log("[MainMenuGUI] Загрузка сцены GameLevel.");
		//RegularMethods.LoadScene("2_GameLevel");
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
