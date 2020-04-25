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
		form.name = $"Form_{formLevel}";

		form.transform.parent = cachedTransform;
		form.transform.localPosition = Vector3.zero;
		cachedTransform.localRotation = Quaternion.Euler(0, 90, 0); //Поворот перпендикулярно камере

		FormRotation.rotate(0);
	}

	public static int formLevel { get; private set; } = 0;
	public static void setFormLevel(int newFormLevel)
	{
		formLevel = newFormLevel;
		Debug.Log($"[FormController] Установка уровеня формы: {formLevel}");

		FormInitialiser.initialiseObject(formLevel);

		CounterCriticalOrbs.setValue(5);
		CounterOrbsAtFormLevel.setValueToLevelUp(formLevel);
	}

	public static void levelUpEvent()
	{
		Debug.Log("[FormController] Уровень повышен!");
		setFormLevel(formLevel + 1);
	}

	public static void levelDownEvent()
	{
		Debug.Log("[FormController] Уровень понижен!");
		setFormLevel(formLevel - 1);
	}
}
