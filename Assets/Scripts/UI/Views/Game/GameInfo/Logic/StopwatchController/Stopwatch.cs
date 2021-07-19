using System;

public class Stopwatch
{
    #region Fields
    DateTime stopwatch = new DateTime(1, 1, 1, 0, 0, 0);
    #endregion

    #region Properties
    public int Second => stopwatch.Second;
    public int Minute => stopwatch.Minute;
    public int Hour => stopwatch.Hour;
    #endregion

    public override string ToString()
    {
        return stopwatch.ToString("mm:ss");
    }

    public void AddSecond()
    {
        stopwatch = stopwatch.AddSeconds(1);
    }
}