using System;
using System.Collections;
using UnityEngine;


public class MeteorMove : MonoBehaviour
{
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int countTup;
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform pointExplosion;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip death;

    private Vector3 pigeonPosition;
    private int countTupDoes;

    private void Start()
    {
        try
        {
            pigeonPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position;
        }
        catch (Exception)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // В дальнейшем исправить, чтобы метерор летел по трактории к игроку
        if (transform.position == pigeonPosition)
        {
            pigeonPosition += offset;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pigeonPosition, speedMove * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (countTupDoes <= countTup)
        {
            countTupDoes++;
        }
        else
        {
            DestroyObjectPlay();
        }
    }

    private void DestroyObjectPlay()
    {
        Instantiate(explosion, pointExplosion.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(death, transform.position);
        Destroy(gameObject);
    }
}
