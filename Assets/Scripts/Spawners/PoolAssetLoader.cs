using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.Linq;

public class PoolAssetLoader
{
    private Queue<GameObject> _cashedObjects = new Queue<GameObject>(2);

    public async void Load(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        _cashedObjects.Enqueue(await handle.Task);
    }

    public async void LoadWithInject(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        DiContainerSingleton.Instance.Container.InjectGameObject(await handle.Task);

        _cashedObjects.Enqueue(await handle.Task);
    }

    public void UnloadFirst()
    {
        if (_cashedObjects.Count() == 0)
            return;

        _cashedObjects.First().SetActive(false);

        Addressables.ReleaseInstance(_cashedObjects.First());

        _cashedObjects.Dequeue();
    }

    public void UnloadAll()
    {
        if (_cashedObjects.Count() == 0)
            return;

        for(int i = 0; i < 2; i++)
        {
            _cashedObjects.First().SetActive(false);
            
            Addressables.ReleaseInstance(_cashedObjects.First());

            _cashedObjects.Dequeue();
        }

        _cashedObjects.Clear();
    }
}