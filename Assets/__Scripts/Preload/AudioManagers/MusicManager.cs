using UnityEngine;

/// <summary>
/// Music manager.
/// </summary>
public class MusicManager : AudioManager
{
	[SerializeField]
	AudioClip musicClip = null;

	void Awake()
	{
		if (musicClip == null) musicClip = (AudioClip)Resources.Load("Audio/Music/mainTheme");

		setupAudioSource(volume: 1, loop: true, playOnAwake: false, clip: musicClip);
	}

	void Start()
	{
		//Toggle отсутствуют на сцене Preload.
		//Надо переключить Источник Музыки вручную.
		switchAudio();
	}
}
