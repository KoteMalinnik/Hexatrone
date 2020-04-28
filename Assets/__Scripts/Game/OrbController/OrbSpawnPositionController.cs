using UnityEngine;

/// <summary>
/// Контроллер позиции появления сферы.
/// </summary>
public static class OrbSpawnPositionController
{
	/// <summary>
	/// Позиция появления.
	/// </summary>
	static Vector2 spawnPosition = Vector2.zero;

	/// <summary>
	/// Установить позицию появления.
	/// </summary>
	/// <param name="orbTransform">Transform сферы.</param>
	public static void setupPosition(Transform orbTransform)
	{
		spawnPosition.x = Random.Range(-3, 3);
		orbTransform.localPosition = spawnPosition;
	}
}
