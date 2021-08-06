using UnityEngine;

public class InteractionPlayer : MonoBehaviour
{
    [SerializeField] private float damage = 25;
    [SerializeField] private float addEnergy = 10f;

    public float InflictDamage()
    {
        return damage;
    }

    public float AddEnergy()
    {
        return addEnergy;
    }
}
