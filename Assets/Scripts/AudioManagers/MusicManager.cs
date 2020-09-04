using CustomScreen;
using UnityEngine;

public class MusicManager : AudioManager
{
	#region Fields
	[SerializeField] AudioClip musicClip = null;
	#endregion

	#region MonoBehaviour Callbacks
	private void Awake()
	{
		mainChanel = CreateAudioSource(volume: 0.1f, loop: true, playOnAwake: false);
		mainChanel.clip = musicClip;
	}

	private void OnEnable()
	{
		SettingsScreen.OnMusicToggleChanged += ToggleAudio;
	}

	private void OnDisable()
	{
		SettingsScreen.OnMusicToggleChanged -= ToggleAudio;
	}
	#endregion

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
