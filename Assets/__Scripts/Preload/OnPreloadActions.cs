using UnityEngine;

/// <summary>
/// On Preload Actions
/// </summary>
public class OnPreloadActions : MonoBehaviour
{
	[SerializeField]
	bool loadMainMenuScene = true;

    //Т.к. объект находится только на сцене Preload,
	//С его помощью необходимо перейти на другую сцену
	void Awake()
	{
		Serialization.loadAllParametrs();

		if(loadMainMenuScene) RegularMethods.LoadScene(1);
	}
}
