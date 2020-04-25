public static class Counters
{
	public static int orbsAtFormLevelCount { get; private set; } = 0;
	public static int totalOrbsCount { get; private set; } = 0;
	public static int criticalOrbsCount { get; private set; } = 5;
	public static int orbsToLevelUp { get; private set; } = 0;


	public static void setValue(ref int Value, int newValue) { Value = newValue; }

	public static void incrementValue(ref int Value, int delta = 1) { Value += delta; }
	public static void decrementValue(ref int Value, int delta = 1) { Value -= delta; }
}