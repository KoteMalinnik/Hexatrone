using UnityEngine;

/// <summary>
/// Сокрытие и показ панелей GUI.
/// </summary>
public class PanelsActivitySwitcher : MonoBehaviour
{
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
