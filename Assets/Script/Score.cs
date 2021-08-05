using TMPro;
using UnityEngine;

class Score : MonoBehaviour
{
    private int score = 0;
    private float timeNext;
    public TextMeshProUGUI text;

    private void Update()
    {
        timeNext += Time.deltaTime;
        if (timeNext > 0.5f)
        {
            score++;
            text.text = score.ToString();
            timeNext = 0; 
        }
    }
}
