using UnityEngine;

/// <summary>
/// On Preload Actions
/// </summary>
public class OnPreloadActions : MonoBehaviour
{
    //Т.к. объект находится только на сцене Preload,
	//С его помощью необходимо перейти на другую сцену
	void Awake()
	{
		Serialization.loadAllParametrs();

		RegularMethods.LoadScene(1);
	}
}
