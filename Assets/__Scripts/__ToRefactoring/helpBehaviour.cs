using UnityEngine;

	/// <summary>
	/// Вспомогательный класс, содержащий используемые во многих скриптах функции
	/// </summary>
public sealed class helpBehaviour : MonoBehaviour
{
	//protected IEnumerator deactivatePanel(GameObject panel)
	//{
	//	panel.GetComponent<Animator>().SetBool("isHidden", true);

	//	yield return new WaitForSeconds(panel.GetComponent<Animation>().clip.length / 2);

	//	Deactivate(panel); //отключаем панель
	//}

	//Dictionary<string, GameManager.Language> Languages = new Dictionary<string, GameManager.Language>
	//{
	//	["Russian"] = GameManager.Language.Russian,
	//	["English"] = GameManager.Language.English
	//};
	///// <summary>
	///// Приведение переменной типа string в переменную типа GameManager.Language
	///// </summary>
	//protected GameManager.Language Language(string key)
	//{
	//	GameManager.Language l;
	//	Languages.TryGetValue(key, out l);

	//	return l;
	//}

	//Dictionary<string, GameManager.Controll> Controlls = new Dictionary<string, GameManager.Controll>
	//{
	//	["Left_Right"] = GameManager.Controll.Left_Right,
	//	["Part_Selection"] = GameManager.Controll.Part_Selection,
	//	["Swipe"] = GameManager.Controll.Swipe
	//};
	///// <summary>
	///// Приведение переменной типа string в переменную типа GameManager.Controll
	///// </summary>
	//protected GameManager.Controll Controll(string key)
	//{
	//	GameManager.Controll l;
	//	Controlls.TryGetValue(key, out l);

	//	return l;
	//}

	//Dictionary<string, GameManager.GameMode> GameModes = new Dictionary<string, GameManager.GameMode>
	//{
	//	["Infinite"] = GameManager.GameMode.Infinite,
	//	["Hardcore"] = GameManager.GameMode.Hardcore,
	//	["Levels"] = GameManager.GameMode.Levels
	//};

	/// <summary>
	/// Приведение переменной типа string в переменную типа GameManager.Language
	/// </summary>
	//protected GameManager.GameMode GameMode(string key)
	//{
	//	GameManager.GameMode l;
	//	GameModes.TryGetValue(key, out l);

	//	return l;
	//}

	/// <summary>
	/// Приведение переменной типа string в переменную типа bool
	/// </summary>
	//public bool string_TO_bool(string s)
	//{
	//	if (s == true.ToString()) return true;
	//	return false;
	//}

	/// <summary>
	/// Приведение переменной типа string в переменную типа int
	/// </summary>
	//public int string_TO_int(string s)
	//{
	//	return int.Parse(s);
	//}

	/// <summary>
	/// Приведение массива типа string в массив типа int
	/// </summary>
	//public void stringArray_TO_intArray(int[] int_array, string[] string_array)
	//{
	//	for (int i = 0; i < int_array.Length; i++) int_array[i] = string_TO_int(string_array[i]);
	//}

	/// <summary>
	/// Приведение массива типа int в переменную типа string
	/// </summary>
	//protected string intArray_TO_string(int[] int_array)
	//{
	//	string s = "";
	//	for (int i = 0; i < int_array.Length; i++)
	//	{
	//		s += int_array[i].ToString();
	//		if (i == int_array.Length - 1) break;
	//		s += ':';
	//	}

	//	return s;
	//}

	/// <summary>
	/// Удаление слушателей на Toggles
	/// </summary>
	//protected void RemoveListeners(Toggle[] toggles)
	//{
	//	foreach(Toggle t in toggles)
	//	{
	//		t.onValueChanged.RemoveAllListeners();
	//	}
	//}

	/// <summary>
	/// Добавление слушателя на галочку языка
	/// /// </summary>
	//protected void Language_AddListener(Toggle toggle, GameManager.Language language)
	//{
	//	toggle.onValueChanged.AddListener (delegate { LANGUAGE_changed(language); });
	//}

	/// <summary>
	/// Добавление слушателя на галочку управления
	/// /// </summary>
	//protected void Controll_AddListener(Toggle toggle, Toggle inverseToggle, GameManager.Controll controll)
	//{
	//	toggle.onValueChanged.AddListener (delegate { CONTROLTYPE_changed(inverseToggle, controll); });
	//}

	/// <summary>
	/// Добавление слушателя на галочки звука, музыки и инверсии
	/// /// </summary>
	//protected void Other_AddListeners(Toggle soundToggle, Toggle musicToggle, Toggle inverseToggle)
	//{
	//	soundToggle.onValueChanged.AddListener (delegate { SOUND_changed(soundToggle.isOn); });
	//	musicToggle.onValueChanged.AddListener(delegate { MUSIC_changed(musicToggle.isOn); });
	//	inverseToggle.onValueChanged.AddListener(delegate { INVERSE_changed(inverseToggle.isOn); });
	//}


	////функция слушателя галочки языков
	//protected void LANGUAGE_changed(GameManager.Language language)
	//{
	//	//перевод в соответствии с установленным языком
	//	LocalizationManager.Language = language.ToString();
	//}

	////функция слушателя галочки типов управлений
	//protected void CONTROLTYPE_changed(Toggle toggle, GameManager.Controll controller)
	//{
	//	playClick();
	//	gm.controller = controller;
	//	//gm.sn.SettingsSerialisation("controller", gm.controller);

	//	if (controller == GameManager.Controll.Part_Selection)
	//	{
	//		toggle.interactable = false;
	//		INVERSE_changed(false);
	//		toggle.isOn = false;
	//	}
	//	else toggle.interactable = true;
	//}
}
