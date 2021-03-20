using UnityEngine;

public static class Serialization
{
    public static int Load(SerializationKeys key, int defaultValue)
	{
		var loadedValue = PlayerPrefs.GetInt(key.ToString(), defaultValue);
		Debug.Log($"Параметр {key} загружен. Значение: {loadedValue}");
		return loadedValue;
	}

	public static bool Load(SerializationKeys key, bool defaultValue)
	{
		var loadedValue = PlayerPrefs.GetInt(key.ToString(), defaultValue ? 1 : 0);
		Debug.Log($"Параметр {key} загружен. Значение: {loadedValue == 1}");
		return loadedValue == 1;
	}

	public static void Save(SerializationKeys key, int value)
	{
		PlayerPrefs.SetInt(key.ToString(), value);
		Debug.Log($"Параметр {key} сохранен. Значение: {value}");
	}

	public static void Save(SerializationKeys key, bool state)
	{
		PlayerPrefs.SetInt(key.ToString(), state ? 1 : 0);
		Debug.Log($"Параметр {key} сохранен. Значение: {state}");
	}
}
