using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */

public class FormController : MonoBehaviour
{
	public static FormController instance { get; private set;} = null;
	public static Transform cachedTransform { get; private set; } = null;
	void Awake()
	{
		instance = this;
		cachedTransform = transform;
	}

	//объект формы
	public static GameObject form { get; private set; } = null;
	public static void setForm(GameObject newForm)
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

		FormRotation.rotate(0);
	}
}
