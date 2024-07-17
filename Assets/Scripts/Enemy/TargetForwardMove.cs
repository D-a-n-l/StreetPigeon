using System.Collections;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class TargetForwardMove : MonoBehaviour
{
    [SerializeField]
    private bool _isWithDelay = false;

    [SerializeField]
    [Min(0.001f)]
    private float _duration = 5f;

    [SerializeField]
    [Min(0.001f)]
    private float _waitTime = 5f;

    [SerializeField]
    private Vector3 _offset;

    private MovingPlayer _movingPlayer;

    private WaitForSeconds _waitForSeconds;

    private Tween _tween;

    [Inject]
    public void Construct(MovingPlayer movingPlayer)
    {
        _movingPlayer = movingPlayer;
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitTime);

        if (_isWithDelay == true)
            StartCoroutine(TargetForwardWithDelay());
        else
            TargetForward();
    }

    public void TargetForward()
    {
        Vector3 targetPosition = _movingPlayer.transform.position + _offset;

        _tween = transform.DOMove(targetPosition, _duration);
    }

    public IEnumerator TargetForwardWithDelay()
    {
        yield return _waitForSeconds;

        Vector3 targetPosition = _movingPlayer.transform.position + _offset;

        _tween = transform.DOMove(targetPosition, _duration);
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}