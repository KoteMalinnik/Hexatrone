using UnityEngine;

[RequireComponent(typeof(FormPartsSetuper))]
public class FormInitialiser : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// Имя префаба в папке Resources\Prefabs
	/// </summary>
	string _prefabName = "Form";
	static string prefabName;

	void Awake()
	{
		prefabName = _prefabName;
	}

	public static void initialiseObject(int formLevel)
	{
		Debug.LogError($"[FormInitialiser] Инициализация формы уровня {formLevel}.");

		var prefab = loadPrefab(formLevel);

		GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);

		FormPartsSetuper.setupFormParts(ref obj);
		FormController.setForm(ref obj);
	}

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
