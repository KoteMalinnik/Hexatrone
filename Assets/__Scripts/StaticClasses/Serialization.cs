using UnityEngine;

/// <summary>
/// Сериализация данных
/// </summary>
public static class Serialization
{
	//Ключи для сериализуемых параметров
	const string key_musicStatement = "key_musicStatement";
	const string key_soundStatement = "key_soundStatement";

	/// <summary>
	/// Загрузка всех параметров
	/// </summary>
	public static void loadAllParametrs()
	{
		Debug.Log("Загрузка параметров из PlayerPrefs");

		var musicState = loadValue(key_musicStatement, true);
		MusicManager.setAudioState(musicState);

		var soundState = loadValue(key_soundStatement, true);
		MusicManager.setAudioState(soundState);
	}

	public static void saveAllParametrs()
	{
		Debug.Log("Сохранение параметров в PlayerPrefs");

		saveValue(key_soundStatement, SoundManager.allowAudio);
		saveValue(key_musicStatement, MusicManager.allowAudio);
	}

	/// <summary>
	/// Загрузка параметра типа int с ключом key. Если такого нет, ему будет присвоено значение defaultValue
	/// </summary>
	/// <param name="key">Ключ.</param>
	/// <param name="defaultValue">Значение по умолчанию.</param>
	static int loadValue(string key, int defaultValue)
	{
		var parametrValue = PlayerPrefs.GetInt(key, defaultValue);
		Debug.Log($"Параметр {key} загружен. Значение: {parametrValue}");
		return parametrValue;
	}

	/// <summary>
	/// Загрузка параметра типа bool с ключом key. Если такого нет, ему будет присвоено значение defaultValue
	/// </summary>
	/// <param name="key">Ключ.</param>
	/// <param name="defaultValue">Значение по умолчанию.</param>
	static bool loadValue(string key, bool defaultValue)
	{
		var parametrValue = loadValue(key, defaultValue ? 1 : 0);
		bool statementValue = parametrValue == 1;
		return statementValue;
	}

	/// <summary>
	/// Сохранение параметра типа int с ключом key
	/// </summary>
	static void saveValue(string key, int parametrValue)
	{
		PlayerPrefs.SetInt(key, parametrValue);
		Debug.Log($"Параметр {key} сохранен. Значение: {parametrValue}");
	}

	/// <summary>
	/// Сохранение параметра типа bool с ключом key
	/// </summary>
	static void saveValue(string key, bool statementValue)
	{
		int parametrValue = statementValue ? 1 : 0;
		saveValue(key, parametrValue);
	}
}
