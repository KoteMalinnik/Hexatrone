using UnityEngine;
using System.IO;

namespace Core
{
	interface IResourceManager
	{
		bool TryLoad<T>(string path, string name, out T result) where T : Object;
	}

	public class ResourceManager : IResourceManager
	{
        public bool TryLoad<T>(string path, string name, out T result) where T : Object
        {
			Log.Message($"Загрузка объекта \"{name}\" ({typeof(T).Name}) из ресурсов по пути: {path}.");

			var fullPath = Path.Combine(path, name);
			result = Resources.Load<T>(fullPath);

			if (result is null)
            {
				Log.Warning($"Ресурс по пути {path} отсутствует!");
				return false;
			}

			return true;
		}
    }

}