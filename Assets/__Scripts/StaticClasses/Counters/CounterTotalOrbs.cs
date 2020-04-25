using UnityEngine;


/*
 * РЕФАКТОРИТЬ 
 */


public static class CounterTotalOrbs
{
	public static int value { get; private set; } = 0;
	public static void setValue(int newValue)
	{
		value = newValue;
		Debug.Log("[CounterTotalOrbs]");
	}
}