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

        _defaultRotation = new Vector3(0f, 0f, -7f);

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

    public void PressedButton(float speed)
    {
        if (_isPressed == true)
        {
            ButtonDown(speed);
        }
    }

    public void ButtonDown(float speed)
    {
        if (_energy.Current <= 0)
            return;

        _currentSpeed = speed;

        transform.DOLocalRotate(_newRotation, _durationRotation);

        OnButtonDown.Invoke();
    }

    public void Rotate(float rotateZ)
    {
        _newRotation = new Vector3(0f, 0f, rotateZ);

        //NewMethod();
    }

    public void NewMethod()
    {
        transform.DOLocalRotate(_newRotation, _durationRotation);
    }

    public void ButtonUp(float speed)
    {
        if (_energy.Current <= 0)
            return;

        _currentSpeed = speed;

        transform.DOLocalRotate(_defaultRotation, _durationRotation);

        OnButtonUp.Invoke();
    }

    public void SwitchCurrentSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;

        transform.DOLocalRotate(_newRotation, _durationRotation);

        OnButtonUp.Invoke();
    }
}