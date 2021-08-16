using System.Collections;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    [Header("Complexity Game")]
    [SerializeField] private GameObject[] EasyLocationsPrefab;
    [SerializeField] private GameObject[] AverageLocationsPrefab;
    [SerializeField] private GameObject[] HardLocationsPrefab;
    [SerializeField] private int average = 1000;
    [SerializeField] private int hard = 2200;
    private GameObject[] nowComplexity;
    [Space]
    [SerializeField] private float timeSpawn = 5f;
    [SerializeField] private float timeDestroyObject = 5f;
    [Space]
    [SerializeField] private bool isSpawn = true;
    [Space]
    [SerializeField] private GameSession gameSession;
    IEnumerator Start()
    {
        nowComplexity = EasyLocationsPrefab;

        while(isSpawn)
        {
            if (gameSession.ShowScoreGame() > average)
            {
                nowComplexity = AverageLocationsPrefab;
                Debug.Log("Average");
            }
            if (gameSession.ShowScoreGame() > hard)
            {
                nowComplexity = HardLocationsPrefab;
                Debug.Log("Hard");
            }

            int rand = Random.Range(0, nowComplexity.Length);
            yield return new WaitForSeconds(timeSpawn);
            Instantiate(nowComplexity[rand], transform.position, Quaternion.identity);
        }

        if(!isSpawn)
        {
            yield return new WaitForSeconds(timeDestroyObject);
            Destroy(gameObject);
        }
    }
}
