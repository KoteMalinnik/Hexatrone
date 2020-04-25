using UnityEngine;

public class Generator : MonoBehaviour
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

	/// <summary>
	/// Количество генерируемых объектов
	/// </summary>
	const int objectsCount = 4;

	void Awake()
	{
		loadPrefab();


		for (int i = 0; i < poolObjectsCount; i++)
		{
			newPoolObject = Instantiate(prefabOject, Vector3.zero, Quaternion.identity);

			newPoolObject.transform.parent = poolTransform;
			newPoolObject.name = $"{prefabName} ({i})";
			newPoolObject.setParentPool(pool);

			pool.addObject(newPoolObject);
		}

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