using UnityEngine;

public class SoundManager : AudioManager
{
	#region Fields
	bool audioIsAllowed = true;
	#endregion

	#region MonoBehaviour Callbacks
	private void Start()
	{
		SetupAudioSource(volume: 0.1f, loop: false, playOnAwake: false);
	}

	private void OnEnable()
	{
		//подписаться на события включения/отключения звука
	}

	private void OnDisable()
	{
		//отписаться на события включения/отключения звука
	}
	#endregion

	private void AllowAudio()
	{
		audioIsAllowed = true;
	}

	private void DisallowAudio()
	{
		audioIsAllowed = false;
	}

	private void PlaySound(Sounds sound)
	{
		if (!audioIsAllowed) return;
		
		AudioClip audioClip = Resources.Load<AudioClip>(@"Audio\Sounds\" + sound.ToString() + ".asset");
		if (audioClip == null)
        {
			Log.Error($"Звук {sound} отсутствует по пути <Audio\\Sounds\\>.");
			return;
        }

		Source.PlayOneShot(audioClip);
	}
}
