using UnityEngine;
using DG.Tweening;

public class ResizeSprite : MonoBehaviour
{
    [SerializeField]
    private bool _playOnAwake = true;

    [Space(5)]
    [SerializeField]
    private Vector3 _newScale;

    [SerializeField]
    [Min(0.001f)]
    private float _duration;

    [SerializeField]
    private int _numberLoop;

    private Vector3 _defaultScale;

    private Tween _tween;

    private void Start()
    {
        _defaultScale = transform.localScale;

        if (_playOnAwake == true)
            Rescale();
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }

    public void Rescale()
    {
        _tween = DOTween.Sequence()
            .Append(transform.DOScale(_newScale, _duration))
            .Append(transform.DOScale(_defaultScale, _duration))
            .SetLoops(_numberLoop);
    }
}