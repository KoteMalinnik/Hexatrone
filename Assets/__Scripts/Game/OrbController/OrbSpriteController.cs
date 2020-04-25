using UnityEngine;

public class OrbSpriteController : MonoBehaviour
{
	[Header("Базовая")]

	[SerializeField]
	Sprite _basic = null;
	static Sprite basic;

	[Header("Бонусные")]

	[SerializeField]
	Sprite _deltaBonus = null;
	static Sprite deltaBonus;

	[SerializeField]
	Sprite _criticalBonus = null;
	static Sprite criticalBonus;

	[SerializeField]
	Sprite _levelUpBonus = null;
	static Sprite levelUpBonus;

	void Awake()
	{
		basic = _basic;

		deltaBonus = _deltaBonus;
		criticalBonus = _criticalBonus;
		levelUpBonus = _levelUpBonus;
	}

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