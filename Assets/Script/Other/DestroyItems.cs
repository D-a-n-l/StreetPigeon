using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    [SerializeField] private float lifetime = 0.5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
