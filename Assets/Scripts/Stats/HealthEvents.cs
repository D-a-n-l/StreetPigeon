using UnityEngine.Events;

public class HealthEvents
{
    public static UnityEvent OnDecrease = new UnityEvent();

    public static UnityEvent OnIncrease = new UnityEvent();

    public static UnityEvent OnZeroing = new UnityEvent();

    public static void CallOnDecrease()
    {
        OnDecrease.Invoke();
    }

    public static void CallOnIncrease()
    {
        OnIncrease.Invoke();
    }

    public static void CallOnZeroing()
    {
        OnZeroing.Invoke();
    }
}