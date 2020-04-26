using UnityEngine;

public class FormPartsSetuper : MonoBehaviour
{
	[SerializeField]
	Color[] _colors = new Color[8];
	static Color[] colors;

	void Awake()
	{
		colors = _colors;
		Destroy(this);
	}

	public static void setupFormParts(GameObject form)
	{
		if (colors == null) return;

		Debug.Log($"[FormPartsSetuper] Настройка частей формы {form.name}");

		Transform formTransform = form.transform;

		for (int i = formTransform.childCount - 1; i >= 0; i--)
		{
			var part = formTransform.GetChild(i).GetComponent<PartController>();
			part.setPartColor(colors[i]);

			Debug.Log($"[FormPartsSetuper] Часть {part.name} окрашена в цвет.");
		}
	}
}
