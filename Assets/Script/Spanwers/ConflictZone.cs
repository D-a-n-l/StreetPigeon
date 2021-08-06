using UnityEngine;

public class ConflictZone : MonoBehaviour
{
    [SerializeField] private bool isDestroyItem = false;
    [SerializeField] private bool isDamagePigeon = false;
    [SerializeField] private bool isAddEnergy = false;
    [SerializeField] private bool isDestroyPigeon = false;


    private Damage damage;
    
    private void Start()
    {
        damage = GetComponent<Damage>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerFeature player))
        {
            if (isDamagePigeon)
            {
                player.DamagePlayer(damage.InflictDamage());
                player.OnBlinkDamage();
            }
            
            if (isAddEnergy)
            {
                player.AddEnergy(damage.AddEnergy());
                Destroy(gameObject);
            }
            if (isDestroyPigeon)
            {
                FindObjectOfType<GameSession>().PanelIsActive();
                Destroy(other.gameObject);
            }
        }

        if (isDestroyItem)
        {
            Destroy(other.gameObject);
        }
    }
}
