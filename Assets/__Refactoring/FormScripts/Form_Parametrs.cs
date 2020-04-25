using UnityEngine;

/*

	ХРАНИТ ВСЕ ЛОКАЛЬНЫЕ ПАРАМЕТРЫ ЗА ОДНУ ИГРУ
		СЧЕТЧИКИ
		ПРЕФАБЫ ФОРМЫ
		УРОВЕНЬ

 */

public class Form_Parametrs : MonoBehaviour
{
	//объект формы
	public GameObject form { get; set; } 

	[Space]

	[Header("Формы")]
	public GameObject[] Forms = new GameObject[6];

	[Header("Уровень формы")]
	public int formLVL; //уровень формы (от 0 до 5)

	[Header("Цвета частей формы")]
	public Color[] partColors = new Color[8];


	[HideInInspector]
	public int[] colorCounters = new int[8]; //цветные счетчики в конкретной игре
											  //i-тый элемент соответствует i-тому цвету в partColors
}
