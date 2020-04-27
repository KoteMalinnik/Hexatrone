using UnityEngine;

public class SoundManager : AudioManager
{
	public static SoundManager instance { get; private set; } = null;
	void Awake()
	{
		instance = this;
		audioSource = setupAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
	}

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

	/// <summary>
	/// Plays the sound by the key.
	/// </summary>
	/// <param name="key">0-CorrectOrb. 1-WrongOrb. 2-Baff. 3-levelUp. 4-levelDown. 5-gameOver. 6-goalAchieved. 7-clickGUI.</param>
	public static void playSound(int key)
	{
		if (instance == null) return;

		if (instance.allowAudio)
		{
			switch (key)
			{
				case 0:
					playOneShot(instance.CollectCorrectOrb);
					break;
				case 1:
					playOneShot(instance.CollectWrongOrb);
					break;
				case 2:
					playOneShot(instance.CollectBaff);
					break;
				case 3:
					playOneShot(instance.levelUp);
					break;
				case 4:
					playOneShot(instance.levelDown);
					break;
				case 5:
					playOneShot(instance.gameOver);
					break;
				case 6:
					playOneShot(instance.goalAchieved);
					break;
				case 7:
					playOneShot(instance.clickGUI);
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
	static void playOneShot(AudioClip audioClip)
	{
		instance.audioSource.PlayOneShot(audioClip);
	}
}
