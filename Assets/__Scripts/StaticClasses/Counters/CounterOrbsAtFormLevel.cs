using UnityEngine;

public static class CounterOrbsAtFormLevel
{
	public static int valueToLevelUp { get; private set; } = 0;

	public static int value { get; private set; } = 0;
	public static void setValue(int newValue)
	{
		value = newValue;
		Debug.Log("[CounterTotalOrbs]");
	}
}