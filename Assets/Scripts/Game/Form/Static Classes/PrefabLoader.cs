using UnityEngine;

namespace Form
{
	public static class PrefabLoader
	{
		public static GameObject Load(int formLevel, string path, string nameTemplate)
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

			return loadedPrefab;
		}
	}
}