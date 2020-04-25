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

	static float bonusThreshold = 0.9f;
	public static orbType getNewOrbType(ref GameObject orb)
	{
		BasicOrb orbClass = orb.GetComponent<BasicOrb>();
		Destroy(orbClass);

		float probability = Random.Range(0.0f, 1.0f);
		if(probability < bonusThreshold) 
		{
			orb.AddComponent<BasicOrb>();
			return orbType.Basic;
		}
			

		probability = Random.Range(0.0f, 1.0f);

		if (probability < 0.5f)
		{
			orb.AddComponent<DeltaBonus>();
			return orbType.DeltaBonus;
		}
			
		if (probability < 0.8f)
		{
			orb.AddComponent<CriticalBonus>();
			return orbType.CriticalBonus;
		}
			
		orb.AddComponent<LevelUpBonus>();
		return orbType.LevelUpBonus;
	}
}
