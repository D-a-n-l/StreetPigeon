using UnityEngine;
using Zenject;

public class SpawnConfigInstaller : MonoInstaller
{
    [SerializeField]
    private LoopSpawnConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<LoopSpawnConfig>().FromInstance(_config);
    }
}