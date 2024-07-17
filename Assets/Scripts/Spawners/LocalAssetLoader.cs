using UnityEngine;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class LocalAssetLoader
{
    private static Queue<GameObject> _cashedObject = new Queue<GameObject>(2);

    public async static void LoadInternalPool(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        _cashedObject.Enqueue(await handle.Task);
    }

    public static void UnloadInternalPool()
    {
        if (_cashedObject.Count() == 0)
            return;

        _cashedObject.First().SetActive(false);

        Addressables.ReleaseInstance(_cashedObject.First());

        _cashedObject.Dequeue();
    }

    public static void UnloadAlll()
    {
        if (_cashedObject.Count() == 0)
            return;

        for(int i = 0; i < 2; i++)
        {
            _cashedObject.First().SetActive(false);
            
            Addressables.ReleaseInstance(_cashedObject.First());

            _cashedObject.Dequeue();
        }

        _cashedObject.Clear();
    }


    public static Task<GameObject> LoadInternalSingle(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        return handle.Task;
    }

    public static void UnloadInternalSingle(GameObject gameobject)
    {
        gameobject.SetActive(false);

        Addressables.ReleaseInstance(gameobject);
    }
}