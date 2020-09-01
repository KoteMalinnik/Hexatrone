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
		Log.Message("Создание формы: " + prefab?.name);

		if (prefab == null)
		{
			Log.Warning("Префаб пуст.");
			return null;
		}

		GameObject form = MonoBehaviour.Instantiate(prefab, position, rotation, parent);
		return form;
	}
}