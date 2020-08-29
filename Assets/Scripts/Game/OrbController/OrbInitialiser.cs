using UnityEngine;

[RequireComponent(typeof(OrbController))]
/// <summary>
/// Инициализатор объекта сферы.
/// </summary>
public class OrbInitialiser : MonoBehaviour
{
	[SerializeField, Tooltip("Имя префаба в папке Resources/Prefabs/")]
	/// <summary>
	/// Имя префаба в папке Resources\Prefabs
	/// </summary>
	string prefabName = null;

	void Start()
	{
		var prefab = loadPrefab();
		GameObject obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
		obj.transform.parent = transform;

		OrbController.setOrb(obj);
		Destroy(this);
	}

	/// <summary>
	/// Загрузить префаб из ресурсов
	/// </summary>
	GameObject loadPrefab()
	{
		var path = @"Prefabs\" + prefabName;
		Debug.Log($"<color=yellow>Загрузка префаба {prefabName} по пути {path}</color>");
		GameObject prefabOject = Resources.Load<GameObject>(path);
		return prefabOject;
	}

	void OnDestroy()
	{
		Debug.Log($"Объект <color=white>{prefabName}sGenerator</color> уничтожен");
	}
}