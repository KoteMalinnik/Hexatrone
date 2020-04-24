using UnityEngine;

/// <summary>
/// Music manager.
/// </summary>
public class MusicManager : AudioManager
{
	[SerializeField]
	AudioClip musicClip = null;

	/// <summary>
	/// The music audio source.
	/// </summary>
	static AudioSource audioSource = null;

	void Awake()
	{
		if (musicClip == null) musicClip = (AudioClip)Resources.Load("Audio/Music/mainTheme");

		setupAudioSource(audioSource: ref audioSource, volume: 1, loop: true, playOnAwake: false, clip: musicClip);
	}

	void Start()
	{
		//Toggle отсутствуют на сцене Preload.
		//Надо переключить Источник Музыки вручную.
		switchAudio();
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:MusicManager"/> allow audio.
	/// </summary>
	/// <value><c>true</c> if allow audio; otherwise, <c>false</c>.</value>
	public static bool allowAudio { get; private set; } = true;

	/// <summary>
	/// Sets the state of the audio.
	/// </summary>
	/// <param name="allowAudio">If set to <c>true</c> allow audio.</param>
	public static void setAudioState(bool allowAudio)
	{
		MusicManager.allowAudio = allowAudio;
		if (audioSource != null) switchAudio();
	}

	/// <summary>
	/// Switches playing the audio.
	/// </summary>
	static void switchAudio()
	{
		if (allowAudio)
		{
			audioSource.Play();
			return;
		}

		audioSource.Stop();
	}
}
