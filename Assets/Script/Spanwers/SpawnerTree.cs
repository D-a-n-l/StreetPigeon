using UnityEngine;

public class SpawnerTree : MonoBehaviour
{
    [SerializeField] private float startTimeBtwSpawn;
    [SerializeField] private float decrease;
    [SerializeField] private float minValue;
    [Space]
    [SerializeField] private GameObject prefabWaring;
       
    private float timeBtwSpawn = 0f;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(prefabWaring, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (minValue < startTimeBtwSpawn)
            {
                startTimeBtwSpawn -= decrease;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
