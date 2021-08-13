using UnityEngine;

public class ConflictZone : MonoBehaviour
{
    private const float INSTANTLY_DEATH = 0f;

    [SerializeField] private bool isDestroyObject = false;
    [SerializeField] private bool isDamagePigeon = false;
    [SerializeField] private bool isAddEnergy = false;
    [SerializeField] private bool isDestroyPigeon = false;

    [SerializeField] private AudioClip audioClip;

    private InteractionPlayer damage;
    private CameraShake cameraShake;
    
    private void Start()
    {
        cameraShake = FindObjectOfType<CameraShake>();
        damage = GetComponent<InteractionPlayer>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)                     // Этот скрипт скорее всего сильно влияет на производительность
    {                                                                   // он обрабатывает все возможные столкновения с объеками
        if (other.gameObject.TryGetComponent(out PlayerFeature player)) // В будущих патчах обязательно исправить 
        {
            if (isDamagePigeon)
            {
                AudioSource.PlayClipAtPoint(audioClip, new Vector2(0f, 0f), MasterPlayerPrefs.GetVolumeMaster());
                player.DamagePlayer(damage.InflictDamage());
                cameraShake.ShakeCamera();
                player.OnBlinkDamage();
            }
            
            if (isAddEnergy)
            {
                player.AddEnergy(damage.AddEnergy());
                isDestroy();
            }
            if (isDestroyPigeon)
            {
                player.ChangeHealthPigeon(INSTANTLY_DEATH);
                FindObjectOfType<GameSession>().PanelIsActive();             
                Destroy(other.gameObject);
                isDestroy();
            }
        }

        if (isDestroyObject)
        {
            Destroy(other.gameObject);
        }
    }

    private void isDestroy()
    {
        AudioSource.PlayClipAtPoint(audioClip, new Vector2(0f, 0f), MasterPlayerPrefs.GetVolumeMaster());
        Destroy(gameObject);
    }
}
