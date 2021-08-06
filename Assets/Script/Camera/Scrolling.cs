using UnityEngine;

public class Scrolling : MonoBehaviour
{

    [SerializeField] private float parallaxSpeed = 8f;
    [SerializeField] private float backgroundSize;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10f;
    private int leftIndex;
    private int rightIndex;

    private void Start()
    {
        cameraTransform = Camera.main.transform;

        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * parallaxSpeed * Time.deltaTime);

        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
        {
            scrollRight();
        }

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
        {
            scrollLeft();
        }
    }

    private void scrollRight()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void scrollLeft()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
