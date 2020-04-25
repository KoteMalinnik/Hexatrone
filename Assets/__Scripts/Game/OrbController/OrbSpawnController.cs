using UnityEngine;

public static class OrbSpawnController
{
	static Vector2 spawnPosition = Vector2.zero;

	public static void setupPosition(Transform orbTransform)
	{
		spawnPosition.x = Random.Range(-3, 3);
		orbTransform.localPosition = spawnPosition;
	}
}
