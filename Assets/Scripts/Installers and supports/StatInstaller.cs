using UnityEngine;
using Zenject;

public class StatInstaller : MonoInstaller
{
    [SerializeField]
    private Health _health;

    [SerializeField]
    private Energy _energy;

    public override void InstallBindings()
    {
        Container.Bind<Health>().FromInstance(_health);
        Container.Bind<Energy>().FromInstance(_energy);
    }
}