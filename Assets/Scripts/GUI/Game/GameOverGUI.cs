using UnityEngine;

/// <summary>
/// Управление GUI при конце игры.
/// </summary>
public class GameOverGUI : MonoBehaviour
{
	[SerializeField]
	GameObject _panelGameOver = null;
	static GameObject panelGameOver;

	void Awake()
	{
		panelGameOver = _panelGameOver;

		//var panelsSwitcher = new PanelsActivitySwitcher();
		//panelsSwitcher.__HidePanel(panelGameOver);

		Destroy(this);
	}

	public static void gameOver()
	{
		Statements.setGameOver(true);

		//var panelsSwitcher = new PanelsActivitySwitcher();
		//panelsSwitcher.__ShowPanel(panelGameOver);

		//SoundManager.playSound(5);
	}
}