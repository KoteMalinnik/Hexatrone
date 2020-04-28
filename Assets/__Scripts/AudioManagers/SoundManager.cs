using UnityEngine;

/// <summary>
/// Менеджер звука.
/// </summary>
public class SoundManager : AudioManager
{
	/// <summary>
	/// Экземпляр
	/// </summary>
	public static SoundManager instance { get; private set; } = null;
	void Awake()
	{
		instance = this;
		audioSource = setupAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
	}

	[SerializeField]
	/// <summary>
	/// Звук при совпадении цветов Orb и Part.
	/// </summary>
	AudioClip CollectCorrectOrb = null;

	[SerializeField]
	/// <summary>
	/// Звук при несовпадении цветов Orb и Part
	/// </summary>
	AudioClip CollectWrongOrb = null;

	[SerializeField]
	/// <summary>
	/// Звук при совпадении цветов BonusOrb и Part
	/// </summary>
	AudioClip CollectBaff = null;

	[SerializeField]
	/// <summary>
	/// Звук при повышении уровня
	/// </summary>
	AudioClip levelUp = null;

	[SerializeField]
	/// <summary>
	/// Звук при понижении уровня
	/// </summary>
	AudioClip levelDown = null;

	[SerializeField]
	/// <summary>
	/// Звук при конце игры
	/// </summary>
	AudioClip gameOver = null;

	[SerializeField]
	/// <summary>
	/// Звук при достижении целей уровня
	/// </summary>
	AudioClip goalAchieved = null;

	[SerializeField]
	/// <summary>
	/// Звук при нажатии на элемент GUI
	/// </summary>
	AudioClip clickGUI = null;

	/// <summary>
	/// Проиграть звук под номером key
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
	/// Проиграть звук
	/// </summary>
	/// <param name="audioClip">Звук.</param>
	static void playOneShot(AudioClip audioClip)
	{
		instance.audioSource.PlayOneShot(audioClip);
	}
}
