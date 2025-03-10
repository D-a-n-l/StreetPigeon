using UnityEngine;
using Zenject;

public class StatsInstaller : MonoInstaller
{
    [Min(0.001f)]
    [SerializeField]
    private float _maxHealth = 100f;

    [Min(0.001f)]
    [SerializeField]
    private float _maxEnergy = 100f;

    public override void InstallBindings()
    {
        BindHealth();

        BindEnergy();
    }

    private void BindHealth()
    {
        Health health = new Health(_maxHealth);

        Container.Bind<Health>().FromInstance(health).AsSingle();
    }

    private void BindEnergy()
    {
        Energy energy = new Energy(_maxEnergy);

        Container.Bind<Energy>().FromInstance(energy).AsSingle();
    }
}