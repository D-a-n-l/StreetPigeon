using UnityEngine;

public class MeteorMove : MonoBehaviour
{
    private const int MOUSE_BUTTON_LEFT = 0;

    [SerializeField] private float speedMove = 5f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private int countTup;
    private Vector3 pigeonPosition;
    private int countTupDoes;

    private void Start()
    {
        pigeonPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position;
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
            Destroy(gameObject);
        }
    }
}
