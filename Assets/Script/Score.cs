using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
