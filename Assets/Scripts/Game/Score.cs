using System;
using System.Collections;
using UnityEngine;

public class Score
{
    public int CurrentScore { get; private set; } = 0;

    public int HighScore { get; private set; }

    private float _timeUpdateScore = 0.5f;

    private float _timeIncreaseScore;

    private Coroutine _currentCoroutine;

    public Action OnUpdated;

    public Action OnUpdatedHighScore;

    public void Start()
    {
        Debug.Log("Score " + CurrentScore);

        HighScore = MasterPlayerPrefs.GetInt(MasterPlayerPrefs.HIGH_SCORE, 0);

        OnUpdatedHighScore?.Invoke();

        _currentCoroutine = Coroutines.Start(UpdateScores());
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
                CurrentScore++;

                _timeIncreaseScore = 0;

                if (CurrentScore > HighScore)
                {
                    HighScore = CurrentScore;

                    OnUpdatedHighScore?.Invoke();
               }
            }
        }
    }

    public void Reset()
    {
        CurrentScore = 0;

        Coroutines.Stop(_currentCoroutine);

        OnUpdated?.Invoke();
    }

    public void SaveHighScore()//когда игрок умер
    {
        MasterPlayerPrefs.SetInt(MasterPlayerPrefs.HIGH_SCORE, HighScore);
    }
}