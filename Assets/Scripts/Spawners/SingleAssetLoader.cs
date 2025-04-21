using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SingleAssetLoader
{
    private GameObject _cashedObject;

    public async Task<GameObject> Load(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        _cashedObject = await handle.Task;

        return _cashedObject;
    }

    public static T LoadWithInject<T>(T original, Transform positionRoot) where T : Object
    {
        return DiContainerSingleton.Instance.Container.InstantiatePrefabForComponent<T>(original, positionRoot);
    }

    public async Task<GameObject> LoadWithInject(AssetReference assetReference, Transform positionRoot)
    {
        var handle = Addressables.InstantiateAsync(assetReference, positionRoot);

        _cashedObject = await handle.Task;

        DiContainerSingleton.Instance.Container.InjectGameObject(_cashedObject);

        return _cashedObject;
    }

    public void Unload()
    {
        if (_cashedObject == null)
            return;

        _cashedObject.SetActive(false);

        Addressables.ReleaseInstance(_cashedObject);

        _cashedObject = null;
    }

    public async Task UnloadWithDelay()
    {
        if (_cashedObject == null)
            return;

        GameObject cashedObject = _cashedObject;

        await Task.Delay(5000);

        cashedObject.SetActive(false);

        Addressables.ReleaseInstance(cashedObject);

        //_cashedObject = null;
    }

    public static void UnloadIndividual(GameObject go)
    {
        go.SetActive(false);

        Addressables.ReleaseInstance(go);
    }
}