using CustomScreen;
using UnityEngine;

public class SoundManager : AudioManager
{
	#region Fields
	[SerializeField] AudioClip CorrectCollorCollected = null;
	[SerializeField] AudioClip IncorrectColorCollected = null;
	[SerializeField] AudioClip LevelUp = null;
	[SerializeField] AudioClip LevelDown = null;
	[SerializeField] AudioClip GameOver = null;
	[SerializeField] AudioClip GoalAchived = null;

	AudioSource secondChanel = null;
	bool audioIsAllowed = true;
	#endregion

	#region MonoBehaviour Callbacks
	private void Awake()
	{
		mainChanel = CreateAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
		secondChanel = CreateAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
	}

	private void OnEnable()
	{
		SettingsScreen.OnSoundToggleChanged += ToggleAudio;
	}

	private void OnDisable()
	{
		SettingsScreen.OnSoundToggleChanged -= ToggleAudio;
	}
	#endregion

	protected override void ToggleAudio(bool state)
	{
		Log.Message("Переключение SoundManager: " + state);

		if (state) AllowAudio();
		else DisallowAudio();
	}

	public void AllowAudio()
	{
		audioIsAllowed = true;
	}

	public void DisallowAudio()
	{
		audioIsAllowed = false;
	}

	private void PlaySound(AudioClip audioClip)
	{
		if (!audioIsAllowed) return;

		if (mainChanel.isPlaying)
        {
			secondChanel.PlayOneShot(audioClip);
			return;
        }

		mainChanel.PlayOneShot(audioClip);
	}
}
