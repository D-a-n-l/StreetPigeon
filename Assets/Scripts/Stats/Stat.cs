using UnityEngine;
using UnityEngine.Events;

public abstract class Stat : MonoBehaviour
{
    [SerializeField]
    [Min(0.001f)]
    protected float _max;

    public float Max => _max;

    protected float _current;

    public float Current => _current;

    public UnityEvent OnDecrease;

    public UnityEvent OnIncrease;

    public UnityEvent OnZeroing;

    public void Start() => _current = _max;
}