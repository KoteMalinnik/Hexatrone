using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Управление аудиокнопками GUI.
/// </summary>
public sealed class AudioButtonsControll : MonoBehaviour
{
    [Header("GUI Audiobutton's images")]

	[SerializeField]
	/// <summary>
	/// Image кнопки музыки.
	/// </summary>
	Image imageMusicButton = null;

	[SerializeField]
	/// <summary>
	/// Image кнопки звука.
	/// </summary>
	Image imageSoundButton = null;

	[Header("GUI Audiobutton's colors")]

	[SerializeField]
	/// <summary>
	/// Цвет при разрешенном воспроизведении аудио.
	/// </summary>
	Color allowAudioColor = Color.blue;

	[SerializeField]
	/// <summary>
	/// Цвет при запрещенном воспроизведении аудио.
	/// </summary>
	Color disallowAudioColor = Color.red;

	// Установить начальные цвета кнопок.
	void Start()
	{
		if (MusicManager.instance != null) imageMusicButton.color = MusicManager.instance.allowAudio ? allowAudioColor : disallowAudioColor;
		if (SoundManager.instance != null) imageSoundButton.color = SoundManager.instance.allowAudio ? allowAudioColor : disallowAudioColor;
	}

	/// <summary>
	/// Переключить звук.
	/// </summary>
	public void __Sound()
	{
		if (SoundManager.instance == null) return;

		Debug.Log("[MainMenuGUI] Переключение звука.");

		var state = imageSoundButton.color == allowAudioColor;
		state = !state;
		SoundManager.instance.setAudioState(state);

		imageSoundButton.color = state ? allowAudioColor : disallowAudioColor;
	}

	/// <summary>
	/// Переключить музыку.
	/// </summary>
	public void __Music()
	{
		if (MusicManager.instance == null) return;

		Debug.Log("[MainMenuGUI] Переключение музыки.");

		var state = imageMusicButton.color == allowAudioColor;
		state = !state;
		MusicManager.instance.setAudioState(state);

		imageMusicButton.color = state ? allowAudioColor : disallowAudioColor;
	}
}
