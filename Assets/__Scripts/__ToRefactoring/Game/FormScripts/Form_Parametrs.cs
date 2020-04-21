using UnityEngine;

/*

	ХРАНИТ ВСЕ ЛОКАЛЬНЫЕ ПАРАМЕТРЫ ЗА ОДНУ ИГРУ
		СЧЕТЧИКИ
		СКОРОСТЬ ВРАЩЕНИЯ ФОРМЫ
		ПРЕФАБЫ ФОРМЫ
		УРОВЕНЬ

 */

public class Form_Parametrs : helpBehaviour
{
	public static Form_Parametrs instance { get; private set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

		gm = GameManager.instance;
		gm._formParametrs = instance;
	}

	//счетчик количества собранных сфер на данном уровне сферы в конкретной игре
	public int CurrentOrbCounter { get; set; }
	//количество сфер до нового уровня
	public int OrbsToNextLvlCount { get; set; }
	//количество сфер до падения уровня
	public int CriticalOrbsCount;
	//счетчик количества сфер до падения уровня
	public int CriticalOrbsCounter { get; set; }
	//счетчик количества всех собранных сфер на уровне
	public int TotalOrbsCounter { get; set; }

	//объект формы
	public GameObject form { get; set; } 

	[Space]

	[Header("Формы")]
	public GameObject[] Forms = new GameObject[6];

	[Header("Скорость вращения")]
	public float RotationSpeed = 10;

	[Header("Уровень формы")]
	public int formLVL; //уровень формы (от 0 до 5)

	[Header("Цвета частей формы")]
	public Color[] partColors = new Color[8];

	[Header("Цвета анимации частей")]
	public Color rightOrbColor; //цвет анимации части при правильной сфере
	public Color wrongOrbColor; //цвет анимации части при неправильной сфере
	public float partIntensity; //скорость анимации части

	[HideInInspector]
	public int[] colorCounters = new int[8]; //цветные счетчики в конкретной игре
											  //i-тый элемент соответствует i-тому цвету в partColors
	//корутин на вращение формы при новом уровне
	public Coroutine Coroutine_Rotate { get; set; }  
	//корутин на вращение формы при управлении PartSelection
	public Coroutine rotate_SelectedPart { get; set; }
}
