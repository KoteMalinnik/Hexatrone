using UnityEngine;

public static class OrbColorSetuper
{
	public static void setupColor(GameObject orb)
	{
		if(FormPartsSetuper.colors == null)
		{
			Debug.Log("[OrbColorSetuper] <color=red>Цвета отсутствуют.</color>");
			return;
		}

		SpriteRenderer spriteRenderer = orb.GetComponent<SpriteRenderer>();
		spriteRenderer.color = getRandomColor();

	}

	static Color getRandomColor()
	{
		var randomColor = FormPartsSetuper.colors[Random.Range(0, FormLevel.level+3)];
		return randomColor;
	}
}
