using UnityEngine;

public class UndestroyableOnLoadObject : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
}
