public class Energy : Stat, IDecrease, IIncrease
{
    public Energy(float max) : base(max)
    {
    }

    private bool _isPressed = false;

    public void OnPressed(bool value) => _isPressed = value;

    public void Decrease(float value)
    {
        if (_isPressed == true)
        {
            if (value < 0)
                return;

            Current -= value;

            OnDecreased.Invoke();

            if (Current <= 0)
            {
                Current = 0;

                OnZeroing.Invoke();
            }
        }
    }

    public void Increase(float value)
    {
        if (value < 0)
            return;

        Current += value;

        if (Current >= Max)
            Current = Max;

        OnIncreased.Invoke();
    }
}