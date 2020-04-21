using System.Collections;
using UnityEngine;

/// <summary>
/// ОБРАБАТЫВАЕТ СТОЛКНОВЕНИЯ СФЕРЫ И ЧАСТИ
/// ОТСЫЛАЕТ НОВЫЕ В FORM_PARAMETRS
///	ВЫЗЫВАЕТ ОБНОВЛЕНИЕ СЧЕТЧИКОВ НА КАНВАСЕ
///	ВЫСЫЛАЕТ ЗАПРОС НА ИЗМЕНЕНИЕ УРОВЕНЯ, ЕСЛИ ТРЕБУЕТСЯ
/// </summary>
public class Form_Processing_Orbs : helpBehaviour
{
	public static Form_Processing_Orbs instance { get; private set; }
	void Awake()
	{
		if (instance == null) instance = this;
		else if (instance == this) Destroy(gameObject);

		gm = GameManager.instance;
		gm._formProcessingOrbs = instance;
	}

	//обработка столкновения сферы и формы

	struct Orb_to_process //сфера, которая обрабатываются при коллизии
	{
		public Color partColor;
		public SpriteRenderer partSR;
		public Color orbColor;
		public GameObject orb;
		public Orb_object.OrbType type;
	}

	Orb_to_process[] otp = new Orb_to_process[2]; //максимум 2 коллизии за кадр
	Coroutine DoubleOrbCoroutine; //корутин обработки

	//OrbColor - цвет сферы, PartColor - цвет Part-а, Orb - обробатываемая сфера
	public void DoubleTouch(Color OrbColor, Color PartColor, GameObject Orb, Orb_object.OrbType OrbType, SpriteRenderer PartSpriteRenderer)
	{
		//если обрабатывается одна и та же сфера (вторая коллизия)
		if (Orb == otp[0].orb && otp[0].orb != null)
		{
			otp[1].partColor = PartColor;
			otp[1].partSR = PartSpriteRenderer;
			otp[1].orb = Orb;
			otp[1].orbColor = OrbColor;
			otp[1].type = OrbType;
		}
		else //если только первая сфера попалась
		{
			otp[0].partColor = PartColor;
			otp[0].partSR = PartSpriteRenderer;
			otp[0].orb = Orb;
			otp[0].orbColor = OrbColor;
			otp[0].type = OrbType;

			//запускаем корутин обработки
			if (DoubleOrbCoroutine == null) DoubleOrbCoroutine = StartCoroutine(LastUpdate_Coroutine());
		}
	}

