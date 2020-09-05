using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Управление GUI игровой информации.
/// </summary>
public class GameInfoViewer : MonoBehaviour
{
	public static GameInfoViewer instance = null;
	void Awake()
	{
		instance = this;
	}

	[Header("GUI Sliders")]

	[SerializeField]
	Slider sliderOrbsAtFormLevel = null;
	static Image imageFillRect_sliderOrbsAtFormLevel = null;

	[SerializeField]
	Slider sliderCriticalOrbs = null;
	static Image imageFillRect_sliderCriticalOrbs = null;


	[Header("GUI Texts")]

	[SerializeField]
	Text textLevel = null;

	[SerializeField]
	Text textTotalOrbs = null;

	void Start()
	{
		//imageFillRect_sliderOrbsAtFormLevel = sliderOrbsAtFormLevel.fillRect.GetComponent<Image>();
		//imageFillRect_sliderCriticalOrbs = sliderCriticalOrbs.fillRect.GetComponent<Image>();

		//sliderCriticalOrbs.maxValue = 5;

		//updateLevelGUI(FormLevelController.level);
	}

	/// <summary>
	/// Обновить элементы GUI, отвечающие за отображение значений при совпадении цветов.
	/// </summary>
	public static void updateMatchGUI()
	{
		//if (instance == null) return;

		//instance.sliderOrbsAtFormLevel.value = CounterOrbsAtFormLevel.value;
		//instance.textTotalOrbs.text = CounterTotalOrbs.value.ToString();
		//instance.sliderCriticalOrbs.value = CounterCriticalOrbs.value;
	}

	/// <summary>
	/// Обновить элементы GUI, отвечающие за отображение значений при несовпадении цветов.
	/// </summary>
	public static void updateMismatchGUI()
	{
		//if (instance == null) return;

		//instance.sliderCriticalOrbs.value = CounterCriticalOrbs.value;
	}

	/// <summary>
	/// Обновить элементы GUI, отвечающие за отображение значений при изменении уровня.
	/// </summary>
	public static void updateLevelGUI(int formLevel)
	{
		//if (instance == null) return;

		//instance.textLevel.text = formLevel.ToString();
		//Обновление счетчиков
		//updateMatchGUI();
		//updateMismatchGUI();

		//если уровень формы равен 5, то надо скрыть слайдер прогресса
		//if (formLevel >= 5)
		//{
		//	instance.sliderOrbsAtFormLevel.gameObject.SetActive(false);
		//	return;
		//}

		//если уровень формы меньше 5 и слайдер прогресса скрыт, то показать его
		//if (formLevel < 5)
		//	if (!instance.sliderOrbsAtFormLevel.gameObject.activeInHierarchy)
		//		instance.sliderOrbsAtFormLevel.gameObject.SetActive(true);

		//обновляем максимальные значения слайдеров, чтобы не рассчитывать лишний раз какую часть добавить
		//instance.sliderOrbsAtFormLevel.maxValue = CounterOrbsAtFormLevel.valueToLevelUp;

		//if (FormPartColorazing.colors == null) return;

		//изменяем цвета слайдеров
		//sliderOrbsAtFormLevel - цвет следующей части
		//imageFillRect_sliderOrbsAtFormLevel.color = FormPartColorazing.colors[formLevel + 3];

		//sliderCriticalOrbs - цвет текущего последнего элемента
		//imageFillRect_sliderCriticalOrbs.color = formLevel > 0 ? FormPartColorazing.colors[formLevel + 2] : Color.gray;
	}
}
