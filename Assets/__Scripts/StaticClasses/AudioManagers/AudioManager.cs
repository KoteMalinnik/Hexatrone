using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{
	/// <summary>
	/// The audio source.
	/// </summary>
	protected AudioSource audioSource = null;

    /// <summary>
    /// Setups the audio source.
    /// </summary>
    /// <param name="volume">Volume.</param>
    /// <param name="loop">If set to <c>true</c> loop.</param>
    /// <param name="playOnAwake">If set to <c>true</c> play on awake.</param>
	protected AudioSource setupAudioSource(float volume, bool loop, bool playOnAwake, AudioClip clip = null)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;

		return audioSource;
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:AudioManager"/> allow audio.
	/// </summary>
	/// <value><c>true</c> if allow audio; otherwise, <c>false</c>.</value>
	public bool allowAudio { get; protected set; } = true;

	/// <summary>
	/// Sets the state of the audio.
	/// </summary>
	/// <param name="allowAudio">If set to <c>true</c> allow audio.</param>
	public virtual void setAudioState(bool allowAudio)
	{
		this.allowAudio = allowAudio;
	}
}
