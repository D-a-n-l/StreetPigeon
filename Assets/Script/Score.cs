using UnityEngine;
using UnityEngine.UI;

class Score : MonoBehaviour
{
    private int score = 0;
    private float timeNext;
    public Text text;

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
