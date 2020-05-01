﻿using UnityEngine;

[RequireComponent(typeof(PanelsActivitySwitcher))]
[RequireComponent(typeof(AudioButtonsControll))]
/// <summary>
/// Управление GUI панели паузы.
/// </summary>
public class PauseGUI : MonoBehaviour
{
	[Header("GUI Panels")]

	[SerializeField]
	/// <summary>
	/// Панель паузы.
	/// </summary>
	GameObject panelPause = null;

	[SerializeField]
	/// <summary>
	/// Панель целей уровня.
	/// </summary>
	GameObject panelGoals = null;

	void Awake()
	{
		var panelsSwitcher = GetComponent<PanelsActivitySwitcher>();
		panelsSwitcher.__HidePanel(panelPause);
		panelsSwitcher.__HidePanel(panelGoals);
	}

	/// <summary>
	/// Установить паузу.
	/// </summary>
	/// <param name="state">Новое состояние паузы.</param>
	public void __SetPause(bool state)
	{
		Statements.setPause(state);
	}

	/// <summary>
	/// Выйти в главное меню.
	/// </summary>
	public void __MainMenu()
	{
		RegularMethods.LoadScene("1_MainMenu");
	}
}