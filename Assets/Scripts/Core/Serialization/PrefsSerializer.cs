using UnityEngine;

namespace Serialization
{
	public static class PrefsSerializer
	{
		public enum Key
		{
			MusicIsOn,
			SoundIsOn,
			Language
		}

		// --- Save Methods ---

		public static void Save(Key key, int value)
		{
			PlayerPrefs.SetInt(key.ToString(), value);
			LogSave(key, value);
		}

		public static void Save(Key key, bool value)
		{
			PlayerPrefs.SetString(key.ToString(), value.ToString());
			LogSave(key, value);
		}

		public static void Save(Key key, float value)
		{
			PlayerPrefs.SetFloat(key.ToString(), value);
			LogSave(key, value);
		}

		public static void Save(Key key, string value)
		{
			PlayerPrefs.SetString(key.ToString(), value);
			LogSave(key, value);
		}

		// --- Load Methods ---

		public static int Load(Key key, int defaultValue = 0)
		{
			var value = PlayerPrefs.GetInt(key.ToString(), defaultValue);

			LogLoad(key, value);
			return value;
		}

		public static bool Load(Key key, bool defaultValue = false)
		{
			var value = bool.Parse(PlayerPrefs.GetString(key.ToString(), defaultValue.ToString()));

			LogLoad(key, value);
			return value;
		}

		public static float Load(Key key, float defaultValue = 0.0f)
		{
			var value = PlayerPrefs.GetFloat(key.ToString(), defaultValue);

			LogLoad(key, value);
			return value;
		}

		public static string Load(Key key, string defaultValue = "null")
		{
			var value = PlayerPrefs.GetString(key.ToString(), defaultValue);

			LogLoad(key, value);
			return value;
		}

		// ---------------------------------

		private static void LogSave<T>(Key key, T value) => Log.Message($"Параметр {key} сохранен. Значение: {value}");
		private static void LogLoad<T>(Key key, T value) => Log.Message($"Параметр {key} загружен. Значение: {value}");
	}
}