using UnityEngine;
using UnityEditor;

public class Debuger : EditorWindow
{
	[MenuItem("Window/_Debuger")]
	public static void showDebuger()
	{
		Debug.Log("[Debuger] Окно дебагера открыто.");
		Debuger window = GetWindow<Debuger>(false, "Debuger", true);
	}

	void OnGUI()
	{
		GUILayout.Box("Игровые настройки");
		GUILayout.Space(10);

		DisplayAudioManagersData();
		DisplayLevelData();
		DisplayCountersData();
	}

	void DisplayLevelData()
	{
		GUILayout.Box("Уровень формы");
		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		if (GUILayout.Button("+", GUILayout.Width(20))) FormLevel.levelUpEvent();
		if (GUILayout.Button("0", GUILayout.Width(20))) FormLevel.setLevel(0);
		if (GUILayout.Button("-", GUILayout.Width(20))) FormLevel.levelDownEvent();
		GUILayout.Label(FormLevel.level.ToString(), GUILayout.MaxWidth(40));
		GUILayout.EndHorizontal();

		GUILayout.Space(10);
	}

	void DisplayCountersData()
	{
		GUILayout.Box("Счетчики количества сфер");
		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		GUILayout.Label($"Общ.", GUILayout.Width(40));
		if (GUILayout.Button("+", GUILayout.Width(20))) CounterTotalOrbs.incrementValue();
		if (GUILayout.Button("0", GUILayout.Width(20))) CounterTotalOrbs.setValue(0);
		if (GUILayout.Button("-", GUILayout.Width(20))) CounterTotalOrbs.decrementValue();
		GUILayout.Label(CounterTotalOrbs.value.ToString(), GUILayout.MaxWidth(40));
		GUILayout.EndHorizontal();

		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		GUILayout.Label($"Тек.", GUILayout.Width(40));
		if (GUILayout.Button("+", GUILayout.Width(20))) CounterOrbsAtFormLevel.incrementValue();
		if (GUILayout.Button("0", GUILayout.Width(20))) CounterOrbsAtFormLevel.setValue(0);
		if (GUILayout.Button("-", GUILayout.Width(20))) CounterOrbsAtFormLevel.decrementValue();
		GUILayout.Label($"{CounterOrbsAtFormLevel.value}/{CounterOrbsAtFormLevel.valueToLevelUp}", GUILayout.MaxWidth(40));
		GUILayout.EndHorizontal();

		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		GUILayout.Label($"Крит.", GUILayout.Width(40));
		if (GUILayout.Button("+", GUILayout.Width(20))) CounterCriticalOrbs.incrementValue();
		if (GUILayout.Button("0", GUILayout.Width(20))) CounterCriticalOrbs.setValue(0);
		if (GUILayout.Button("-", GUILayout.Width(20))) CounterCriticalOrbs.decrementValue();
		GUILayout.Label($"{CounterCriticalOrbs.value}/5", GUILayout.MaxWidth(40));
		GUILayout.EndHorizontal();

		GUILayout.Space(10);
	}

	void DisplayAudioManagersData()
	{
		GUILayout.Box("Менеджеры аудио");

		_diplayAudioManager(MusicManager.instance, "музыки");
		_diplayAudioManager(SoundManager.instance, "звука");

		GUILayout.Space(10);
	}

	void _diplayAudioManager(AudioManager manager, string managerName)
	{
		GUILayout.Space(5);

		if (manager != null)
		{
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("On", GUILayout.Width(30))) manager.setAudioState(true);
			if (GUILayout.Button("Off", GUILayout.Width(30))) manager.setAudioState(false);
			GUILayout.Label("Состояние: " + (manager.allowAudio ? "On" : "Off"));
			GUILayout.EndHorizontal();
		}
		else GUILayout.Label($"Менеджер {managerName} отсутствует!");
	}
}
