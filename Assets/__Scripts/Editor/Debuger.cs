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

	Vector2 scrollViewPosition = Vector2.zero;
	bool needSimulation = false;
	bool needAudioManagers = false;

	void OnGUI()
	{
		scrollViewPosition = GUILayout.BeginScrollView(scrollViewPosition);

		DisplayStatements();

		needAudioManagers = GUILayout.Toggle(needAudioManagers, "Отображать аудио менеджеры");
		if(needAudioManagers) DisplayAudioManagersData();

		needSimulation = GUILayout.Toggle(needSimulation, "Необходима симуляция обработки сферы");
		if (needSimulation) DisplayCounterProcessing();

		GUILayout.Space(10);

		DisplayLevelData();
		DisplayCountersData();

		GUILayout.EndScrollView();
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

	void DisplayCounterProcessing()
	{
		GUILayout.Box("Симуляция обработки при совпадении");
		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Basic")) _onColorMatch(1, OrbTypeDefiner.orbType.Basic);
		if (GUILayout.Button("Critical")) _onColorMatch(1, OrbTypeDefiner.orbType.CriticalBonus);
		if (GUILayout.Button("Delta")) _onColorMatch(Random.Range(0,5), OrbTypeDefiner.orbType.DeltaBonus);
		if (GUILayout.Button("LevelUp")) _onColorMatch(1, OrbTypeDefiner.orbType.LevelUpBonus);
		GUILayout.EndHorizontal();


		GUILayout.Box("Симуляция обработки при несовпадении");
		GUILayout.Space(5);

		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Basic")) _onColorMismatch(1, OrbTypeDefiner.orbType.Basic);
		if (GUILayout.Button("Critical")) _onColorMismatch(1, OrbTypeDefiner.orbType.CriticalBonus);
		if (GUILayout.Button("Delta")) _onColorMismatch(Random.Range(0, 5), OrbTypeDefiner.orbType.DeltaBonus);
		if (GUILayout.Button("LevelUp")) _onColorMismatch(1, OrbTypeDefiner.orbType.LevelUpBonus);
		GUILayout.EndHorizontal();

		GUILayout.Space(10);
	}

	void _onColorMatch(int delta, OrbTypeDefiner.orbType type)
	{
		var orb = new OrbObject(delta, type);
		CountersProcessing.OnColorMatch(orb);
	}

	void _onColorMismatch(int delta, OrbTypeDefiner.orbType type)
	{
		var orb = new OrbObject(delta, type);
		CountersProcessing.OnColorMismatch(orb);
	}

	void DisplayStatements()
	{
		GUILayout.Box("Состояния");

		GUILayout.BeginHorizontal();
		if (GUILayout.Button(Statements.pause ? "False" : "True", GUILayout.Width(40))) Statements.setPause(!Statements.pause);
		GUILayout.Label($"Пауза: {Statements.pause}");
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if (GUILayout.Button(Statements.gameOver ? "False" : "True", GUILayout.Width(40))) Statements.setGameOver(!Statements.gameOver);
		GUILayout.Label($"Конец игры: {Statements.gameOver}");
		GUILayout.EndHorizontal();

		GUILayout.Space(10);
	}
}
