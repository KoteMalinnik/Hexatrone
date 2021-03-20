using UI.CustomScreen.Logic;
using UnityEngine;

public class MusicManager : AudioManager
{
	[SerializeField] AudioClip musicClip = null;

	private void Awake()
	{
		mainChanel = CreateAudioSource(volume: 0.1f, loop: true, playOnAwake: false);
		mainChanel.clip = musicClip;
	}

	private void OnEnable()
	{
		AudioButtonsController.OnMusicToggleChanged += ToggleAudio;
	}

	private void OnDisable()
	{
		AudioButtonsController.OnMusicToggleChanged -= ToggleAudio;
	}

	protected override void ToggleAudio(bool state)
	{
		Log.Message("Переключение MusicManager: " + state);

		if (state) Play();
		else Stop();
	}

	public void Play()
    {
		mainChanel.UnPause();
		if (!mainChanel.isPlaying) mainChanel.Play();
    }

	public void Stop()
    {
		mainChanel.Pause();
    }
}
