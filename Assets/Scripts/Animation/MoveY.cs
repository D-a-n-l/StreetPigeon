using DG.Tweening;
using NaughtyAttributes;
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

    [Button]
    public void Move()
    {
        tween = transform.DOMoveX(y, duration).SetEase(ease).SetUpdate(UpdateType.Normal, true);
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