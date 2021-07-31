using UnityEngine;
using UnityEngine.UI;

public class PlayerFeature : MonoBehaviour
{
    [SerializeField] private short health = 100;
    [SerializeField] private float speedEffect = 0.003f;

    private float maxHealth = 100f;
    public Image barHealth;
    public Image barEffect;
    
    private void Start()
    {
        maxHealth = health;
    }

    public void Update()
    {
        LineHealth();
    }

    public void LineHealth()
    {
        barHealth.fillAmount = health / maxHealth;
        if (barHealth.fillAmount < barEffect.fillAmount)
        {
            barEffect.fillAmount -= speedEffect;
        }
        else
        {
            barEffect.fillAmount = barHealth.fillAmount;
        }
    }

    public void DamagePlayer(short damage)
    {
        health -= damage;
        if (health <= 1)
        {
            Destroy(gameObject, 0.5f);
        }

        
    }
    
}
