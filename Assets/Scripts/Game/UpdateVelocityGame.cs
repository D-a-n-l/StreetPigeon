using System.Collections;
using UnityEngine;
using Zenject;

public class UpdateVelocityGame : MonoBehaviour
{
    [SerializeField]
    [Min(1)]
    private int _increaseEvery = 150;

    [Space(5)]
    [SerializeField]
    [Min(0.01f)]
    private float _howAddVelocity = 0.1f;
    
    [Space(5)]
    [SerializeField]
    [Min(0)]
    private float _defaultTimeScale = 1;

    [SerializeField]
    [Min(0.01f)]
    private float _maxTimeScale = 2f;

    private Score _score;

    private int _currentIncrease;

    [Inject]
    public void Construct(Score score)
    {
        _score = score;
    }

    public void Reset()
    {
        _currentIncrease = _increaseEvery;

        Time.timeScale = _defaultTimeScale;
    }

    public IEnumerator Increase()
    {
        yield return new WaitUntil(() => _score.CurrentScore >= _currentIncrease);
    
        _currentIncrease += _increaseEvery;

        Time.timeScale += _howAddVelocity;

        if (Time.timeScale < _maxTimeScale)
            StartCoroutine(Increase());
    }
}