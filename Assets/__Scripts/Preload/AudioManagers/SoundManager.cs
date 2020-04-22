using UnityEngine;

public class SoundManager : AudioManager
{
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

	void Awake()
	{
		setupAudioSource(volume: 1, loop: false, playOnAwake: false);
	}

	/// <summary>
	/// Plays the sound by the key.
	/// </summary>
	/// <param name="key">0-CollectCorrectOrb. 1-CollectWrongOrb. 2-CollectBaff. 3-levelUp. 4-levelDown.</param>
	public void playSound(int key)
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
			default:
				Debug.Log("[SoundManager] Неверный ключ аудио дорожки");
				break;
		}
	}
}
