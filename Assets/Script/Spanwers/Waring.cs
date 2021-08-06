using UnityEngine;

public class Waring : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float randScaleMin;
    [SerializeField] private float randScaleMax;
    
    private void Start()
    {
        float randLocalScale = Random.Range(randScaleMin, randScaleMax);
        transform.localScale = new Vector2(randLocalScale, randLocalScale);
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
