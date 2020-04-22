using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Setups the audio source.
    /// </summary>
    /// <param name="volume">Volume.</param>
    /// <param name="loop">If set to <c>true</c> loop.</param>
    /// <param name="playOnAwake">If set to <c>true</c> play on awake.</param>
	protected void setupAudioSource(ref AudioSource audioSource, float volume, bool loop, bool playOnAwake, AudioClip clip = null)
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
