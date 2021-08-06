using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Setting properties
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private float randScaleMin;
    [SerializeField] private float randScaleMax;
    
    // State
    [SerializeField] private bool isChangeScale = false;

    private void Start()
    {
        if (isChangeScale)
        {
            float randLocalScale = Random.Range(randScaleMin, randScaleMax);
            transform.localScale = new Vector2(randLocalScale, randLocalScale);
        }

    }

    private void Update()
    {
        transform.Translate(Vector2.left * speedMove * Time.deltaTime);
    }
}
