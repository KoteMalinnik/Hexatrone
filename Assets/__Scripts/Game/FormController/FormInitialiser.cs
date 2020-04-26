using UnityEngine;

public static class FormInitialiser
{
	public static void initialiseObject(int formLevel = 0)
	{
		Debug.Log($"[FormInitialiser] Инициализация формы уровня {formLevel}.");

		var prefab = loadPrefab(formLevel);
		GameObject obj = MonoBehaviour.Instantiate(prefab, Vector3.zero, Quaternion.Euler(0,90,0));

		FormController.setForm(obj);
	}

	/// <summary>
	/// Имя префаба в папке Resources\Prefabs
	/// </summary>
	static string prefabName = "Form";

	/// <summary>
	/// Загрузить префаб из папки Resources\Prefabs
	/// </summary>
	static GameObject loadPrefab(int formLevel)
	{
		var path = @"Prefabs\Forms\" + prefabName + "_" + formLevel;
		Debug.Log($"<color=yellow>Загрузка префаба {prefabName} по пути {path}</color>");

		GameObject prefabOject = Resources.Load<GameObject>(path);

		if (prefabOject == null)
		{
			Debug.LogError("[FormInitialiser] Префаб отсутствует.");
			throw new System.ArgumentNullException();
		}

		return prefabOject;
	}
}
