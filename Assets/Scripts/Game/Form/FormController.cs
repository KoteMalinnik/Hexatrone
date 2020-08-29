using UnityEngine;

/// <summary>
/// Контролер формы.
/// </summary>
public class FormController : MonoBehaviour
{
	/// <summary>
	/// Экземпляр.
	/// </summary>
	public static FormController instance { get; private set;} = null;

	/// <summary>
	/// Кешированный Transform.
	/// </summary>
	public static Transform cachedTransform { get; private set; } = null;
	void Awake()
	{
		instance = this;
		cachedTransform = transform;
	}

	/// <summary>
	/// Объект формы.
	/// </summary>
	public static GameObject form { get; private set; } = null;

	/// <summary>
	/// Установить объект формы.
	/// </summary>
	/// <param name="newForm">Объект формы.</param>
	public static void setForm(GameObject newForm)
	{
		if (newForm == null)
		{
			Debug.LogError($"[FormController] Новая форма пуста");
			return;
		}

		form = newForm;

		if(cachedTransform.localRotation.eulerAngles.y < 10) cachedTransform.localRotation = Quaternion.Euler(0, 90, 0);

		FormPartsSetuper.setupFormParts(form);

		form.name = $"Form_{FormLevelController.level}";

		form.transform.parent = cachedTransform;
		form.transform.localPosition = Vector3.zero;

		FormRotation.rotate(0);
	}
}
