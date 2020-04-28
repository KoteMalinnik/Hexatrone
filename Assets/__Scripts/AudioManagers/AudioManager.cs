using UnityEngine;

/// <summary>
/// Менеджер аудио.
/// </summary>
public abstract class AudioManager : MonoBehaviour
{
	/// <summary>
	/// Источник аудио.
	/// </summary>
	protected AudioSource audioSource = null;

    /// <summary>
    /// Настроить источник аудио
    /// </summary>
    /// <param name="volume">Громкость.</param>
    /// <param name="loop">Если установить <c>true</c>, то проигрывание зациклится.</param>
    /// <param name="playOnAwake">Если установить <c>true</c>, то начинать проигрывание при пробуждении объекта.</param>
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
	/// Разрешение проигрывания аудио на этом <see cref="T:AudioManager"/>.
	/// </summary>
	public bool allowAudio { get; protected set; } = true;

	/// <summary>
	/// Установить разрешение проигрывания аудио
	/// </summary>
	/// <param name="allowAudio">Если установить <c>true</c>, то проигрывание аудио будет разрешено.</param>
	public virtual void setAudioState(bool allowAudio)
	{
		this.allowAudio = allowAudio;
	}
}
