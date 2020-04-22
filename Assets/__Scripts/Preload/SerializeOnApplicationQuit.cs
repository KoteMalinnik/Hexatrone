using UnityEngine;

/// <summary>
/// Serialize on application quit.
/// </summary>
public class SerializeOnApplicationQuit : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(this);
	}

    void OnApplicationQuit()
	{
		//т.к. объект существует на всех сценах, то припишем ему сохранить все параметры по выходу
		Serialization.saveAllParametrs();
	}
}
