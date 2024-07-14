using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlayer : MonoBehaviour
{
    [SerializeField]
    private float _speedFlyUp = 5f;

    [SerializeField]
    private float _speedFlyDown = -2f;

    [SerializeField]
    private Vector3 _newRotation;

    [SerializeField]
    [Min(0.001f)]
    private float _durationRotation;

    private Rigidbody2D _rigidbody2d;

    private Vector3 _defaultRotation;

    private float _currentSpeed;

    private bool _isPressed = false;

    private Energy _energy;

    public UnityEvent OnButtonDown;

    public UnityEvent OnButtonUp;

    private void Start()//поменять DOLocalRotate в другой скрипт
    {
        _rigidbody2d ??= GetComponent<Rigidbody2D>();

        _currentSpeed = _speedFlyDown;

        _defaultRotation = transform.rotation.eulerAngles;

        transform.DOLocalRotate(_newRotation, _durationRotation);

        EnergyEvents.OnZeroing.AddListener(()=> SwitchCurrentSpeed(-1f));
    }

    [Inject]
    private void Construct(Energy energy)
    {
        _energy = energy;
    }

    private void FixedUpdate()
    {
        _rigidbody2d.velocity = Vector2.up * _currentSpeed;
    }

    public void OnPressed(bool value) => _isPressed = value;

    public void PressedButton()
    {
        if (_isPressed == true)
        {
            ButtonDown();
        }
    }

    public void ButtonDown()
    {
        if (_energy.Current <= 0)
            return;

        _currentSpeed = _speedFlyUp;

        transform.DOLocalRotate(_defaultRotation, _durationRotation);

        OnButtonDown.Invoke();
    }

    public void ButtonUp()
    {
        if (_energy.Current <= 0)
            return;

        _currentSpeed = _speedFlyDown;

        transform.DOLocalRotate(_newRotation, _durationRotation);

        OnButtonUp.Invoke();
    }

    public void SwitchCurrentSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;

        transform.DOLocalRotate(_newRotation, _durationRotation);

        OnButtonUp.Invoke();
    }
}