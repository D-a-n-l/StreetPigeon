using DG.Tweening;
using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.Events;

public class MoveY : MonoBehaviour
{
    public float y;

    public float duration;

    public int durationTask;


    public Ease ease;


    public UnityEvent OnCompleteMove;
    private Tween tween;

    public Action OnInvisible;

    [Button]
    public void Move()
    {
        tween = transform.DOMoveX(y, duration).SetEase(ease).SetUpdate(UpdateType.Normal, true);
    }

    private void OnBecameInvisible()
    {
        print("invis");
        OnInvisible?.Invoke();
    }

    [Button]
    public void Res()
    {
        transform.position = Vector3.zero;
    }

    private void OnDisable()
    {
        tween.Kill();
    }
}