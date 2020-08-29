using System;

public static class FormLevelController
{
    #region Events
	public static event Action<int> OnFormLevelChange = null;
    #endregion

    #region Properties
    public static int Level { get; private set; } = 0;
    #endregion

    public static void SetupLevel(int level)
    {
        Level = level;
        Log.Message("Установка уровня формы: " + level);
        OnFormLevelChange?.Invoke(level);
    }

    public static void LevelUp()
    {
		Log.Message($"Уровень формы повышен.");
        SetupLevel(Level + 1);
    }

	public static void LevelDown()
	{
		Log.Message($"Уровень формы понижен.");
        SetupLevel(Level + 1);
	}
}
