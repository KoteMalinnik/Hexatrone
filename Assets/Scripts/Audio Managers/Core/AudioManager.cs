using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
    #region Fields
    AudioSource audioSource = null;
	#endregion

	#region Properties
	protected AudioSource Source => audioSource;
    #endregion

    protected void SetupAudioSource(float volume, bool loop, bool playOnAwake, AudioClip clip = null)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;
	}
}
