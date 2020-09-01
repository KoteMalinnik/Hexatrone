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
	/// <param name="orbSpriteRenderer">SpriteRenderer сферы.</param>
	/// <param name="orbType">Тип сферы.</param>
	//public static void setupSprite(SpriteRenderer orbSpriteRenderer, OrbTypeDefiner.orbType orbType)
	//{
	//	switch (orbType)
	//	{
	//		case OrbTypeDefiner.orbType.Basic:
	//			orbSpriteRenderer.sprite = basic;
	//			break;
	//		case OrbTypeDefiner.orbType.DeltaBonus:
	//			orbSpriteRenderer.sprite = deltaBonus;
	//			break;
	//		case OrbTypeDefiner.orbType.CriticalBonus:
	//			orbSpriteRenderer.sprite = criticalBonus;
	//			break;
	//		case OrbTypeDefiner.orbType.LevelUpBonus:
	//			orbSpriteRenderer.sprite = levelUpBonus;
	//			break;
	//	}
	//}
}