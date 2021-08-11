using UnityEngine;

public class ConflictZone : MonoBehaviour
{
    private const float INSTANTLY_DEATH = 0f;
    private const float SOUND_EFFECT_WAIT = 0.1f;

    [SerializeField] private bool isDestroyObject = false;
    [SerializeField] private bool isDamagePigeon = false;
    [SerializeField] private bool isAddEnergy = false;
    [SerializeField] private bool isDestroyPigeon = false;

    [SerializeField] private AudioSource soundEffect; // испавить это говно

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
                soundEffect.Play();
                player.DamagePlayer(damage.InflictDamage());
                player.OnBlinkDamage();
            }
            
            if (isAddEnergy)
            {
                soundEffect.Play();
                player.AddEnergy(damage.AddEnergy());
                Destroy(gameObject, SOUND_EFFECT_WAIT);
            }
            if (isDestroyPigeon)
            {
                player.ChangeHealthPigeon(INSTANTLY_DEATH);
                FindObjectOfType<GameSession>().PanelIsActive();
                Destroy(other.gameObject);
                Destroy(gameObject, SOUND_EFFECT_WAIT);
            }
        }

        if (isDestroyObject)
        {
            Destroy(other.gameObject);
        }
    }
}
