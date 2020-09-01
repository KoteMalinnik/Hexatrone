using UnityEngine;

public static class ObjectInstantiator
{
	public static GameObject Instantiate
		(
		GameObject prefab,
		Transform parent,
		Vector2 position,
		Quaternion rotation
		)
	{
		if (prefab == null)
		{
			Log.Warning("Префаб пуст.");
			return null;
		}

		Log.Message("Создание объекта: " + prefab?.name);
		GameObject form = MonoBehaviour.Instantiate(prefab, position, rotation, parent);
		return form;
	}
}