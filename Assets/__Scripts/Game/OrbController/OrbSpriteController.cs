using UnityEngine;

/// <summary>
/// Контроллер спрайтов сферы
/// </summary>
public class OrbSpriteController : MonoBehaviour
{
	[Header("Базовая")]

	[SerializeField]
	Sprite _basic = null;
	/// <summary>
	/// Спрайт базовой сферы.
	/// </summary>
	static Sprite basic;

	[Header("Бонусные")]

	[SerializeField]
	Sprite _deltaBonus = null;
	/// <summary>
	/// Спрайт бонуса дельты.
	/// </summary>
	static Sprite deltaBonus;

	[SerializeField]
	Sprite _criticalBonus = null;
	/// <summary>
	/// Спрайт критического бонуса.
	/// </summary>
	static Sprite criticalBonus;

	[SerializeField]
	Sprite _levelUpBonus = null;
	/// <summary>
	/// Спрайт бонуса повышения уровня.
	/// </summary>
	static Sprite levelUpBonus;

	void Awake()
	{
		basic = _basic;

		deltaBonus = _deltaBonus;
		criticalBonus = _criticalBonus;
		levelUpBonus = _levelUpBonus;

		Destroy(this);
	}

	/// <summary>
	/// Установить спрайт.
	/// </summary>
	/// <param name="orb">Сфера.</param>
	/// <param name="orbType">Тип сферы.</param>
	public static void setupSprite(GameObject orb, OrbTypeDefiner.orbType orbType)
	{
		SpriteRenderer spriteRenderer = orb.GetComponent<SpriteRenderer>();

		switch (orbType)
		{
			case OrbTypeDefiner.orbType.Basic:
				spriteRenderer.sprite = basic;
				break;
			case OrbTypeDefiner.orbType.DeltaBonus:
				spriteRenderer.sprite = deltaBonus;
				break;
			case OrbTypeDefiner.orbType.CriticalBonus:
				spriteRenderer.sprite = criticalBonus;
				break;
			case OrbTypeDefiner.orbType.LevelUpBonus:
				spriteRenderer.sprite = levelUpBonus;
				break;
		}
	}
}