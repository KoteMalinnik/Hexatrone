using System;

/// <summary>
/// Управление уровнем формы.
/// </summary>
public static class FormLevelController
{
    #region Events
	public static event Action<int> OnFormLevelChange = null;
    #endregion

    #region Fields
    static int level = 1;
    #endregion

    public static void SetupLevel(int level)
    {
        Log.Message("Установка уровня формы: " + level);
        OnFormLevelChange?.Invoke(level);
    }

    public static void LevelUp()
    {
		Log.Message($"Уровень формы повышен.");
        SetupLevel(level + 1);
    }

	public static void LevelDown()
	{
		Log.Message($"Уровень формы понижен.");
        SetupLevel(level + 1);
	}
}
