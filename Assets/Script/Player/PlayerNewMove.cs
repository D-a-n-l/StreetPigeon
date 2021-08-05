using UnityEngine;

public class PlayerNewMove : MonoBehaviour
{
    [SerializeField] private float speedFly = 5f;
    [SerializeField] private float decreaseSpeed = 2f;
    private float maxSpeed;

    public Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        maxSpeed = speedFly;
        speedFly = decreaseSpeed;  
    }

    private void Update()
    {
        rb.velocity = Vector2.up * -speedFly;
    }

    public void OnButtonDown() // для кнопки 
    {
        speedFly = -maxSpeed;
        animator.SetBool("isFly", true);
    }

    public void OnButtonUp()
    {
        speedFly = decreaseSpeed;
        animator.SetBool("isFly", false);
    }
}
