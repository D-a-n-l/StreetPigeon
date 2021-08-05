using UnityEngine;
using UnityEngine.UI;

public class PlayerFeature : MonoBehaviour
{
    [SerializeField] private short health = 100;
    [SerializeField] private float energy = 1;
    [SerializeField] private float decreaseEnergy = 0.05f;
    [SerializeField] private float speedEffect = 0.003f;

    private float maxHealth = 100f;
    public Image barHealth;
    public Image barHealthEffect;

    public Image barEnergy;
    public Image barEnergyEffect;

    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = health;
    }

    public void Update()
    {
        LineHealth();
        LineEnergy();
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
            energy -= decreaseEnergy;
            barEnergy.fillAmount = energy;
            
        }
        barEnergyEffect.fillAmount = BarEffect(barEnergy.fillAmount, barEnergyEffect.fillAmount, 0.0009f);
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

    public void DamagePlayer(short damage)
    {
        health -= damage;
        if (health <= 1)
        {
            Destroy(gameObject, 1f);
        }
    }   
}
