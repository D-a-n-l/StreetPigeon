using UnityEngine;
using Zenject;

public class SkinsInstaller : MonoInstaller
{
    [SerializeField]
    private Skins _skins;

    [SerializeField]
    private SettableSkin _settableSkin;

    public override void InstallBindings()
    {
        Container.Bind<Skins>().FromInstance(_skins).AsSingle();

        Container.Bind<SettableSkin>().FromInstance(_settableSkin).AsSingle();
    }
}