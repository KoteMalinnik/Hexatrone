using UnityEngine;

[RequireComponent(typeof(OrbController))]
/// <summary>
/// Objects Generator.
/// </summary>
public class OrbGenerator : MonoBehaviour
{
	/// <summary>
	/// The prefab oject.
	/// </summary>
	GameObject prefabOject = null;

	[SerializeField]
	/// <summary>
	/// Имя префаба в папке Resources\Prefabs
	/// </summary>
	string prefabName = null;

	void Awake()
	{
		loadPrefab();
	}

	void Start()
	{
		GameObject obj = Instantiate(prefabOject, Vector3.zero, Quaternion.identity);
		obj.transform.parent = transform;

		OrbController.setupObject(ref obj);
		Destroy(this);
	}

	/// <summary>
	/// Загрузить префаб из папки Resources\Prefabs
	/// </summary>
	void loadPrefab()
	{
		var path = @"Prefabs\" + prefabName;
		Debug.Log($"<color=yellow>Загрузка префаба {prefabName} по пути {path}</color>");
		prefabOject = Resources.Load<GameObject>(path);
	}

	void OnDestroy()
	{
		Debug.Log($"Объект <color=white>{prefabName}sGenerator</color> уничтожен");
	}
}