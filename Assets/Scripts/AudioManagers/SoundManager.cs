using UI.CustomScreen.Logic;
using UnityEngine;

public class SoundManager : AudioManager
{
	AudioSource secondChanel = null;
	bool audioIsAllowed = true;
	
	private void Awake()
	{
		mainChanel = CreateAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
		secondChanel = CreateAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
	}

	private void OnEnable()
	{
		AudioButtonsController.OnSoundToggleChanged += ToggleAudio;
	}

	private void OnDisable()
	{
		AudioButtonsController.OnSoundToggleChanged -= ToggleAudio;
	}

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
