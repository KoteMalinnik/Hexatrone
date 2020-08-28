using UnityEngine;

public class ApplicationQuitListener : MonoBehaviour
{
	void OnApplicationQuit()
	{
		//т.к. объект существует на всех сценах, то припишем ему сохранить все параметры по выходу
		Serialization.saveAllParametrs();
	}
}
