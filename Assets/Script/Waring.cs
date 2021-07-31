using UnityEngine;

public class Waring : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float viewZone = 14.8f;

    private float cameraPosition;
    private Damage damage; 
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        damage = GetComponent<Damage>();
        cameraPosition = Camera.main.transform.position.x;

        float randLocalScale = Random.Range(0.3f, 0.45f);
        transform.localScale = new Vector2(randLocalScale, randLocalScale);
        int randSprite = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randSprite];
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (cameraPosition > transform.position.x + viewZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerFeature plyaer))
        {
            plyaer.DamagePlayer(damage.InflictDamage());
        }
    }
}
