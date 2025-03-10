using UnityEngine;
using Zenject;

public abstract class SelectableStat : MonoBehaviour
{
    [SerializeField]
    private Enums.TypeStat _typeStat;

    protected Stat _stat;

    [Inject]
    public void Construct(Health health, Energy energy)
    {
        if (_typeStat == Enums.TypeStat.Health)
            _stat = health;
        else if (_typeStat == Enums.TypeStat.Energy)
            _stat = energy;
    }
}