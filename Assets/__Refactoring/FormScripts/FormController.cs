using UnityEngine;

[RequireComponent(typeof(FormRotation))]
[RequireComponent(typeof(FormPartSelection))]
[RequireComponent(typeof(FormInitialiser))]

/*
 * РЕФАКТОРИТЬ 
 */

public class FormController : MonoBehaviour
{
	static Transform cachedTransform = null;
	void Awake()
	{
		cachedTransform = transform;
	}

	//объект формы
	public static GameObject form { get; private set; } = null;
	public static void setForm(ref GameObject newForm)
	{
		if (newForm == null)
		{
			Debug.LogError($"[FormController] Новая форма пуста");
			return;
		}

		form = newForm;
		form.name = $"Form_{FormLevel.level}";

		form.transform.parent = cachedTransform;
		form.transform.localPosition = Vector3.zero;
		cachedTransform.localRotation = Quaternion.Euler(0, 90, 0); //Поворот перпендикулярно камере

		FormRotation.rotate(0);
	}
}
