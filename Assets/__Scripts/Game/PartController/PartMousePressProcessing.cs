using UnityEngine;

/// <summary>
/// Обработчик нажатия на объект Part левой кнопки мыши на ПК или тапа на мобильном устройстве.
/// </summary>
public class PartMousePressProcessing : MonoBehaviour
{
	/// <summary>
	/// Кешированный Transform.
	/// </summary>
	Transform cachedTransform = null;
	void Awake()
	{
		cachedTransform = transform;
	}

	void OnMouseDown()
	{
		if (Statements.pause) return;

		Debug.Log($"Нажатие на часть формы {name}.");
		FormPartSelection.calculate(cachedTransform.localRotation.eulerAngles.z);
	}
}