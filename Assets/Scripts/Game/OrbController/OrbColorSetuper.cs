using UnityEngine;

/// <summary>
/// Установщик цвета объекта Orb.
/// </summary>
public static class OrbColorSetuper
{
	/// <summary>
	/// Установить цвет.
	/// </summary>
	/// <param name="orbColorSetuper">ColorSetuper сферы.</param>
	public static void setupColor(ColorSetuper orbColorSetuper)
	{
		if(FormPartsSetuper.colors == null)
		{
			Debug.Log("[OrbColorSetuper] <color=red>Цвета отсутствуют.</color>");
			return;
		}

		orbColorSetuper.setColor(getRandomColor());
	}

	/// <summary>
	/// Получить случайный цвет, который присутствует у существующей формы.
	/// </summary>
	static Color getRandomColor()
	{
		var randomColor = FormPartsSetuper.colors[Random.Range(0, FormLevelController.level+3)];
		return randomColor;
	}
}
