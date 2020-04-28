using UnityEngine;

/// <summary>
/// Установка части формы.
/// </summary>
public class FormPartsSetuper : MonoBehaviour
{
	[SerializeField]
	Color[] _colors = new Color[8];
	/// <summary>
	/// Цвета частей формы.
	/// </summary>
	public static Color[] colors { get; private set; }

	void Awake()
	{
		colors = _colors;
		Destroy(this);
	}

	/// <summary>
	/// Установить части формы.
	/// </summary>
	/// <param name="form">Объект формы.</param>
	public static void setupFormParts(GameObject form)
	{
		if (colors == null) return;

		Debug.Log($"[FormPartsSetuper] Настройка частей формы {form.name}");

		Transform formTransform = form.transform;

		for (int i = formTransform.childCount - 1; i >= 0; i--)
		{
			var part = formTransform.GetChild(i).GetComponent<PartColorSetuper>();
			part.setPartColor(colors[i]);

			Debug.Log($"[FormPartsSetuper] Часть {part.name} окрашена в цвет.");
		}
	}
}
