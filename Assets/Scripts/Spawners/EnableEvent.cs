using UnityEngine.Events;

public static class EnableEvent
{
    public static UnityEvent<bool> Enabled = new UnityEvent<bool>();

    public static void CallEnabled(bool value)
    {
        Enabled.Invoke(value);
    }
}