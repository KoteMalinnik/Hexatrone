using System;

/// <summary>
/// Состояния игрового процесса
/// </summary>
public static class Statements
{
	public static event Action OnPause = null;
	public static event Action OnUnpause = null;

	public static event Action OnGameOver = null;

	static bool _pause = false;
	static bool _gameOver = false;

    public static bool Pause
	{
		get => _pause;
		set
        {
			Log.Message("Переключение состояния паузы: " + value);
			_pause = value;

			UnityEngine.Time.timeScale = value ? 0 : 1;

			if (value) OnPause?.Invoke();
			else OnUnpause?.Invoke();
        }
	}

	public static bool GameOver
	{
		get => _gameOver;
		set
		{
			Log.Message("Переключение состояния конца игры: " + value);
			_gameOver = value;

			if (value) Pause = true;
			if (value) OnGameOver?.Invoke();
		}
	}
}
