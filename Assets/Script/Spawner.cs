using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeBtwSpawn = 0f;
    [SerializeField] float startTimeBtwSpawn;
    [SerializeField] float decrease;
    [SerializeField] float minValue;

    public GameObject prefabWaring;

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
