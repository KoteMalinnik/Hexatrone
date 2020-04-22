﻿using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioManager : MonoBehaviour
{
	/// <summary>
	/// The music audio source.
	/// </summary>
	protected AudioSource audioSource { get; private set; } = null;

    /// <summary>
    /// Setups the audio source.
    /// </summary>
    /// <param name="volume">Volume.</param>
    /// <param name="loop">If set to <c>true</c> loop.</param>
    /// <param name="playOnAwake">If set to <c>true</c> play on awake.</param>
	protected void setupAudioSource(float volume, bool loop, bool playOnAwake, AudioClip clip = null)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:AudioManager"/> allow audio.
	/// </summary>
	/// <value><c>true</c> if allow audio; otherwise, <c>false</c>.</value>
	public bool allowAudio { get; private set; } = true;

	/// <summary>
	/// Sets the state of the audio.
	/// </summary>
	/// <param name="allowAudio">If set to <c>true</c> allow audio.</param>
	public void setAudioState(bool allowAudio)
	{
		this.allowAudio = allowAudio;
		if (audioSource != null) switchAudio();
	}

	/// <summary>
	/// Switches playing the audio.
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

	/// <summary>
	/// Plays the audio clip one time.
	/// </summary>
	/// <param name="audioClip">Audio clip.</param>
	protected void playOneShot(AudioClip audioClip)
	{
		if(allowAudio) audioSource.PlayOneShot(audioClip);
	}
}
