using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private Stat _stat;

    [Space(5)]
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
        _stat.OnDecrease.AddListener(()=> StartCoroutine(Effect()));
        _stat.OnIncrease.AddListener(()=> StartCoroutine(Effect()));
    }

    private IEnumerator Effect()
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