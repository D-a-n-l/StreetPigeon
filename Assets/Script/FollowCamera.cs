using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerThansform;


    private void Update()
    {
        transform.position = new Vector3(playerThansform.transform.position.x, transform.position.y, transform.position.z); 
    }
}
