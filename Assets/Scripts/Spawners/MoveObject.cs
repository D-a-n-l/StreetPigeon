using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}