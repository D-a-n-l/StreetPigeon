using UnityEngine;
using Zenject;

public class SpawnConfigInstaller : MonoInstaller
{
    [SerializeField]
    private SpawnerConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<SpawnerConfig>().FromInstance(_config);
    }
}