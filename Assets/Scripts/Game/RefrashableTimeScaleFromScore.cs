using System.Collections;
using UnityEngine;

public class RefrashableTimeScaleFromScore
{
    private int _increaseEvery = 150;

    private float _howAddTimeScale = 0.1f;
    
    private float _baseTimeScale = 1;

    private float _maxTimeScale = 2f;

    private int _currentIncreaseEvery;

    private Score _score;

    private WaitUntil _wait;

    private Coroutine _currentCoroutine;

    public RefrashableTimeScaleFromScore(int increaseEvery, float howAddTimeScale, float baseTimeScale, float maxTimeScale, Score score)
    {
        _increaseEvery = increaseEvery;

        _howAddTimeScale = howAddTimeScale;

        _baseTimeScale = baseTimeScale;

        _maxTimeScale = maxTimeScale;

        _score = score;

        _wait = new WaitUntil(() => _score.CurrentScore >= _currentIncreaseEvery);
    }

    public void Start()
    {
        _currentCoroutine = Coroutines.Start(StartCo());
    }

    public void Stop()
    {
        Coroutines.Stop(_currentCoroutine);
    }

    public void Reset()
    {
        _currentIncreaseEvery = _increaseEvery;

        Time.timeScale = _baseTimeScale;
    }

    private IEnumerator StartCo()
    {
        yield return _wait;

        _currentIncreaseEvery += _increaseEvery;

        Time.timeScale += _howAddTimeScale;

        if (Time.timeScale < _maxTimeScale)
            Start();
    }
}