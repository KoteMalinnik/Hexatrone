﻿using UnityEngine;

/// <summary>
/// Mouse button press processing.
/// </summary>
public class MouseButtonPressProcessing : MonoBehaviour
{
	void OnMouseDown()
	{
		Debug.Log($"Нажатие на часть формы {name}.");

		//если анимация поворота PART_SELECTION формы не работает и не пауза, то можно ее включить
		//if (GameManager.instance.controller == GameManager.Controll.Part_Selection
		//	&& Form_Parametrs.instance.rotate_SelectedPart == null
		//	&& !PauseMenuManager.isPause)
		//	StartCoroutine(Form_Controller.instance.rotate_SelectedPart(transform.rotation.eulerAngles.z)); //поворот формы
	}
}