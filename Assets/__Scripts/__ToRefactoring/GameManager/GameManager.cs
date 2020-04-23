using UnityEngine;
using Assets.SimpleLocalization;

/// <summary>
/// Содержит ссылки на менеджеры и основные переменные
/// </summary>
public class GameManager : MonoBehaviour
{
	//перечисление управления
	public enum Controll
	{
		Left_Right,
		Part_Selection,
		Swipe
	}
	public Controll controller;
	//инверсия управления LEFT-RIGHT и SWIPE. true, ЕСЛИ ИНВЕРСИЯ. false, Если нет инверсии
	public bool inverse { get; set; }

	//перечисление языков
	public enum Language 
	{
		Russian,
		English
	}
	public Language language { get; set; }

	//Режимы игры
	public enum GameMode
	{
		Infinite, // бесконечный
		Hardcore, // хардкор
		Levels // уровнями
	}
	public GameMode gamemode { get; set;}

	public bool QuitMessageToggle { get; set; } //галочка для скрытия сообщения о выходе

	public int level { get; set; }

	void Start()
	{
		//ЛОКАЛИЗАЦИЯ
		//инициализация словаря
		LocalizationManager.Read();
		//перевод в соответствии с установленным языком
		LocalizationManager.Language = language.ToString();

		//Устанавливаем стандартный режим
		gamemode = GameMode.Infinite;
	}
}
