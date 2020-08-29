using UnityEngine;
using System.Collections;

/// <summary>
/// Уничтожение существующей формы.
/// </summary>
public static class FormDestroyer 
{
	/// <summary>
	/// Уничтожить существующую форму, после чего создать новую. Если форма не существует, то создать ее.
	/// </summary>
	/// <param name="form">Объект формы.</param>
	public static void destroyObject(GameObject form)
	{
		if(form == null)
		{
			//Инициализируем форму, если она null в FormController.form
			FormInitialiser.initialiseObject(FormLevel.level);
			return;
		}

		Debug.Log($"[FormDestroyer] Уничтожение формы {form.name}.");
		FormController.instance.StartCoroutine(destroyAfterRotation(form));
	}

	/// <summary>
	/// Корутина уничтожения формы после воспроизведения анимации вращения.
	/// </summary>
	/// <param name="form">Объект формы.</param>
	static IEnumerator destroyAfterRotation(GameObject form)
	{
		//Продумать передачу ссылки на объект или затестить, будет ли корутина без ref уничтожать объект
		FormRotation.rotate(90);

		yield return new WaitWhile(() => FormRotation.rotating);

		MonoBehaviour.Destroy(form);
		Debug.Log($"[FormDestroyer] Форма уничтожена.");

		FormInitialiser.initialiseObject(FormLevel.level);
	}
}
