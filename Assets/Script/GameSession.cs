using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float freezeTime = 1f;

    private void Update()
    {
        Time.timeScale = freezeTime;   
    }
}
