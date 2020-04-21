using UnityEngine;
using System.Collections;

/*

	МЕНЕДЖЕР ЗВУКОВ И МУЗЫКИ
	ХРАНИТ МУЗЫКУ
	ВКЛЮЧЕНИЕ/ВЫКЛЮЧЕНИЕ ПРОИСХОДИТ ЗДЕСЬ

 */

public class AudioManager : helpBehaviour
{
	public AudioClip[] music; //массив музыки
	AudioSource aSe; // Источник музыки

	void Awake()
	{
		gm = get_GameManager();
		aSe = get_AudioSource(); //получаем источник звука GM
	}

	//очередь воспроизведения музыки
	void Update()
	{
		if (!aSe.isPlaying && gm.isMusicOn)    // если музыка не играет и музыка включена
		{
			aSe.clip = music[Random.Range(0, music.Length)]; //выбрать случайную песню
			aSe.Play(); //воспроизвести выбранную песню

			StartCoroutine(Wait()); //дождаться окончания трека
		}
		else if (!gm.isMusicOn) StopMusic(); //выключить музыку, если музыка выключена
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(aSe.clip.length * Time.timeScale); //дождаться окончания трека
	}

	//остановить музыку
	public void StopMusic() 
	{ 
		StopCoroutine(Wait());
		aSe.Stop(); 
	}
}

