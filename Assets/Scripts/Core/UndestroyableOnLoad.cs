using UnityEngine;

public class UndestroyableOnLoad : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
}
