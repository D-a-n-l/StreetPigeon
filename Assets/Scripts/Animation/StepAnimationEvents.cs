using System;

public static class StepAnimationEvents
{
    public static string CurrentKey { get; private set; }

    public static Action<bool> StartStep;

    public static void SetKey(string key)
    {
        CurrentKey = key;
    }

    public static void Invoke(bool value)
    {
        StartStep?.Invoke(value);
    }
}