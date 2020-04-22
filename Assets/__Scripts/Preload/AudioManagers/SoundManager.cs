using UnityEngine;

public class SoundManager : AudioManager
{
	void Awake()
	{
		setupAudioSource(volume: 1, loop: false, playOnAwake: false);
	}

}
