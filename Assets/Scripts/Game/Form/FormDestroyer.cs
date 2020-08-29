using UnityEngine;
using System.Collections;

public static class FormDestroyer 
{
	/// <summary>
	/// Уничтожить существующую форму, после чего создать новую. Если форма не существует, то создать ее.
	/// </summary>
	/// <param name="existingForm">Объект формы.</param>
	public static void destroyObject(GameObject existingForm)
	{
		if(existingForm == null)
		{
			//Инициализируем форму, если она null в FormController.form
			//FormInitialiser.initialiseObject(FormLevelController.level);
			return;
		}

		Debug.Log($"[FormDestroyer] Уничтожение формы {existingForm.name}.");
		FormController.instance.StartCoroutine(destroyAfterRotation(existingForm));
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

		//FormInitialiser.initialiseObject(FormLevelController.level);
	}
}
