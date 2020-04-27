using UnityEngine;

/// <summary>
/// Music manager.
/// </summary>
public class MusicManager : AudioManager
{
	[SerializeField]
	AudioClip musicClip = null;

	public static MusicManager instance { get; private set; } = null;
	void Awake()
	{
		instance = this;

		if (musicClip == null) musicClip = (AudioClip)Resources.Load("Audio/Music/mainTheme");

		audioSource = setupAudioSource(volume: 0.5f, loop: true, playOnAwake: false, clip: musicClip);
	}

	void Start()
	{
		//Toggle отсутствуют на сцене Preload.
		//Надо переключить Источник Музыки вручную.
		switchAudio();
	}

	/// <summary>
	/// Sets the state of the audio.
	/// </summary>
	/// <param name="allowAudio">If set to <c>true</c> allow audio.</param>
	public override void setAudioState(bool allowAudio)
	{
		this.allowAudio = allowAudio;
		if (audioSource != null) switchAudio();
	}

	/// <summary>
	/// Switches playing the audio.
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
