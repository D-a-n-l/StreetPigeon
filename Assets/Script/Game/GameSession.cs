using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [Header("Boost velocity")]
    [Range(0, 10)] [SerializeField] private float nowVelocityGame = 1f;
    [SerializeField] private float whenIncreaseVelocityGame = 100f;
    [SerializeField] private float howAddTime = 0.1f;

    [Header("Properties panel")]
    [SerializeField] private GameObject panelDead;
    [SerializeField] private Text textFinalScore;
    [SerializeField] private bool isActivePanel = false;
    
    [Header("Properties text score")]
    [SerializeField] private Text textScore, textHighScore;
    [SerializeField] private float timeBtwScore = 0.5f;
    private int scoreCounter = 0;
    private int scoreHighCounter;
    private float timeIncreaseScore;

    private void Start()
    {
        scoreHighCounter = MasterPlayerPrefs.GetHighScoreMaster();
        Time.timeScale = nowVelocityGame;
    }

    private void Update()
    {
        textHighScore.text = scoreHighCounter.ToString();
        textScore.text = scoreCounter.ToString();
        IncreaseVelocityGame();

        if (!isActivePanel)
        {
            AddNumberScore();
        }
        else 
        {
            textFinalScore.text = scoreCounter.ToString();
            panelDead.SetActive(isActivePanel);
        }
    }

    private void IncreaseVelocityGame()
    {
        if (scoreCounter >= whenIncreaseVelocityGame)
        {
            nowVelocityGame += howAddTime;
            Time.timeScale = nowVelocityGame;
            whenIncreaseVelocityGame += 150;
        }
    }

    public void PanelIsActive()
    {
        isActivePanel = true;
    }

    private void AddNumberScore()
    {
        timeIncreaseScore += Time.deltaTime;

        if (timeIncreaseScore > timeBtwScore)
        {
            scoreCounter++;
            AddHighScore();
            timeIncreaseScore = 0;
        }
    }

    private void AddHighScore()
    {
        if (scoreCounter > scoreHighCounter)
        {
            scoreHighCounter = scoreCounter;
            MasterPlayerPrefs.SetHighScoreMaster(scoreHighCounter);
        }
    }

    public float VelocityGame()
    {
        return nowVelocityGame;
    }
}
