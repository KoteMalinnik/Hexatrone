using UnityEngine.UI;
using UnityEngine;
using System.Text;

/// <summary>
/// Управление счетчиком времени.
/// </summary>
public class TimerControllerGUI : MonoBehaviour
{
	//время игры на уровне
	public static short sec { get; private set; }
	public static short min { get; private set; }

	[SerializeField]
	Text textTimer = null;

	void Start()
	{
		sec = 0;
		min = 0;

		InvokeRepeating("Timer", 0, 1);
	}

	readonly StringBuilder stringBuilder = new StringBuilder(5);
	void Timer()
	{
		if (Statements.pause) return;

		stringBuilder.Clear();
		stringBuilder.AppendFormat("{0:00}:{1:00}", min, sec);

		sec++;
		if (sec >= 60)
		{
			sec = 0;
			min++;
		}

		textTimer.text = stringBuilder.ToString();
	}
}
