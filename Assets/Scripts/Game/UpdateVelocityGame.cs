using System.Collections;
using UnityEngine;

public class UpdateVelocityGame
{
    private int _increaseEvery = 150;

    private float _howAddVelocity = 0.1f;
    
    private float _baseTimeScale = 1;

    private float _maxTimeScale = 2f;

    private int _currentIncrease;

    private Score _score;

    private WaitUntil _waitUntil;

    private Coroutine _currentCoroutine;

    public UpdateVelocityGame(int increaseEvery, float howAddVelocity, float baseTimeScale, float maxTimeScale, Score score)
    {
        _increaseEvery = increaseEvery;

        _howAddVelocity = howAddVelocity;

        _baseTimeScale = baseTimeScale;

        _maxTimeScale = maxTimeScale;

        _score = score;

        //_waitUntil = new WaitUntil(() => _score.CurrentScore >= _currentIncrease);
    }

    public void Start()
    {

        //_waitUntil = new WaitUntil(() => _score.CurrentScore >= _currentIncrease);

        _currentCoroutine = Coroutines.Start(StartCo());
    }

    public void Stop()
    {
        Coroutines.Stop(_currentCoroutine);
    }

    public void Reset()
    {
        _currentIncrease = _increaseEvery;

        Time.timeScale = _baseTimeScale;
    }

    private IEnumerator StartCo()
    {
        yield return new WaitUntil(() => _score.CurrentScore >= _currentIncrease);

        _currentIncrease += _increaseEvery;

        Time.timeScale += _howAddVelocity;

        if (Time.timeScale < _maxTimeScale)
            Start();
    }
}