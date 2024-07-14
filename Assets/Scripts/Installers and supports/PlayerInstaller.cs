using System.ComponentModel;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private MovingPlayer _movingPlayer;

    public override void InstallBindings()
    {
        Container.Bind<MovingPlayer>().FromInstance(_movingPlayer);
    }
}