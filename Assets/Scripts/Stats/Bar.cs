using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private Enums.TypeStat _typeStat;

    [Space(10)]
    [SerializeField]
    [Min(0.001f)]
    private float _speedEffect = 0.003f;

    [Space(10)]
    [SerializeField]
    private Image _bar;

    [SerializeField]
    private Image _barEffect;

    private Stat _stat;

    [Inject]
    public void Construct(Health health, Energy energy)
    {
        if (_typeStat == Enums.TypeStat.Health)
            _stat = health;
        else if (_typeStat == Enums.TypeStat.Energy)
            _stat = energy;
    }

    private void Start()
    {
        _stat.OnDecrease += Effect;
        _stat.OnIncrease += Effect;
    }

    private void OnDisable()
    {
        _stat.OnDecrease -= Effect;
        _stat.OnIncrease -= Effect;
    }

    private void Effect() => StartCoroutine(EffectCo());

    private IEnumerator EffectCo()
    {
        _bar.fillAmount = _stat.Current / _stat.Max;

        while (true)
        {
            if (_barEffect.fillAmount > _bar.fillAmount)
            {
                _barEffect.fillAmount -= _speedEffect;
            }
            else
            {
                _barEffect.fillAmount = _bar.fillAmount;
                StopAllCoroutines();
            }

            yield return null;
        }
    }
}