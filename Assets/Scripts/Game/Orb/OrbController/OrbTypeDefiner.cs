using UnityEngine;

/// <summary>
/// Определитель типа сферы.
/// </summary>
public class OrbTypeDefiner : MonoBehaviour
{
	//[SerializeField, Range(0.1f, 1.0f)]
	//float _bonusThreshold = 0.9f;
	///// <summary>
	///// Коэффициент появления бонусной сферы. Чем больше значение, тем меньше вероятность появления бонусной сферы.
	///// </summary>
	//static float bonusThreshold = 0.9f;

	//void Awake()
	//{
	//	bonusThreshold = _bonusThreshold;
	//	Destroy(this);
	//}

	///// <summary>
	///// Сгенерировать тип сферы.
	///// </summary>
	//public static orbType getNewOrbType()
	//{
	//	float probability = Random.Range(0.0f, 1.0f);

	//	if(probability < bonusThreshold) return orbType.Basic;

	//	probability = Random.Range(0.0f, 1.0f);

	//	if (probability < 0.5f) return orbType.DeltaBonus;
	//	if (probability < 0.8f) return orbType.CriticalBonus;
	//	return orbType.LevelUpBonus;
	//}
}
