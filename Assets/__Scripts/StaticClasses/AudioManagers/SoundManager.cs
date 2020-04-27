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
}
