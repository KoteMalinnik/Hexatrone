using UnityEngine;
using System.Collections;

public static class FormDestroyer 
{
	public static void destroyObject(GameObject form)
	{
		if(form == null)
		{
			Debug.Log($"[FormDestroyer] Форма отсутствует.");
			return;
		}

		Debug.Log($"[FormDestroyer] Уничтожение формы {form.name}.");
		FormController.instance.StartCoroutine(destroyAfterRotation(form));
	}

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
