using UnityEngine;

public class MusicManager : AudioManager
{
	#region Fields
	[SerializeField] AudioClip musicClip = null;
	#endregion

	#region MonoBehaviour Callbacks
	private void Awake()
	{
		SetupAudioSource(volume: 0.1f, loop: true, playOnAwake: false, clip: musicClip);
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
		Source.UnPause();
		if (!Source.isPlaying) Source.Play();
    }

	public void Stop()
    {
		Source.Pause();
    }
}
