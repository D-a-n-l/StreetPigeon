using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefab;

    [Header("Time between spanwns")]
    [SerializeField] private float minTimeBtwSpawn = 5f;
    [SerializeField] private float maxTimeBtwSpawn = 10f;

    [Header("Spawn position range")]
    [SerializeField] private float minPosSpawn = -5;
    [SerializeField] private float maxPosSpawn = 5;
    [Space]
    [SerializeField] private bool isSpawn;

    IEnumerator Start()
    {
        while (isSpawn)
        {
            int randItem = Random.Range(0, itemPrefab.Length);
            yield return new WaitForSeconds(Random.Range(minTimeBtwSpawn, maxTimeBtwSpawn));
            Instantiate(itemPrefab[randItem], new Vector2(transform.position.x, 
                Random.Range(minPosSpawn, maxPosSpawn)), Quaternion.identity);
        }
    }
}
