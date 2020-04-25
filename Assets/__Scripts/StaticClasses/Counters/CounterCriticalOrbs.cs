using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */


public static class CounterCriticalOrbs
{
	public static int value { get; private set; } = 5;
	public static void setValue(int newValue)
	{
		value = newValue;
		Debug.Log("[CounterTotalOrbs]");
	}
}