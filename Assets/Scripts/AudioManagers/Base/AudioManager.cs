using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
	#region Fields
	protected AudioSource mainChanel = null;
    #endregion

    protected AudioSource CreateAudioSource(float volume, bool loop, bool playOnAwake)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;

		return audioSource;
	}
}
