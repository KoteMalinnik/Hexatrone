using System.Collections;
using UnityEngine;

/*

	ОТВЕЧАЕТ ЗА СПАВН СФЕР ORB
	ЗАПСКАЕТ СФЕРЫ С ПЕРИОДОМ Т И СКОРОСТЬЮ SPEED
	ИЗМЕНЯЕТ ЦВЕТ И СВОЙСТВА СФЕРЫ
	УСТАНАВЛИВАЕТ СПРАЙТ СФЕРЫ В ЗАВИСИМОСТИ ОТ ЕЕ ТИПА

 */

public class Orb_Spawner : helpBehaviour
{
	public static Orb_Spawner instance { get; private set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

		gm = GameManager.instance;
		gm._orbSpawner = instance;
	}

	//Префаб сферы
	public GameObject Orb_prefab;
	public GameObject pulledOrb { get; set; } = null;

	[HideInInspector]
	public GameObject[] Orb_queue = new GameObject[3];//очередь сфер

	public int orbsSpeed { get; set; } = 6;

	[Space]
	public Sprite[] countBaf_Sprites; // Спрайты сфер количества
	public Sprite[] lvlBaf_Sprites; //Спрайты сфер уровня
	public Sprite criticalBaf_Sprite; //Спрайт сферы критической
	public Sprite usual_Sprite; //Спрайт обычной сферы


	void Start()
	{
		InstansiateOrbs(); //Создаем сферы
		if (gm.gamemode == GameManager.GameMode.Hardcore) orbsSpeed = 7;
		enabled = false;
	}

	public void firstEnable()
	{
		StartCoroutine(PullingOrbs()); //Запускаем корутину выпуска сфер
	}

		//Инициализация и размещение сфер
	void InstansiateOrbs()
	{
		for (int i = 0; i < Orb_queue.Length; i++)
		{
				//создаем сферу по префабу
			GameObject orb = Instantiate(Orb_prefab);
				//помещаем сферу в transform OrbSpawner
			orb.transform.parent = transform;

			Deactivate(orb);
				//заносим в очередь
			Orb_queue[i] = orb; 
		}
	}

		//выпуск сфер по очереди
	IEnumerator PullingOrbs()
	{
		int i = 0; //счетчик
		while (true)
		{
			yield return new WaitUntil(() => !PauseMenuManager.isPause); //ожидание,  если стоит на паузе

			//делаем активной сферу
			Activate(Orb_queue[i]);
			ReloadOrb(Orb_queue[i]);
			pulledOrb = Orb_queue[i];
			get_OrbObject(Orb_queue[i]).pull_Orb(orbsSpeed, gm._formController.gameObject.transform.position);
			i++;
			if (i == Orb_queue.Length) i = 0;

			yield return new WaitUntil(() => pulledOrb == null); //ожидания столкновения
		}
	}

		//Переподготовка использованной сферы
		//obj - объект сферы, которую необходимо заново засунуть в очередь
	public void ReloadOrb(GameObject obj) 
	{
			//перемещаем на новую позицию
		obj.transform.position = new Vector3(UnityEngine.Random.Range(-3, 3), 6, 0);
			
		if(gm.gamemode == GameManager.GameMode.Hardcore)
		{
			//обычный тип сферы
			get_OrbObject(obj).type = Orb_object.OrbType.Usual;
			setSprite(Orb_object.OrbType.Usual, get_OrbObject(obj) , get_SpriteRenderer(obj));
		}
		else
		{
			//устанавливаем тип сферы
			changeOrbType(get_OrbObject(obj));
		}
	}

		//устанавливаем тип сферы и параметры
	void changeOrbType(Orb_object orb)
	{
		//шанс выпадения бафа
		float UnusualChance = UnityEngine.Random.Range(0, 1.0f);
			//если вероятность выпадения бафа необходимая, то делаем нужный баф
		if (UnusualChance > 0.95) 
		{
			if (UnusualChance < 0.97) orb.type = Orb_object.OrbType.Count_Baf;
			else if (UnusualChance < 0.99 && gm._formParametrs.CriticalOrbsCounter != gm._formParametrs.CriticalOrbsCount) orb.type = Orb_object.OrbType.Critical;
			else orb.type = Orb_object.OrbType.LVL_Baf;
		}
			//иначе обычная сфера
		else orb.type = Orb_object.OrbType.Usual;

		setSprite(orb.type, orb, get_SpriteRenderer(orb.gameObject));
	}

		//устанавливаем спрайт, соответствующий типу сферы
	void setSprite(Orb_object.OrbType type, Orb_object orb, SpriteRenderer sr)
	{
		switch (type)
		{
			case Orb_object.OrbType.Usual:
				{
						//Устанавливаем спрайт обычной сферы
					sr.sprite = usual_Sprite;
						//переопределяем цвет
					sr.color = gm._formParametrs.partColors[UnityEngine.Random.Range(0, gm._formParametrs.formLVL + 3)];
					//устанавливаем размер сферы
					orb.transform.localScale = new Vector3(0.3f, 0.3f, 1);
					break;
				}
			case Orb_object.OrbType.Count_Baf:
				{
						//Устанавливаем рандомное число в свойство количества Count_Baf_Property
						// От 2 до <количество_спрайтов>+1
					orb.Count_Baf_value = UnityEngine.Random.Range(2, countBaf_Sprites.Length + 1);
						//Устанавливаем спрайт, соответствующий свойству количества Count_Baf_Property
						// От 0 до <количество_спрайтов>-1
					sr.sprite = countBaf_Sprites[orb.Count_Baf_value - 2];
						//переопределяем цвет
					sr.color = gm._formParametrs.partColors[UnityEngine.Random.Range(0, gm._formParametrs.formLVL + 3)];
					//устанавливаем размер сферы
					orb.transform.localScale = new Vector3(0.5f, 0.5f, 1);
					break;
				}
			case Orb_object.OrbType.LVL_Baf:
				{
						// Устанавливаем рандомное число в свойство уровня LVL_Baf_Property
						// От 0 до 5 (до максимума formLVL)
						// Перевыбираем, если выпал текущий уровень
					orb.LVL_Baf_value = UnityEngine.Random.Range(0, lvlBaf_Sprites.Length - 1);
					if (orb.LVL_Baf_value == gm._formParametrs.formLVL)
					{
						changeOrbType(orb);
						break;
					}
						//Устанавливаем спрайт, соответствующий свойству уровня LVL_Baf_Property
						// От 0 до 5 (до максимума formLVL)
					sr.sprite = lvlBaf_Sprites[orb.LVL_Baf_value];
						//переопределяем цвет
					sr.color = gm._formParametrs.partColors[UnityEngine.Random.Range(0, gm._formParametrs.formLVL + 3)];
					//устанавливаем размер сферы
					orb.transform.localScale = new Vector3(0.5f, 0.5f, 1);
					break;
				}
			case Orb_object.OrbType.Critical:
				{
					//Устанавливаем спрайт обычной сферы
					sr.sprite = criticalBaf_Sprite;
					//переопределяем цвет
					sr.color = gm._formParametrs.partColors[UnityEngine.Random.Range(0, gm._formParametrs.formLVL + 3)];
					//устанавливаем размер сферы
					orb.transform.localScale = new Vector3(0.5f, 0.5f, 1);
					break;
				}
		}

		//Если была проблема с определением цвета при изменении уровня, то выставляем по умолчанию всегда присутствующий цвет
		if (sr.color == Color.white) sr.color = gm._formParametrs.partColors[0];
	}
}