using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using NaughtyAttributes;

public class DOMovePosition : MonoBehaviour
{
    [SerializeField]
    private bool _isStart = false;

    [ShowIf(nameof(_isStart))]
    [SerializeField]
    private Enums.TypeMove _typeMove;

    [ShowIf(nameof(_typeMove), Enums.TypeMove.moveAnchor)]
    [SerializeField]
    private RectTransform _rectTransform;

    [SerializeField]
    private Vector3 _newPosition;

    [SerializeField]
    [Min(0.01f)]
    private float _duration;

    [SerializeField]
    private Ease _ease;

    private Tween _tween;

    public UnityEvent OnCompleteMove;
    
    private void Start()
    {
        if (_isStart == true)
        {
            switch(_typeMove)
            {
                case Enums.TypeMove.move:
                    Move();
                    break;
                case Enums.TypeMove.localMove:
                    LocalMove();
                    break;
                case Enums.TypeMove.moveAnchor:
                    MoveAnchor(_rectTransform);
                    break;
            }
        }
    }

    public void Move()
    {
        _tween = DOTween.Sequence()
            .SetUpdate(UpdateType.Normal, true)
            .SetEase(_ease)
            .Append(transform.DOMove(_newPosition, _duration))
            .OnComplete(()=> OnCompleteMove.Invoke());
    }

    public void LocalMove()
    {
        _tween = DOTween.Sequence()
            .SetUpdate(UpdateType.Normal, true)
            .SetEase(_ease)
            .Append(transform.DOLocalMove(_newPosition, _duration))
            .OnComplete(()=> OnCompleteMove.Invoke());
    }

    public void MoveAnchor(RectTransform rectTransform)
    {
        _tween = DOTween.Sequence()
            .SetUpdate(UpdateType.Normal, true)
            .SetEase(_ease)
            .Append(rectTransform.DOAnchorPos(_newPosition, _duration))
            .OnComplete(()=> OnCompleteMove.Invoke());
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}