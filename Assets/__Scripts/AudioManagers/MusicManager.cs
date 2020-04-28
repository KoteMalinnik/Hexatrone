using UnityEngine;

/// <summary>
/// Менеджер музыки.
/// </summary>
public class MusicManager : AudioManager
{
	[SerializeField]
	/// <summary>
	/// Музыка.
	/// </summary>
	AudioClip musicClip = null;

	/// <summary>
	/// Экземпляр.
	/// </summary>
	public static MusicManager instance { get; private set; } = null;

	void Awake()
	{
		instance = this;

		if (musicClip == null) musicClip = (AudioClip)Resources.Load("Audio/Music/mainTheme");

		audioSource = setupAudioSource(volume: 0.1f, loop: true, playOnAwake: false, clip: musicClip);
	}

	void Start()
	{
		//Toggle отсутствуют на сцене Preload.
		//Надо переключить Источник Музыки вручную.
		switchAudio();
	}

	/// <summary>
	/// Установить разрешение проигрывания аудио.
	/// </summary>
	/// <param name="allowAudio">Если установить <c>true</c>, то проигрывание аудио будет разрешено.</param>
	public override void setAudioState(bool allowAudio)
	{
		this.allowAudio = allowAudio;
		if (audioSource != null) switchAudio();
	}

	/// <summary>
	/// Переключить разрешение проигрывания музыки.
	/// </summary>
	void switchAudio()
	{
		if (allowAudio)
		{
			audioSource.Play();
			return;
		}

		audioSource.Stop();
	}
}
