using UnityEngine;

/// <summary>
/// Audio manager.
/// </summary>
public class MusicManager : AudioManager
{
	[SerializeField]
	AudioClip[] music = null;

	void Awake()
	{
		setupAudioSource(volume: 1, loop: true, playOnAwake: true);
	}

	void Start()
	{
		//Toggle отсутствуют на сцене Preload.
		//Надо переключить Источник Музыки вручную.
		switchAudio();
	}


}
