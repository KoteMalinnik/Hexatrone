﻿using UnityEngine;

public class SoundManager : AudioManager
{
	#region Fields
	[SerializeField] AudioClip CorrectCollorCollected = null;
	[SerializeField] AudioClip IncorrectColorCollected = null;
	[SerializeField] AudioClip LevelUp = null;
	[SerializeField] AudioClip LevelDown = null;
	[SerializeField] AudioClip GameOver = null;
	[SerializeField] AudioClip GoalAchived = null;

	bool audioIsAllowed = true;
	#endregion

	#region MonoBehaviour Callbacks
	private void Start()
	{
		SetupAudioSource(volume: 0.1f, loop: false, playOnAwake: false);

		PlaySound(CorrectCollorCollected);
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

	private void PlaySound(AudioClip audioClip)
	{
		if (!audioIsAllowed) return;
		Source.PlayOneShot(audioClip);
	}
}