using UnityEngine;

/// <summary>
/// Audio manager.
/// </summary>
public class MusicManager : MonoBehaviour
{
	[SerializeField]
	/// <summary>
	/// The music array
	/// </summary>
	AudioClip[] music = null;

	/// <summary>
	/// The music audio source.
	/// </summary>
	static AudioSource musicAudioSource = null;

	[SerializeField]
	/// <summary>
	/// Звук, воспроизводимый при проигрыше
	/// </summary>
	AudioClip gameOverSound = null;
	static AudioSource gameOverSoundSource = null;


	void Awake()
	{
		DontDestroyOnLoad(this);

		setupAudioSource(audioSource: ref musicAudioSource, audioClip: music, volume: 0.4f, loop: true, playOnAwake: true);
		setupAudioSource(audioSource: ref gameOverSoundSource, audioClip: gameOverSound, volume: 0.2f, loop: false, playOnAwake: false);
		setupAudioSource(audioSource: ref collectingSoulSoundSource, audioClip: collectingSoulSound, volume: 0.2f, loop: false, playOnAwake: false);
	}

	/// <summary>
	/// Создание и настройка компонента AudioSource
	/// </summary>
	void setupAudioSource(ref AudioSource audioSource, AudioClip audioClip, float volume, bool loop = true, bool playOnAwake = true)
	{
		if (volume < 0) volume = 0;
		if (volume > 1.0f) volume = 1.0f;

		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = volume;
		audioSource.loop = loop;
		audioSource.playOnAwake = playOnAwake;
		audioSource.clip = audioClip;
	}

	void Start()
	{
		switchMusic(); //Т.к. отсутствуют какие-либо Toggle в сцене Preload, то надо переключить Источник Музыки вручную
	}

	/// <summary>
	/// Состояние звука. True, если звук вкл., в противном случае false
	/// </summary>
	public static bool allowAudio { get; private set; } = true;

	/// <summary>
	/// Установка состояния звука
	/// </summary>
	public static void setAudioStatement(bool newAudioStatement)
	{
		Debug.Log($"Звук: {newAudioStatement}");
		allowAudio = newAudioStatement;

		if (musicAudioSource != null) switchMusic();
	}

	/// <summary>
	/// Переключение mainThemeSource
	/// </summary>
	static void switchMusic()
	{
		if(allowAudio)
		{
			musicAudioSource.Play();
			return;
		}

		musicAudioSource.Stop();
	}

	/// <summary>
	/// Воспроизвести звук при проигрыше
	/// </summary>
	public static void playGameOverSound()
	{
		if (gameOverSoundSource != null && allowAudio) gameOverSoundSource.Play();
	}

	void OnApplicationQuit()
	{
		//т.к. объект существует на всех сценах, то припишем ему сохранить все параметры по выходу
		Serialization.saveAllParametrs(); 
	}
}
