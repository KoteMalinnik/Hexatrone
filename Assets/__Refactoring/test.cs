using UnityEngine;

public class test : MonoBehaviour
{
	[SerializeField]
	KeyCode keyDown_1 = KeyCode.None;

	[SerializeField]
	KeyCode keyDown_2 = KeyCode.None;

	[SerializeField]
	KeyCode keyDown_3 = KeyCode.None;

	[SerializeField]
	KeyCode keyDown_4 = KeyCode.None;


	void Update()
	{
		if (Input.GetKeyDown(keyDown_1)) method();

		if (Input.GetKeyDown(keyDown_2)) Debug.Log(keyDown_2);

		if (Input.GetKeyDown(keyDown_3)) Debug.Log(keyDown_3);

		if (Input.GetKeyDown(keyDown_4)) Debug.Log(keyDown_4);
	}

	void method()
	{
		Debug.Log("method");
	}
}