using UnityEngine;

/// <summary>
/// Управление GUI панели паузы.
/// </summary>
public class PauseGUI : MonoBehaviour
{
	//[Header("GUI Panels")]

	//[SerializeField]
	/// <summary>
	/// Панель паузы.
	/// </summary>
	//GameObject panelPause = null;

	void Awake()
	{
		//var panelsSwitcher = GetComponent<PanelsActivitySwitcher>();
		//panelsSwitcher.__HidePanel(panelPause);
	}

	/// <summary>
	/// Установить паузу.
	/// </summary>
	/// <param name="state">Новое состояние паузы.</param>
	public void __SetPause(bool state)
	{
		//Statements.setPause(state);
	}

	/// <summary>
	/// Перезагрузить уровень
	/// </summary>
	public void __Restart()
	{
		//RegularMethods.LoadScene("2_GameLevel");
	}

	/// <summary>
	/// Выйти в главное меню.
	/// </summary>
	public void __MainMenu()
	{
		//RegularMethods.LoadScene("1_MainMenu");
	}
}