public class Energy : Stat, IDecrease, IIncrease
{
    private bool _isPressed = false;

    public void OnPressed(bool value) => _isPressed = value;

    public void Decrease(float value)
    {
        if (_isPressed == true)
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