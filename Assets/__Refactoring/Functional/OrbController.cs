using UnityEngine;

/// <summary>
/// Контроль перемещения Orb
/// </summary>
public sealed class OrbController : ObjectsController
{
	GameObject orb = null;

	void Start()
	{
		orb = transform.GetChild(0).gameObject;
	}

	Vector2 spawnPosition = Vector2.zero;

	protected override void setupObject(PoolObject obj)
	{
		Transform objTransform = obj.transform;

		setupPosition(objTransform);
		//objTransform.GetComponent<SoulAnimation>().setStartParametrs();
	}

	protected override void setupPosition(Transform objTransform)
	{
		//Выставляем позицию по оси Y так, чтобы душа была на видимой стороне платформы
		var newPosition = objTransform.localPosition;

		newPosition.x = lastObjectPosition.x;
		newPosition.y = platformPosition.y > 0 ? platformPosition.y - 1 : platformPosition.y + 1;
		newPosition.z = platformPosition.z;

		objTransform.localPosition = newPosition;
	}
}
