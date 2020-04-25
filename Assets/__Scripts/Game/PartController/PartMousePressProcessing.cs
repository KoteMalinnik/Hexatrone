using UnityEngine;

/// <summary>
/// Mouse button press processing.
/// </summary>
public class PartMousePressProcessing : MonoBehaviour
{
	Transform cachedTransform = null;
	void Awake()
	{
		cachedTransform = transform;
	}

	void OnMouseDown()
	{
		Debug.Log($"Нажатие на часть формы {name}.");
		FormPartSelection.calculate(cachedTransform.localRotation.eulerAngles.z);
	}
}