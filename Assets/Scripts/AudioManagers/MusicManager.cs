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
		//подписаться на события включения/отключения музыки
	}

	private void OnDisable()
	{
		//отписаться на события включения/отключения музыки
	}
	#endregion

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
