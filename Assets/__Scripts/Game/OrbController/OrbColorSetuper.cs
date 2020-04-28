using UnityEngine;

/// <summary>
/// Установщик цвета объекта Orb.
/// </summary>
public static class OrbColorSetuper
{
	/// <summary>
	/// Установить цвет.
	/// </summary>
	/// <param name="orb">Сфера.</param>
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

	/// <summary>
	/// Получить случайный цвет, который присутствует у существующей формы.
	/// </summary>
	static Color getRandomColor()
	{
		var randomColor = FormPartsSetuper.colors[Random.Range(0, FormLevel.level+3)];
		return randomColor;
	}
}
