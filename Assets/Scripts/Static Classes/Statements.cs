using UnityEngine;

/// <summary>
/// Состояния игрового процесса
/// </summary>
public static class Statements
{
    /// <summary>
	/// Состояние паузы
	/// </summary>
	public static bool pause { get; private set; } = false;

	/// <summary>
	/// Установить состояние паузы
	/// </summary>
	public static void setPause(bool state)
	{
		Debug.Log($"<color=yellow>Пауза: {state}</color>");
		pause = state;
	}


	/// <summary>
	/// Состояние конца игры
	/// </summary>
	public static bool gameOver { get; private set; } = false;

	/// <summary>
	/// Установить состояние конца игры
	/// </summary>
	public static void setGameOver(bool state)
	{
		Debug.Log($"<color=yellow>Конец игры: {state}</color>");
		gameOver = state;

		if (pause) return;
		setPause(state);
	}
}
