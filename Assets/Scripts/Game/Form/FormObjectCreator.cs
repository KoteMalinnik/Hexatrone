using UnityEngine;

public class FormObjectCreator : MonoBehaviour
{
	#region Fields
	[SerializeField] string path = "Prefabs\\Forms\\";
	[SerializeField] string nameTemplate = "Level_";
    #endregion

    public GameObject Create(int formLevel, Transform parent, Vector2 position, Quaternion rotation)
	{
		Log.Message("Создание объекта формы уровня " + formLevel);

		var fullPath = path + nameTemplate + formLevel;
		Log.Message("Загрузка префаба формы по пути: " + fullPath);
		GameObject loadedPrefab = Resources.Load<GameObject>(fullPath);

		if (loadedPrefab == null)
		{
			Log.Warning($"Префаб по пути {fullPath} отсутствует!");
			return null;
		}

		return Instantiate(loadedPrefab, position, rotation, parent);
	}
}
