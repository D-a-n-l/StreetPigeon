using UnityEngine;
using TMPro;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _textScore;

    [SerializeField]
    private TMP_Text _textHighScore;

    private Score _score;

    [Inject]
    public void Construct(Score score)
    {
        _score = score;
    }

    private void Awake()
    {
        _score.OnUpdated += OnUpdated;
        _score.OnUpdatedHighScore += OnUpdatedHighScore;
    }

    private void OnDestroy()
    {
        _score.OnUpdated -= OnUpdated;
        _score.OnUpdatedHighScore -= OnUpdatedHighScore;
    }

    private void OnUpdated()
    {
        _textScore.text = _score.CurrentScore.ToString();
    }

    private void OnUpdatedHighScore()
    {
        _textHighScore.text = _score.HighScore.ToString();
    }
}