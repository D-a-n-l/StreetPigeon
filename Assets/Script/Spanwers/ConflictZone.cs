using UnityEngine;

public class ConflictZone : MonoBehaviour
{
    private const float INSTANTLY_DEATH = 0f;

    [SerializeField] private bool isDestroyObject = false;
    [SerializeField] private bool isDamagePigeon = false;
    [SerializeField] private bool isAddEnergy = false;
    [SerializeField] private bool isDestroyPigeon = false;


    private InteractionPlayer damage;
    
    private void Start()
    {
        damage = GetComponent<InteractionPlayer>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)                     // Этот скрипт скорее всего сильно влияет на производительность
    {                                                                   // он обрабатывает все возможные столкновения с объеками
        if (other.gameObject.TryGetComponent(out PlayerFeature player)) // В будущих патчах обязательно исправить 
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
                player.ChangeHealthPigeon(INSTANTLY_DEATH);
                Destroy(other.gameObject);
            }
        }

        if (isDestroyObject)
        {
            Destroy(other.gameObject);
        }
    }
}
