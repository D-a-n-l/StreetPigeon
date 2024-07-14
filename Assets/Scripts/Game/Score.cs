using System;
using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    [Min(0.001f)]
    private float _timeUpdateScore = 0.5f;

    private int _currentScore = 0;

    public int CurrentScore => _currentScore;

    private int _highScore;

    public int HighScore => _highScore;

    private float _timeIncreaseScore;

    public Action OnUpdated;

    public Action OnUpdatedHighScore;

    private void Start()
    {
        _highScore = MasterPlayerPrefs.GetInt(MasterPlayerPrefs.HIGH_SCORE, 0);

        OnUpdatedHighScore?.Invoke();

        StartCoroutine(UpdateScores());
    }

    private IEnumerator UpdateScores()
    {
        while(true)
        {
            OnUpdated?.Invoke();
            
            _timeIncreaseScore += Time.deltaTime;

            yield return null;

            if (_timeIncreaseScore > _timeUpdateScore)
            {
                _currentScore++;

                _timeIncreaseScore = 0;

                if (_currentScore > _highScore)
                {
                    _highScore = _currentScore;

                    OnUpdatedHighScore?.Invoke();
               }
            }
        }
    }

    public void Reset() => _currentScore = 0;
    
    public void SaveHighScore()//когда игрок умер
    {
        MasterPlayerPrefs.SetInt(MasterPlayerPrefs.HIGH_SCORE, _highScore);
    }
}