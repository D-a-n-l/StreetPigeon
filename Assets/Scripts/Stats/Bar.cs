using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : SelectableStat
{
    [Space(10)]
    [SerializeField]
    [Min(0.001f)]
    private float _speedEffect = 0.003f;

    [Space(10)]
    [SerializeField]
    private Image _bar;

    [SerializeField]
    private Image _barEffect;

    private void Start()
    {
        _stat.OnDecreased += Effect;
        _stat.OnIncreased += Effect;
    }

    private void OnDisable()
    {
        _stat.OnDecreased -= Effect;
        _stat.OnIncreased -= Effect;
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