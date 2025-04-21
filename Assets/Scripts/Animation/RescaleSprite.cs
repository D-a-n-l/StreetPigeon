using UnityEngine;
using DG.Tweening;

public class RescaleSprite : MonoBehaviour
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
            RescalePingPong(transform, _newScale, _defaultScale, _duration, _numberLoop);
    }

    public void RescalePingPong(Transform go, Vector3 newScale, Vector3 baseScale, float duration, int numberLoop)
    {
        _tween = DOTween.Sequence()
            .Append(go.transform.DOScale(newScale, duration))
            .Append(go.transform.DOScale(baseScale, duration))
            .SetLoops(numberLoop);
    }

    public static void Rescale(Transform go, Vector3 newScale, float duration)
    {
        go.transform.DOScale(newScale, duration);
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}