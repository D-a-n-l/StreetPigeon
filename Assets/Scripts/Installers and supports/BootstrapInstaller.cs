using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField]
    private Bootstrap _bootstrap;

    public override void InstallBindings()
    {
        Container.Bind<Bootstrap>().FromInstance(_bootstrap).AsSingle();
    }
}