using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlayer : MonoBehaviour
{
    [SerializeField]
    private float _speedFall = -2f;

    [SerializeField]
    [Min(0.001f)]
    private float _durationRotation;

    private float _currentSpeed;

    private bool _isPressed = false;

    private Rigidbody2D _rigidbody2d;

    private Vector3 _defaultRotation;

    private Vector3 _newRotation;

    private Energy _energy;

    public UnityEvent OnButtonDown;

    public UnityEvent OnButtonUp;

    [Inject]
    private void Construct(Energy energy)
    {
        _energy = energy;
    }

    private void Start()
    {
        _rigidbody2d ??= GetComponent<Rigidbody2D>();

        _currentSpeed = _speedFall;

        StartRotation();
    }

    private void OnEnable()
    {
        StartRotation();
    }

    private void FixedUpdate()
    {
        _rigidbody2d.velocity = Vector2.up * _currentSpeed;
    }

    public void OnPressed(bool value) => _isPressed = value;

    public void Rotate(float rotateZ) => _newRotation = new Vector3(0f, 0f, rotateZ);

    public void StartRotation()
    {
        _defaultRotation = new Vector3(0f, 0f, -7f);

        transform.DOLocalRotate(_defaultRotation, _durationRotation);
    }

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

        StartRotation();

        OnButtonUp.Invoke();
    }
}