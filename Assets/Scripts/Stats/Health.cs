public class Health : Stat, IDecrease, IIncrease
{
    public void Decrease(float value)
    {
        if (value < 0)
            return;

        _current -= value;

        OnDecrease.Invoke();

        if (_current <= 0)
        {
            _current = 0;

            OnZeroing.Invoke();
        }
    }

    public void Increase(float value)
    {
        if (value < 0)
            return;

        _current += value;

        if (_current >= _max)
            _current = _max;

        OnIncrease.Invoke();
    }
}