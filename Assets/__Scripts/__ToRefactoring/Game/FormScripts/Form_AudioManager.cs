using UnityEngine;

/*

	ОТВЕЧАЕТ ЗА ЗВУКИ УРОВНЯ И СЛОВЛЕННЫХ СФЕР

 */

public class Form_AudioManager : helpBehaviour
{
	public static Form_AudioManager instance { get; private set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

		gm = GameManager.instance;
		gm._formAudioManager = instance;
	}


	public AudioClip rightOrbSound; //звук правильной сферы
	public AudioClip wrongOrbSound; //звук неправильной сферы

	[Space]

	public AudioClip lvlUpSound; 	 //звук повышения уровня
	public AudioClip lvlDownSound;  //звук понижения уровня

	[Space]
	public AudioClip bafSound; //звук поглощения бафа


	[Space]
	public AudioClip gameOverSound; //звук при проигрыше
	public AudioClip levelCompliteSound; //звук при пройденном уровне

	AudioSource aSe; // Источник звука формы: звуки сфер и уровня

	void Start()
	{
		aSe = get_AudioSource(); //получаем источник звука на FormManager
	}

	//Воспроизвести звук
	public void playSound(AudioClip ac)
	{
		if(gm.isSoundOn) aSe.PlayOneShot(ac);
	}
}
