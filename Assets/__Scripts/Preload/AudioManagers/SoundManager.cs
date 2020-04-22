using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
	/// <summary>
	/// Звук, воспроизводимый при проигрыше
	/// </summary>
	AudioClip gameOverSound = null;
	static AudioSource gameOverSoundSource = null;
}
