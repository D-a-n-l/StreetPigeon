using System.Collections;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class DOLoopMove : MonoBehaviour
{
    [SerializeField]
    private bool _isStart = false;

    [ShowIf(nameof(_isStart))]
    [SerializeField]
    private Enums.TypeLoopMove _typeMove;

    [ShowIf(nameof(_typeMove), Enums.TypeLoopMove.RandomMoveAnchor)]
    [SerializeField]
    private RectTransform _rectTransform;

    [SerializeField]
    private float _duration;

    [SerializeField]
    public Ease _ease;

    [SerializeField]
    private MinMax _newRandomPositionX;

    [SerializeField]
    private MinMax _newRandomPositionY;

    [SerializeField]
    private MinMax _newRandomRotation;

    [SerializeField]
    private MinMax _delayBetweenMove;
    
    private Vector3 _randomVector;

    private WaitForSeconds _delay;

    private Tween _tween;

    private Coroutine _coroutine;

    private Vector3 _basePosition;

    private void Awake()
    {
        if (_isStart == true)
        {
            Go();
        }
    }

    public void Stop()
    {
        _tween.Kill();

        transform.DORotate(Vector3.zero, 2f);

        if (_coroutine != null)
            StopAllCoroutines();
            //StopCoroutine(_coroutine);
    }

    public void Go()
    {
        switch (_typeMove)
        {
            case Enums.TypeLoopMove.RandomMove:
                _coroutine = StartCoroutine(RandomMove());
                break;
            case Enums.TypeLoopMove.RandomMoveAnchor:
                _coroutine = StartCoroutine(RandomMoveAnchor(_rectTransform));
                break;
            case Enums.TypeLoopMove.LoopRandomRotate:
                _coroutine = StartCoroutine(LoopRandomRotate());
                break;
            case Enums.TypeLoopMove.LoopRotate:
                _coroutine = StartCoroutine(LoopRotate());
                break;
        }
    }

    public IEnumerator RandomMove()
    {
        RandomVectorAndDelay(
            Random.Range(_newRandomPositionX.Min, _newRandomPositionX.Max), 
            Random.Range(_newRandomPositionY.Min, _newRandomPositionY.Max), 
            0f, 
            Random.Range(_delayBetweenMove.Min, _delayBetweenMove.Max));

        _tween = transform.DOMove(_randomVector, _duration); 

        yield return _delay;

        _coroutine = StartCoroutine(RandomMove());
    }

    public IEnumerator RandomMoveAnchor(RectTransform rectTransform)
    {
        RandomVectorAndDelay(
            Random.Range(_newRandomPositionX.Min, _newRandomPositionX.Max), 
            Random.Range(_newRandomPositionY.Min, _newRandomPositionY.Max), 
            0f, 
            Random.Range(_delayBetweenMove.Min, _delayBetweenMove.Max));

        _tween = rectTransform.DOAnchorPos(_randomVector, _duration); 

        yield return _delay;

        _coroutine = StartCoroutine(RandomMoveAnchor(rectTransform));
    }

    public IEnumerator LoopRandomRotate()
    {
        _tween.Kill();

        RandomVectorAndDelay(
            0f, 
            0f, 
            Random.Range(_newRandomRotation.Min, _newRandomRotation.Max), 
            Random.Range(_delayBetweenMove.Min, _delayBetweenMove.Max));

        _tween = DOTween.Sequence()
            .SetEase(_ease)
            .Append(transform.DOLocalRotate(_randomVector, _duration))
            .Append(transform.DOLocalRotate(_randomVector * -1, _duration))
            .Append(transform.DORotate(Vector3.zero, _duration));

        yield return _delay;

        _coroutine = StartCoroutine(LoopRandomRotate());
    }

    public IEnumerator LoopRotate()
    {
        _tween.Kill();

        RandomVectorAndDelay(
            0f, 
            0f, 
            Random.Range(_newRandomRotation.Min, _newRandomRotation.Max), 
            Random.Range(_delayBetweenMove.Min, _delayBetweenMove.Max));

        _tween = DOTween.Sequence()
            .SetEase(_ease)
            .Append(transform.DOLocalRotate(_randomVector, _duration))
            .Append(transform.DOLocalRotate(_randomVector * -1, _duration));

        yield return _delay;

        _coroutine = StartCoroutine(LoopRandomRotate());
    }

    private void RandomVectorAndDelay(float randomX, float randomY, float randomZ, float randomDelay)
    {
        _randomVector = new Vector3(randomX, randomY, randomZ);

        _delay = new WaitForSeconds(randomDelay);
    }

    private void OnDestroy()
    {   
        _tween.Kill();
    }
}