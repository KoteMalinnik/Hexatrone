using UnityEngine;
using System.IO;
using System.Xml;
using UnityEditor;

/// <summary>
/// Отвечает за сохранение и загрузку данных
/// </summary>
public class Serialisation : helpBehaviour
{
	
	[SerializeField]
	string fileName = "settings";
	string path;

	[Space]

	public string settingsNode = "SETTINGS";

	[Header("Имена переменных и начальные значения")]

	public string Controller = "Controller";
	[SerializeField]
	GameManager.Controll _Controller = GameManager.Controll.Part_Selection;

	[Space]

	public string strLanguage = "Language";
	[SerializeField]
	GameManager.Language _Language = GameManager.Language.English;

	[Space]

	public string Inverse = "Inverse";
	[SerializeField]
	bool _Inverse = true;

	[Space]
	public string QuitMessageToggle = "QuitMessageToggle";
	[SerializeField]
	bool _QuitMessageToggle = true;

	[Space]
	public string Music = "Music";
	[SerializeField]
	bool _Music = true;

	[Space]
	public string Sound = "Sound";
	[SerializeField]
	bool _Sound = true;

	[Space]
	public string level = "Level";
	[SerializeField]
	int _level = 0;

	void Awake()
	{
		gm = get_GameManager();

		path = Application.persistentDataPath + "/" + fileName + ".xml";
	}

	public void SaveParametr (string element_key, string parametr)
	{
		var xmlDoc = new XmlDocument();
		XmlNode rootNode = null;

		if(!File.Exists(path))
		{
			rootNode = xmlDoc.CreateElement(settingsNode);
			xmlDoc.AppendChild(rootNode);
		}
		else
		{
			xmlDoc.Load(path);
			rootNode = xmlDoc.DocumentElement;
		}

		XmlElement elmNew = xmlDoc.CreateElement(element_key);
		XmlAttribute value = xmlDoc.CreateAttribute("value");
		value.Value = parametr;
		elmNew.SetAttributeNode(value);

		foreach (XmlNode node in rootNode.ChildNodes)
		{
			if(node.Name==element_key)
			{
				rootNode.RemoveChild(node);
				break;
			}
		}

		//Debug.Log("Saved: " + rootNode.Name + ". " + element_key + ". Value = " + value.Value);

		rootNode.AppendChild(elmNew);
		xmlDoc.Save(path);
	}

	void CreateDefaultSettings()
	{
		//Debug.Log("<color=blue>Creating default parametrs...</color>");

		SaveParametr(Controller, _Controller.ToString());
		SaveParametr(strLanguage, _Language.ToString());
		SaveParametr(Inverse, _Inverse.ToString());
		SaveParametr(QuitMessageToggle, _QuitMessageToggle.ToString());
		SaveParametr(Music, _Music.ToString());
		SaveParametr(Sound, _Sound.ToString());
		SaveParametr(level, _level.ToString());
	}

	public void LoadSettings ()
	{
		if (!File.Exists(path))
		{
			CreateDefaultSettings();
		}

		try
		{
			var xmlDoc = new XmlDocument();
			XmlNode rootNode = null;

			xmlDoc.Load(path);

			rootNode = xmlDoc.DocumentElement;

			gm.controller = Controll(LoadElement(rootNode, Controller));
			gm.language = Language(LoadElement(rootNode, strLanguage));
			gm.inverse = string_TO_bool(LoadElement(rootNode, Inverse));
			gm.QuitMessageToggle = string_TO_bool(LoadElement(rootNode, QuitMessageToggle));
			gm.isMusicOn = string_TO_bool(LoadElement(rootNode, Music));
			gm.isSoundOn = string_TO_bool(LoadElement(rootNode, Sound));
			gm.level = string_TO_int(LoadElement(rootNode, level));
		}
		catch (System.Exception)
		{
			Debug.Log("<color=red>Ошибка чтения файла!</color>");
		}
	}

	string LoadElement(XmlNode nodeTitle, string element_key)
	{
		string s = "";
		
		foreach (XmlNode node in nodeTitle.ChildNodes) if (node.Name == element_key) s = node.Attributes[0].Value;

		//Debug.Log("Loaded: " + element_key + ". Value = " + s);
		return s;
	}

	void OnApplicationQuit()
	{
		SaveParametr(Controller, gm.controller.ToString());
		SaveParametr(strLanguage, gm.language.ToString());
		SaveParametr(Inverse, gm.inverse.ToString());
		SaveParametr(QuitMessageToggle, gm.QuitMessageToggle.ToString());
		SaveParametr(Music, gm.isMusicOn.ToString());
		SaveParametr(Sound, gm.isSoundOn.ToString());
		SaveParametr(level, gm.level.ToString());
	}
}
