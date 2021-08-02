using UnityEngine;

public class Waring : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float viewZone = 14.8f;
    [SerializeField] private float randScaleMin;
    [SerializeField] private float randScaleMax;

    private float cameraPosition;
    private Damage damage; 
    
    private void Start()
    {
        damage = GetComponent<Damage>();
        cameraPosition = Camera.main.transform.position.x;

        float randLocalScale = Random.Range(randScaleMin, randScaleMax);
        transform.localScale = new Vector2(randLocalScale, randLocalScale);
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
