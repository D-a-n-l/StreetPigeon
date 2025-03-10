public class Health : Stat, IDecrease, IIncrease
{
    public Health(float max) : base(max)
    {
    }

    public void Decrease(float value)
    {
        if (value < 0)
            return;

        Current -= value;

        OnDecrease.Invoke();

        if (Current <= 0)
        {
            Current = 0;

            OnZeroing.Invoke();
        }
    }

    public void Increase(float value)
    {
        if (value < 0)
            return;

        Current += value;

        if (Current >= Max)
            Current = Max;

        OnIncrease.Invoke();
    }
}