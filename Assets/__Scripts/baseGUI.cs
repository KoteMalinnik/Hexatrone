using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Общая логика всех GUI.
/// </summary>
public class baseGUI : MonoBehaviour
{
    [Header("GUI Audiobutton's images")]

	[SerializeField]
	/// <summary>
	/// Image кнопки музыки.
	/// </summary>
	protected Image imageMusicButton = null;

	[SerializeField]
	/// <summary>
	/// Image кнопки звука.
	/// </summary>
	protected Image imageSoundButton = null;

	[Header("GUI Audiobutton's colors")]

	[SerializeField]
	/// <summary>
	/// Цвет при разрешенном воспроизведении аудио.
	/// </summary>
	protected Color allowAudioColor = Color.blue;

	[SerializeField]
	/// <summary>
	/// Цвет при запрещенном воспроизведении аудио.
	/// </summary>
	protected Color disallowAudioColor = Color.red;

	/// <summary>
	/// Установить начальные цвета кнопок.
	/// </summary>
	protected void presetAudioButtons()
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

	/// <summary>
	/// Открыть панель.
	/// </summary>
	public void __ShowPanel(GameObject panel)
	{
		Debug.Log("[MainMenuGUI] Показать панель " + panel.name);
		panel.SetActive(true);
	}

	/// <summary>
	/// Скрыть панель.
	/// </summary>
	public void __HidePanel(GameObject panel)
	{
		Debug.Log("[MainMenuGUI] Скрыть панель " + panel.name);
		panel.SetActive(false);
	}
}
