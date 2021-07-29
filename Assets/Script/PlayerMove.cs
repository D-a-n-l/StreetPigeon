using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float moveY = 0f;

    [SerializeField] private float speed = 15f;
    [SerializeField] private float borderPosition = 7f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float positionY = rb.position.y + moveY * speed * Time.fixedDeltaTime;
        positionY = Mathf.Clamp(positionY, -borderPosition + (spriteRenderer.size.y / 2), borderPosition - (spriteRenderer.size.y / 2));
        rb.MovePosition(new Vector2(rb.position.x, positionY));
    }

    private void OnEnable()
    {
        PlayerInput.OnMove += Move;
    }

    private void OnDisable()
    {
        PlayerInput.OnMove -= Move;
    }

    private void Move(float moveY)
    {
        this.moveY = moveY;
    }

}
