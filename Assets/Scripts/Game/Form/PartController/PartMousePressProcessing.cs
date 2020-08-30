using System;
using UnityEngine;

/// <summary>
/// Обработчик нажатия на объект Part левой кнопки мыши на ПК или тапа на мобильном устройстве.
/// </summary>
public class PartMousePressProcessing : MonoBehaviour
{
	public static event Action<Transform> OnPartClick = null;

	void OnMouseDown()
	{
		if (Statements.pause) return;

		Log.Message($"Нажатие на {name}.");
		OnPartClick?.Invoke(transform);
	}
}