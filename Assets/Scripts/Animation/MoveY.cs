using DG.Tweening;
using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.Events;

public class MoveY : MonoBehaviour
{
    [SerializeField]
    private float _x;

    [SerializeField]
    private float _duration;

    [field: SerializeField]
    public int DurationForTask { get; private set; }

    [SerializeField]
    private Ease _ease;

    private Tween tween;

    public event Action OnInvisible;

    public void Move()
    {
        tween = transform.DOMoveX(_x, _duration).SetEase(_ease).SetUpdate(UpdateType.Normal, true);
    }

    private void OnBecameInvisible()
    {
        OnInvisible?.Invoke();
    }

    private void OnDisable()
    {
        tween.Kill();
    }
}