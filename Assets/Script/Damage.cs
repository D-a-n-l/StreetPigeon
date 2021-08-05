using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] short damage = 25;

    public short InflictDamage()
    {
        return damage;
    }
}
