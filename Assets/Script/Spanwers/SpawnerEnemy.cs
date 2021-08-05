using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minTimeBtwSpawn = 5f;
    [SerializeField] private float maxTimeBtwSpawn = 10f;
    [SerializeField] private int minPosSpawn = -5;
    [SerializeField] private int maxPosSpawn = 5;
    [SerializeField] private bool isSpawn;

    IEnumerator Start()
    {
        while(isSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn));
            Instantiate(enemyPrefab, new Vector2(transform.position.x, Random.Range(minPosSpawn, maxPosSpawn)), Quaternion.identity);
        }
    }
}
