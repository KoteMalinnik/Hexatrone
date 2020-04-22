﻿using UnityEngine;

public class AudioManager : MonoBehaviour
{
	/// <summary>
	/// The music audio source.
	/// </summary>
	AudioSource audioSource = null;

    /// <summary>
    /// Setups the audio source.
    /// </summary>
    /// <param name="volume">Volume.</param>
    /// <param name="loop">If set to <c>true</c> loop.</param>
    /// <param name="playOnAwake">If set to <c>true</c> play on awake.</param>
	protected void setupAudioSource(float volume, bool loop, bool playOnAwake)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:AudioManager"/> allow audio.
	/// </summary>
	/// <value><c>true</c> if allow audio; otherwise, <c>false</c>.</value>
	protected bool allowAudio { get; private set; } = true;

	/// <summary>
	/// Sets the state of the audio.
	/// </summary>
	/// <param name="allowAudio">If set to <c>true</c> allow audio.</param>
	protected void setAudioState(bool allowAudio)
	{
		this.allowAudio = allowAudio;
		if (audioSource != null) switchAudio();
	}

	/// <summary>
	/// Switchs the audio.
	/// </summary>
	protected void switchAudio()
	{
		if (allowAudio)
		{
			audioSource.Play();
			return;
		}

		audioSource.Stop();
	}
}