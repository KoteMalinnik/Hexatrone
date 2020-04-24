using UnityEngine;

public class SoundManager : AudioManager
{
	/// <summary>
	/// The sound audio source.
	/// </summary>
	static AudioSource audioSource = null;

	[SerializeField]
	AudioClip CollectCorrectOrb = null;

	[SerializeField]
	AudioClip CollectWrongOrb = null;

	[SerializeField]
	AudioClip CollectBaff = null;

	[SerializeField]
	AudioClip levelUp = null;

	[SerializeField]
	AudioClip levelDown = null;

	[SerializeField]
	AudioClip gameOver = null;

	[SerializeField]
	AudioClip goalAchieved = null;

	[SerializeField]
	AudioClip clickGUI = null;

	void Awake()
	{
		setupAudioSource(audioSource: ref audioSource, volume: 1, loop: false, playOnAwake: false);
	}

	/// <summary>
	/// Plays the sound by the key.
	/// </summary>
	/// <param name="key">0-CollectCorrectOrb. 1-CollectWrongOrb. 2-CollectBaff. 3-levelUp. 4-levelDown. 5-gameOver. 6-goalAchieved. 7-clickGUI.</param>
	public void playSound(int key)
	{
		if (allowAudio)
		{
			switch (key)
			{
				case 0:
					playOneShot(CollectCorrectOrb);
					break;
				case 1:
					playOneShot(CollectCorrectOrb);
					break;
				case 2:
					playOneShot(CollectCorrectOrb);
					break;
				case 3:
					playOneShot(CollectCorrectOrb);
					break;
				case 4:
					playOneShot(CollectCorrectOrb);
					break;
				case 5:
					playOneShot(gameOver);
					break;
				case 6:
					playOneShot(goalAchieved);
					break;
				case 7:
					playOneShot(clickGUI);
					break;
				default:
					Debug.Log("[SoundManager] Неверный ключ аудио дорожки");
					break;
			}	
		}
	}

	/// <summary>
	/// Plays the audio clip one time.
	/// </summary>
	/// <param name="audioClip">Audio clip.</param>
	void playOneShot(AudioClip audioClip)
	{
		audioSource.PlayOneShot(audioClip);
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:SoundManager"/> allow audio.
	/// </summary>
	/// <value><c>true</c> if allow audio; otherwise, <c>false</c>.</value>
	public static bool allowAudio { get; private set; } = true;

	/// <summary>
	/// Sets the state of the audio.
	/// </summary>
	/// <param name="allowAudio">If set to <c>true</c> allow audio.</param>
	public static void setAudioState(bool allowAudio)
	{
		SoundManager.allowAudio = allowAudio;
	}
}
