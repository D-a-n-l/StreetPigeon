using UnityEngine;
using UnityEngine.UI;

public class PlayerFeature : MonoBehaviour
{
    [Header("Character properties")]
    [SerializeField] private float health = 100f;
    [SerializeField] private float energy = 100f;
    [Range(0.0001f, 0.001f)]
    [SerializeField] private float decreaseEnergy = 0.05f;
    [SerializeField] private float speedEffect = 0.003f;

    [Header("Bar Health")]
    private float maxHealth;
    [SerializeField] private Image barHealth;
    [SerializeField] public Image barHealthEffect;
    
    [Header("Bar Energy")]
    private float maxEnergy;
    [SerializeField] private Image barEnergy;

    private Material pigeonBlink;
    private Material pigeonDefault;

    private Rigidbody2D rb;
    private PlayerNewMove playerNewMove;
    private SpriteRenderer spriteRend;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        playerNewMove = GetComponent<PlayerNewMove>();
        pigeonBlink = Resources.Load("PigeonMaterial", typeof(Material)) as Material;
        pigeonDefault = spriteRend.material;

        maxHealth = health;
        maxEnergy = energy;
    }

    public void Update()
    {
        LineHealth();
        LineEnergy();

        if (energy <= 0)
        {
            playerNewMove.NoSpeedEnergy();
        }
    }

    public void LineHealth()
    {
        barHealth.fillAmount = health / maxHealth;
        barHealthEffect.fillAmount = BarEffect(barHealth.fillAmount, barHealthEffect.fillAmount, speedEffect);
    }

    public void LineEnergy()
    {
        if (rb.velocity.y >= 0)
        {
            energy -= decreaseEnergy * maxEnergy;
            barEnergy.fillAmount = energy / maxEnergy;
            
        }
    }

    public float BarEffect(float bar, float effect, float speedLineEffect)
    {
        if (bar < effect)
        {
            effect -= speedLineEffect;
            return effect;
        }
        else
        {
            return bar;
        }
    }

    public void AddEnergy(float addEnergy)
    {
        if (energy <= maxEnergy)
        {
            energy += addEnergy;
            barEnergy.fillAmount = energy / maxEnergy;
        }
        
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
            barEnergy.fillAmount = energy / maxEnergy;
        }
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;
        if (health <= 1)
        {
            FindObjectOfType<GameSession>().PanelIsActive();
            Destroy(gameObject, 1f);
        }
    }  

    public void OnBlinkDamage()
    {
        spriteRend.material = pigeonBlink;
        Invoke("OffBlinkDamage", 0.2f);
    }

    private void OffBlinkDamage()
    {
        spriteRend.material = pigeonDefault;
    }

    public void ChangeHealthPigeon(float decreaseHealth)
    {
        health = decreaseHealth;
        barHealth.fillAmount = health;
    }
}