	//Функция определения типа сферы и рассчет счетчиков
	//sign = true, if "+", else "-"
	public Coroutine partAnimationCoroutine { get; set;}
	void defOrbType(Orb_to_process orb, bool sign)
	{
		switch (orb.type)
		{
			case Orb_object.OrbType.Usual:
				{
					//Если обычная сфера, то добавляем 1 к счетчику, иначе вычитаем
					if (sign)
					{ 
						ColorCountersProcessing(orb.partColor, 1);
						//звук правильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.rightOrbSound);
						//белая анимация части
							partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.rightOrbColor));
					}
					else
					{
						gm._formParametrs.CriticalOrbsCounter--;
						//звук неправильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.wrongOrbSound);
						//черная анимация части
							partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.wrongOrbColor));
					}
					break;
				}
			case Orb_object.OrbType.Count_Baf:
				{
						//Если сфера количества, то добавляем или вычитаем количество
					if (sign) 
					{
						gm._stats.collectedBafsCount++;

						ColorCountersProcessing(orb.partColor, get_OrbObject(orb.orb).Count_Baf_value);
						//звук правильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.bafSound);
						//белая анимация части
							partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.rightOrbColor));
					}
					else
					{
						gm._formParametrs.CriticalOrbsCounter -= get_OrbObject(orb.orb).Count_Baf_value;
						//звук неправильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.wrongOrbSound);
						//черная анимация части
							partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.wrongOrbColor));
					} 
					break;
				}
			case Orb_object.OrbType.LVL_Baf:
				{
					gm._stats.collectedBafsCount++;
					//Если сфера уровня, то добавляем 1 к счетчику, иначе вычитаем
					//И устанавливаем новый уровень
					if (sign)
					{
						//добавляем в цветной счетчик
						ColorCountersProcessing(orb.partColor, 1);

						//звук уровня
						//если повышается уровень
						if (gm._formParametrs.formLVL < get_OrbObject(orb.orb).LVL_Baf_value)
							gm._formAudioManager.playSound(gm._formAudioManager.lvlUpSound);
						//если понижается уровнеь
						else gm._formAudioManager.playSound(gm._formAudioManager.lvlDownSound);

						//устанавливаем уровень сферы
						gm._formParametrs.formLVL = get_OrbObject(orb.orb).LVL_Baf_value;

						Deactivate(orb.orb);
						//зачищаем элемент первой коллизии
						orb.orb = null;
						//отключаем корутин
						DoubleOrbCoroutine = null;

						//Запускаем корутину смены уровня
						StartCoroutine(gm._formController.InstansiateForm());
					}
					else
					{
						gm._formParametrs.CriticalOrbsCounter--;
						//звук неправильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.wrongOrbSound);
						//черная анимация части
							partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.wrongOrbColor));
					}
					break;
				}
			case Orb_object.OrbType.Critical:
				{
					//Если обычная сфера, то добавляем 1 к счетчику, иначе вычитаем
					if (sign)
					{
						gm._stats.collectedBafsCount++;

						gm._formParametrs.CriticalOrbsCounter++;
						ColorCountersProcessing(orb.partColor, 1);
						//звук правильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.bafSound);
						//белая анимация части
						partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.rightOrbColor));
					}
					else
					{
						gm._formParametrs.CriticalOrbsCounter--;
						//звук неправильной сферы
						gm._formAudioManager.playSound(gm._formAudioManager.wrongOrbSound);
						//черная анимация части
						partAnimationCoroutine = StartCoroutine(gm._formAnimations.partAnimation(orb.partSR, orb.partSR.color, gm._formParametrs.wrongOrbColor));
					}

					break;
				}
		}
	}

	//Проверка на двойное столкновение
	IEnumerator LastUpdate_Coroutine()
	{
		yield return new WaitForEndOfFrame();

		//проверка коллизий
		if (otp[1].orb == null) //если коллизия единственная
		{
			//Словили правильную сферу
			if (otp[0].orbColor == otp[0].partColor) defOrbType(otp[0], true);
			else defOrbType(otp[0], false);
		}
		else 	//если две коллизии (на стыке), то выбираем выигрышный вариант
		{ 
			if (otp[0].orbColor == otp[0].partColor) defOrbType(otp[0], true);	
			else if(otp[1].orbColor == otp[1].partColor) defOrbType(otp[1], true);
			else defOrbType(otp[0], false);

			//зачищаем элемент второй коллизии
			otp[1].orb = null;
		}
		Deactivate(otp[0].orb);

		//зачищаем элемент первой коллизии
		otp[0].orb = null;
		DoubleOrbCoroutine = null; //отключаем корутин

		yield return new WaitWhile(() => partAnimationCoroutine != null);

		if (gm._formParametrs.CurrentOrbCounter > gm._formParametrs.OrbsToNextLvlCount || gm._formParametrs.CriticalOrbsCounter < 0) levelCounterProcessing();
		gm._canvasManager.updateCounters();

		yield return null;
	}

	//Обработка цветных счетчиков
	//Они только накапливают и ничего не теряют
	void ColorCountersProcessing(Color counterColor, int delta) //counterColor - цвет нужного счетчика
	{
		for (int i = 0; i < gm._formParametrs.partColors.Length; i++)
		{
			if (gm._formParametrs.partColors[i] == counterColor)
			{
				gm._formParametrs.colorCounters[i] +=delta;
				break;
			}
		}
		gm._formParametrs.TotalOrbsCounter += delta;
		gm._formParametrs.CurrentOrbCounter += delta;
	}

	//обработка счетчика текущего уровня формы
	//использует CurrentCounter, CriticalOrbsCount и OrbsCountToNextLVL
	void levelCounterProcessing()
	{
		//проверка на изменение уровня
		if (gm._formParametrs.CurrentOrbCounter > gm._formParametrs.OrbsToNextLvlCount && gm._formParametrs.formLVL < 5) //повышение уровня, если не максимальный уровень
		{
			gm._formParametrs.formLVL++; //повышение уровня
			gm._formParametrs.OrbsToNextLvlCount = 10*(gm._formParametrs.formLVL*2+1) ; //увеличение количества сфер до следующего уровня
			gm._formAudioManager.playSound(gm._formAudioManager.lvlUpSound); //звук повышения уровня

			if (gm._formParametrs.formLVL == 3) gm._orbSpawner.orbsSpeed++;
			else if (gm._formParametrs.formLVL == 5) gm._orbSpawner.orbsSpeed++;
		}
		else if (gm._formParametrs.CriticalOrbsCounter < 0 && gm._formParametrs.formLVL > 0 && gm.gamemode != GameManager.GameMode.Hardcore)
			//понижение уровня, если не минималный уровень. ПРоигрышь, если это хардкор
		{
			gm._formParametrs.formLVL--; //понижение уровня
			gm._formParametrs.OrbsToNextLvlCount = 10 * (gm._formParametrs.formLVL * 2 + 1); //уменьшение количества сфер до следующего уровня
			gm._formAudioManager.playSound(gm._formAudioManager.lvlDownSound); //звук понижения уровня

			if (gm._formParametrs.formLVL == 2) gm._orbSpawner.orbsSpeed--;
			else if (gm._formParametrs.formLVL == 4) gm._orbSpawner.orbsSpeed--;
		}
		else
		{
			// if(gm.isSoundOn) Handheld.Vibrate();
			PauseMenuManager.isPause = false;
			gm._formAudioManager.playSound(gm._formAudioManager.gameOverSound);
			gm._stats.ShowStatsPanel();
		}
		StartCoroutine(gm._formController.InstansiateForm());
	}
}
