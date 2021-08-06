using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float nowTime = 1f;
    [SerializeField] private float boostTime = 100f;
    [SerializeField] private float howAddTime = 0.1f;
    [SerializeField] private GameObject panelDead;
    [SerializeField] private bool isActive = true;
    [SerializeField] private Text text;
    [SerializeField] private float timeBtwScore = 0.5f;
    

    private int score = 0;
    private float timeNextScore;

    private void Update()
    {
        AddNumberScore();
        if (score >= boostTime)
        {
            nowTime += howAddTime;
            boostTime *= 2;
        }
    }

    public void PanelIsActive()
    {
        panelDead.SetActive(isActive);
    }

    private void AddNumberScore()
    {
        timeNextScore += Time.deltaTime;

        if (timeNextScore > timeBtwScore)
        {
            score++;
            text.text = score.ToString();
            timeNextScore = 0;
        }
    }
}
