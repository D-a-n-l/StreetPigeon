using UnityEngine;

public class PlayerNewMove : MonoBehaviour
{
    [SerializeField] private float speedFlyUp = 5f;
    [SerializeField] private float decreaseSpeed = 2f;
    private float maxSpeed;

    public Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = speedFlyUp;
        speedFlyUp = decreaseSpeed;  
    }

    private void Update()
    {
        rb.velocity = Vector2.up * -speedFlyUp;
    }

    public void OnButtonDown()
    {
        speedFlyUp = -maxSpeed;
        animator.SetBool("isFly", true);
    }

    public void OnButtonUp()
    {
        speedFlyUp = decreaseSpeed;
        animator.SetBool("isFly", false);
    }
    
    public void NoSpeedEnergy()
    {
        speedFlyUp = 1f;
    }
}
