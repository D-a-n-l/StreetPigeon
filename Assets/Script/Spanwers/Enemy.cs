using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Damage damage;

    private void Start()
    {
        damage = GetComponent<Damage>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerFeature plyaer))
        {
            plyaer.DamagePlayer(damage.InflictDamage());
        }
    }
}
