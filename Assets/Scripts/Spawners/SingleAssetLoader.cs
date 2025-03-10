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
}