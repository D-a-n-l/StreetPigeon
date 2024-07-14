using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkSprite : MonoBehaviour
{
    [SerializeField]
    private bool _playOnAwake = true;

    [Space(5)]
    [SerializeField]
    private Color _colorBlink;

    [SerializeField]
    [Min(0.01f)]
    private float _duration;

    [SerializeField]
    private int _numberLoop;

    private SpriteRenderer _spriteRenderer;

    private Color _defaultColor;

    private Tween _tween;

    private void Start()
    {
        _spriteRenderer ??= GetComponent<SpriteRenderer>();

        _defaultColor = _spriteRenderer.color;

        if (_playOnAwake == true)
            Blink();
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }

    public void Blink()//поместить в ивент игрока
    {
        _tween = DOTween.Sequence()
            .Append(_spriteRenderer.DOColor(_colorBlink, _duration))
            .Append(_spriteRenderer.DOColor(_defaultColor, _duration))
            .SetLoops(_numberLoop);
    }
}