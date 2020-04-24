using UnityEngine;

/// <summary>
/// Values controller.
/// </summary>
public static class ValuesController
{
	/// <summary>
	/// Gets the score value.
	/// </summary>
	/// <value>The score value.</value>
	public static int scoreValue { get; private set; } = 0;

	/// <summary>
	/// Sets the score value.
	/// </summary>
	/// <param name="newScoreValue">New score value.</param>
	public static void setScoreValue(int newScoreValue)
	{
		if (newScoreValue < 0)
		{
			Debug.Log("<color=red>Счет меньше нуля</color>");
			return;
		}
		
		scoreValue = newScoreValue;
		Debug.Log($"Счет: {scoreValue}");
	}

	/// <summary>
	/// Increments the score value.
	/// </summary>
	public static void incrementScoreValue()
	{
		var incrementedValue = scoreValue + 1;
		setScoreValue(incrementedValue);
	}
}