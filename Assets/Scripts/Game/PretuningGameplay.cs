using System.Collections;
using UnityEngine;

public class PretuningGameplay : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject topDeadZone;

    [SerializeField]
    private GameObject buttonMove;

    [SerializeField]
    private float waitTimeSpawnPlayer = 3f;

    [SerializeField]
    private float waitTimeBUttonAndDeadZone = 3f;

    private void Awake()
    {
        player.SetActive(false);

        topDeadZone.SetActive(false);

        buttonMove.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTimeSpawnPlayer);

        player.SetActive(true);

        yield return new WaitForSeconds(waitTimeBUttonAndDeadZone);

        topDeadZone.SetActive(true);

        buttonMove.SetActive(true);
    }
}