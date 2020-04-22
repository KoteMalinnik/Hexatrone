﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPreload : MonoBehaviour
{
    //Т.к. объект находится только на сцене Preload,
	//С его помощью необходимо перейти на другую сцену
	void Awake()
	{
		Serialization.loadAllParametrs();

		SceneManager.LoadScene("MainMenu");
	}
}
