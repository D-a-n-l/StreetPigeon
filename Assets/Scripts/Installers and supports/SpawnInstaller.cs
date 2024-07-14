using UnityEngine;
using Zenject;

public class SpawnInstaller : MonoInstaller
{
    [SerializeField]
    private LoopSpawnObject _loopSpawnObject;

    public override void InstallBindings()
    {
        Container.Bind<LoopSpawnObject>().FromInstance(_loopSpawnObject);
    }
}