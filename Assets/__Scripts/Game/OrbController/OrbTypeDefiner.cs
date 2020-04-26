using UnityEngine;

public class OrbTypeDefiner : MonoBehaviour
{
    public enum orbType
	{
		Basic,
		DeltaBonus,
		CriticalBonus,
		LevelUpBonus
	}

	[SerializeField, Range(0.1f, 1.0f)]
	float _bonusThreshold = 0.9f;
	static float bonusThreshold = 0.9f;

	void Awake()
	{
		bonusThreshold = _bonusThreshold;
		Destroy(this);
	}

	public static orbType getNewOrbType(GameObject orb)
	{
		OrbBasic orbClass = orb.GetComponent<OrbBasic>();
		Destroy(orbClass);

		float probability = Random.Range(0.0f, 1.0f);
		if(probability < bonusThreshold) 
		{
			orb.AddComponent<OrbBasic>();
			return orbType.Basic;
		}
			

		probability = Random.Range(0.0f, 1.0f);

		if (probability < 0.5f)
		{
			orb.AddComponent<OrbDeltaBonus>();
			return orbType.DeltaBonus;
		}
			
		if (probability < 0.8f)
		{
			orb.AddComponent<OrbCriticalBonus>();
			return orbType.CriticalBonus;
		}
			
		orb.AddComponent<OrbLevelUpBonus>();
		return orbType.LevelUpBonus;
	}
}
