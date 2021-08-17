using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGolube : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deadZone;
    [SerializeField] private GameObject button;

    [SerializeField] private float waitTime = 6f;
    [SerializeField] private float waitTimeTwo = 6f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        player.SetActive(true);
        yield return new WaitForSeconds(waitTimeTwo);
        deadZone.SetActive(true);
        button.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
