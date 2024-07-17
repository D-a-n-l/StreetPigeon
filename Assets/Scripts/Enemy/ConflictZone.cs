using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(InjectObject))]
public class ConflictZone : MonoBehaviour
{
    [SerializeField]
    private bool _isDestroyObject = true;

    [SerializeField]
    private Enums.PlayerEvents _state;

    [Space(10)]
    [ShowIf(nameof(_state), Enums.PlayerEvents.healthOnDecrease)]
    [SerializeField]
    private float _healthDecrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.healthOnDecrease)]
    public UnityEvent OnHealthDecrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.healthOnIncrease)]
    [SerializeField]
    private float _healthIncrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.healthOnIncrease)]
    public UnityEvent OnHealthIncrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.energyOnDecrease)]
    [SerializeField]
    private float _energyDecrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.energyOnDecrease)]
    public UnityEvent OnEnergyDecrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.energyOnIncrease)]
    [SerializeField]
    private float _energyIncrease;

    [ShowIf(nameof(_state), Enums.PlayerEvents.energyOnIncrease)]
    public UnityEvent OnEnergyIncrease;

    private Health _health;

    private Energy _energy;

    [Inject]
    public void Initialize(Health health, Energy energy)
    {
        _health = health;

        _energy = energy;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {             
        if (other.GetComponent<MovingPlayer>())
        {
            if (_state.HasFlag(Enums.PlayerEvents.healthOnDecrease))
            {
                _health.Decrease(_healthDecrease);

                OnHealthDecrease.Invoke();
            }

            if (_state.HasFlag(Enums.PlayerEvents.healthOnIncrease))
            {
                _health.Increase(_healthIncrease);

                OnHealthIncrease.Invoke();
            }

            if (_state.HasFlag(Enums.PlayerEvents.energyOnDecrease))
            {
                _energy.Decrease(_energyDecrease);

                OnEnergyDecrease.Invoke();
            }

            if (_state.HasFlag(Enums.PlayerEvents.energyOnIncrease))
            {
                _energy.Increase(_energyIncrease);

                OnEnergyIncrease.Invoke();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<MovingPlayer>() && _isDestroyObject == true)
        {
            Destroy(gameObject);
        }
    }
}