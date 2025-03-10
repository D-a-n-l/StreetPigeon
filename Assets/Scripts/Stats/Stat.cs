using System;

public class Stat
{
    public Stat(float max)
    {
        Max = max;

        Current = Max;
    }

    public float Max { get; protected set; }

    public float Current { get; protected set; }

    public Action OnDecreased;

    public Action OnIncreased;

    public Action OnZeroing;
}